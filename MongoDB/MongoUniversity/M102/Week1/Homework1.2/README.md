# Homework 1.2

## Problem

Download the handout. Take a look at its content.

Now, import its contents into MongoDB, into a database called "pcat" and a collection called "products". Use the mongoimport utility to do this.

When done, run this query in the mongo shell:
```
db.products.find( { type : "case" } ).count()
```
What's the result?

## Solution
```sh
mongoimport --db pcat --colection products < Products__hw1.2_m102_529e39a8e2d42347509fb3f0.json
```

## Answer
```
3
```