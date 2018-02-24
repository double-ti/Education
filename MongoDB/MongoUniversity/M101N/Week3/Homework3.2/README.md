# Homework 3.2

## Problem

In this homework you will be enhancing the blog project to insert entries into the posts collection. After this, the blog will work. It will allow you to add blog posts with a title, content, and tags and have it be added to the posts collection properly.

We have provided the code that creates users and allows you to login (the assignment from last week). To get started, please download the handout and unpack.

The areas where you need to add code are marked with XXX. You need only touch the Post.cs file, the Comments.cs file, and the HomeController.cs file. There are seven locations for you to add code for this problem:

* 5 in HomeController.cs
* 1 in Post.cs
* 1 in Comment.cs

Here is an example of a valid blog post.
```sh
> db.posts.find().pretty()
{
        "_id" : ObjectId("54c298ec122ea911588b7970"),
        "Author" : "Craig",
        "Title" : "Frist!!!",
        "Content" : "This is my first post!!!",
        "Tags" : [
                "first",
                "awesome"
        ],
        "CreatedAtUtc" : ISODate("2015-01-23T18:54:36.335Z"),
        "Comments" : [
                {
                        "Author" : "Jack",
                        "Content" : "This is a comment.",
                        "CreatedAtUtc" : ISODate("2015-01-23T18:54:42.005Z")
                }
        ]
}
```
We are going to validate that this worked properly. We will be checking for the following functionality:

* Your blog can accept posts.
* Your posts can be tagged.
* Your posts can receive comments from others who are logged in.
When you are ready, turn it in using mongoProc.

## Solution
Source code in Solution folder