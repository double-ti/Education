# Question 4

## Problem

For this problem, you will be implementing the functionality needed to "like" a comment in the blog.

First, download and unpack the blog solution handout.

Next, find the "XXX" in HomeController.cs. This is where you will need to code in the ability to "like" a comment.

When you are done, the following functionality will be in place:

* When you are logged in, and you view a post in its own page (/Home/Post/<post_id>), each post will have a number of "Likes".
* When you click on the "Likes" button, it gets incremented by one.
* You can like a comment as many times as you wish; each click will increment it by one.
* You can even like your own comments.

In your "blog.posts" documents, the "Comments" subdocuments will each contain a "Likes" field. Its value will be a number, and that number will be the number of "Likes" for that comment. Here is an example:
```
{
    "_id" : ObjectId("552a32e84a01d700485c6475"),
    "Author" : "Bender",
    "Title" : "Announcing my Blog",
    "Content" : "This is my blog.",
    "Tags" : [
        "announcements",
        "benderIsGreat"
    ],
    "CreatedAtUtc" : ISODate("3015-04-14T23:34:00.598Z"),
    "Comments" : [
        {
            "Author" : "Bender",
            "Content" : "Another job well done!",
            "CreatedAtUtc" : ISODate("3015-04-14T23:34:17.430Z"),
            "Likes" : 2
        }
    ]
}
```
When you are ready to submit, please do so using mongoProc.
## Solution
Source code in Solution folder
