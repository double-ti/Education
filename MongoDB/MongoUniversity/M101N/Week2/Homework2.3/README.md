# Homework 2.3

## Problem

Download Mongoproc clients from [here](https://university.mongodb.com/mongoproc) if you haven't done so, yet.

You may need to spend some time setting it up.

* Login with your email/password combination that you use for university.mongodb.com.
* When you log in, you can see a 'settings' button. Click on it to set host:port values.
* Your blog should be hosted on localhost:57912, and mongoProc is not pointed there by default.
* Your mongod is on port 27017 by default, and mongoProc should point there initially; when you change it, it should stick.

This is the beginning of the blog project with the UI for creating and logging in blog authors, but nothing to display posts.

The project uses ASP.NET MVC5. You should open the solution file (.sln) in Visual Studio and recognize a typical project. We have used the included template and haven't pulled in any extra dependencies.

The project won't compile immediately as there are missing pieces you'll need to fill out. These pieces are marked with XXX in a comment. You shouldn't need to touch any other code. First, in User.cs, you'll need to add in the contents of the User object. Second, in AccountController, you'll need to insert a user and retrieve a user by email.

The blog stores its data in the "blog" database in the "users" collection. Here are two example documents from the users collection. You can insert these if you'd like, but you don't need to.

```sh
> db.users.find()
{ "_id" : ObjectId("54c272a9122ea91adc328696"), "Name" : "Craig", "Email" : "craig@craig.com" }
{ "_id" : ObjectId("54c27f50122ea914546658be"), "Name" : "Andrew", "Email" : "andrews@andrew.com" }
```
Once you have the project working, the following steps should work.

Click "Register" on the home page and register a user.
Click "Login" on login with the user you just created.
Ok, now it's time to validate that you got it all working.

From the top of this page, there was one additional program that should have been downloaded: mongoProc.

With it, you can test your code and look at the Feedback section. When it says "user creation successful" and "user login successful", you can turn in your assignment.

You will see a message below about your number of submissions, but you must submit this assignment using MongoProc.

## Solution
Source code in Solution folder