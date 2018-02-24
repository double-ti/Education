# Homework 5.1

## Problem

Finding the most frequent author of comments on your blog
In this assignment you will use the aggregation framework to find the most frequent author of comments on your blog. We will be using a data set similar to ones we've used before.
Start by downloading the handout zip file for this problem. Then import into your blog database as follows:
mongoimport --drop -d blog -c posts posts.json
Now use the aggregation framework to calculate the author with the greatest number of comments.
To help you verify your work before submitting, the author with the fewest comments is Mariela Sherer and she commented 387 times.

## Solution

```sh
> db.posts.aggregate([
	{
		$unwind : "$comments"
	},
	{
		$group: {_id: "$comments.author", count: {$sum: 1}}
	},
	{
		$sort: {count: -1}
	},
	{
		$limit: 1
	}
])
```
## Answer

Elizabet Kleine
