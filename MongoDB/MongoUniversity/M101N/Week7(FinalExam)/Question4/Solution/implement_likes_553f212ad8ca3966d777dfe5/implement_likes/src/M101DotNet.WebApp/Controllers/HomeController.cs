﻿using System;
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
            var recentPosts = await blogContext.Posts.Find(x => true)
                .SortByDescending(x => x.CreatedAtUtc)
                .Limit(10)
                .ToListAsync();

            var tags = await blogContext.Posts.Aggregate()
                .Project(x => new { _id = x.Id, Tags = x.Tags })
                .Unwind(x => x.Tags)
                .Group<TagProjection>("{ _id: '$Tags', Count: { $sum: 1 } }")
                .ToListAsync();

            var model = new IndexModel
            {
                RecentPosts = recentPosts,
                Tags = tags
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
            var post = new Post
            {
                Author = User.Identity.Name,
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags.Split(' ', ',', ';'),
                CreatedAtUtc = DateTime.UtcNow,
                Comments = new List<Comment>()
            };

            await blogContext.Posts.InsertOneAsync(post);

            return RedirectToAction("Post", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Post(string id)
        {
            var blogContext = new BlogContext();

            var post = await blogContext.Posts.Find(x => x.Id == id).SingleOrDefaultAsync();

            if (post == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PostModel
            {
                Post = post,
                NewComment = new NewCommentModel
                {
                    PostId = id
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Posts(string tag = null)
        {
            var blogContext = new BlogContext();

            Expression<Func<Post, bool>> filter = x => true;

            if (tag != null)
            {
                filter = x => x.Tags.Contains(tag);
            }

            var posts = await blogContext.Posts.Find(filter)
                .SortByDescending(x => x.CreatedAtUtc)
                .ToListAsync();

            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NewComment(NewCommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = model.PostId });
            }

            var comment = new Comment
            {
                Author = User.Identity.Name,
                Content = model.Content,
                CreatedAtUtc = DateTime.UtcNow
            };

            var blogContext = new BlogContext();

            await blogContext.Posts.UpdateOneAsync(
                x => x.Id == model.PostId,
                Builders<Post>.Update.Push(x => x.Comments, comment));


            return RedirectToAction("Post", new { id = model.PostId });
        }

        [HttpPost]
        public async Task<ActionResult> CommentLike(CommentLikeModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = model.PostId });
            }

            var blogContext = new BlogContext();

            // XXX WORK HERE
            // Increment the Likes field for the comment at {model.Index}
            // inside the post {model.PostId}.
            //
            // NOTE: The 2.0.0 driver has a bug in the expression parser and 
            // might throw an exception depending on how you solve this problem. 
            // This is documented here along with a workaround:
            // https://jira.mongodb.org/browse/CSHARP-1246

            var likesFieldPath = $"Comments.{model.Index}.Likes";

            await blogContext.Posts.FindOneAndUpdateAsync(
                x => x.Id == model.PostId,
                Builders<Post>.Update.Inc(likesFieldPath, 1));

            return RedirectToAction("Post", new { id = model.PostId });
        }
    }
}