# Homework 4.3

## Problem

In this homework assignment you will be adding some indexes to the post collection to make the blog fast.

We have provided the full code for the blog application and you don't need to make any changes, or even run the blog. But you can, for fun.

We are also providing a generated data set with 10000 entries with comments and tags. You must load this dataset to complete the problem. Unzip the mongodump handout. You should see a "dump" directory in your working directory; the "dump" directory contains your mongodump.

First, begin by dropping your blog database, and loading the sample data and taking a look:
```
echo db.dropDatabase() | mongo blog
mongorestore dump
mongo blog
```
Now your 'blog' database should contain 10,000 blog posts (randomly generated) in the 'posts' collection. The users collection is also populated, but you can ignore it if you like.

Your assignment is to make the following pages fast:

* The blog home page (http://localhost:57912/)
* The posts page where it displays posts by tag (http://localhost:57912/Home/Posts?tag=Van)

The tag should be whatever tag we wish to use.

By fast, we mean that an index should satisfy these queries such that we only need to scan the number of documents we are going to return.

Just to be clear, the mongoProc feedback will refer to the web pages that invoke the queries, but it will not be hitting any URLs, just the mongod that you're pointing it to.

You'll want to figure out (by examining the C# code in the handout, or by any other means available to you (such as the database profiler) which queries are triggered. Once you know that, build an index to optimize it.

Once you have added the indexes to make those pages fast, validate and turn in the homework using mongoProc.

## Solution
Create index for home page:
```sh
> db.posts.createIndex({"CreatedAtUtc":1})

```
Create index for page where posts displays by tag:
```sh
> db.posts.createIndex({"Tags" : 1, "CreatedAtUtc":1}

```