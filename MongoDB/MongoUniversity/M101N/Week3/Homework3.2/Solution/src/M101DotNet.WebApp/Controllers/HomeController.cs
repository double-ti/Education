using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using M101DotNet.WebApp.Models;
using M101DotNet.WebApp.Models.Home;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace M101DotNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var blogContext = new BlogContext();
            // XXX WORK HERE
            // find the most recent 10 posts and order them
            // from newest to oldest

            var db = blogContext.Client.GetDatabase("blog");
            var postsCollection = db.GetCollection<Post>("posts");

            var recentPosts = await postsCollection.Find(_ => true).SortBy(q => q.CreatedAtUtc).Limit(10).ToListAsync();

            var model = new IndexModel
            {
                RecentPosts = recentPosts
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NewPost()
        {
            return View(new NewPostModel());
        }

        [HttpPost]
        public async Task<ActionResult> NewPost(NewPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogContext = new BlogContext();
            // XXX WORK HERE
            // Insert the post into the posts collection

            var db = blogContext.Client.GetDatabase("blog");
            var postsCollection = db.GetCollection<Post>("posts");

            var post = new Post
            {
                Id = ObjectId.GenerateNewId(),
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags.Split(',').Select(q => q.Trim()).ToArray(),
                CreatedAtUtc = DateTime.UtcNow,
                Author = User.Identity.Name,
                Comments = new List<Comment>()
            };

            await postsCollection.InsertOneAsync(post);

            return RedirectToAction("Post", new {id = post.Id});
        }

        [HttpGet]
        public async Task<ActionResult> Post(string id)
        {
            var blogContext = new BlogContext();

            // XXX WORK HERE
            // Find the post with the given identifier

            var db = blogContext.Client.GetDatabase("blog");
            var postsCollection = db.GetCollection<Post>("posts");

            var post = await postsCollection.Find(q => q.Id == ObjectId.Parse(id)).SingleAsync();

            if (post == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PostModel
            {
                Post = post
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Posts(string tag = null)
        {
            var blogContext = new BlogContext();

            // XXX WORK HERE
            // Find all the posts with the given tag if it exists.
            // Otherwise, return all the posts.
            // Each of these results should be in descending order.

            var db = blogContext.Client.GetDatabase("blog");
            var postsCollection = db.GetCollection<Post>("posts");

            var posts = await postsCollection.Find(q => q.Tags.Any(t => t == tag)).SortByDescending(q => q.CreatedAtUtc).ToListAsync();

            if (posts.Count == 0)
                posts = await postsCollection.Find(_ => true).SortByDescending(q => q.CreatedAtUtc).ToListAsync();

            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NewComment(NewCommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new {id = model.PostId});
            }

            var blogContext = new BlogContext();
            // XXX WORK HERE
            // add a comment to the post identified by model.PostId.
            // you can get the author from "this.User.Identity.Name"

            var db = blogContext.Client.GetDatabase("blog");
            var postsCollection = db.GetCollection<Post>("posts");

            await postsCollection.FindOneAndUpdateAsync(
                q => q.Id == ObjectId.Parse(model.PostId),
                Builders<Post>.Update.Push(q => q.Comments, new Comment {CreatedAtUtc = DateTime.UtcNow, Content = model.Content, Author = User.Identity.Name}));

            return RedirectToAction("Post", new {id = model.PostId});
        }
    }
}