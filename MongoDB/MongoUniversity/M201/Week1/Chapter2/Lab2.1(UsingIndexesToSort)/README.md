# Lab 2.1: Using Indexes to Sort

## Problem

In this lab you're going to determine which queries are able to successfully use a given index for both filtering and sorting.

Given the following index:
```
{ "first_name": 1, "address.state": -1, "address.city": -1, "ssn": 1 }
```
Which of the following queries are able to use it for both filtering and sorting?

1. db.people.find({ "first_name": "Jessica" }).sort({ "address.state": 1, "address.city": 1 })
2. db.people.find({ "address.city": "West Cindy" }).sort({ "address.city": -1 })
3. db.people.find({ "address.state": "South Dakota", "first_name": "Jessica" }).sort({ "address.city": -1 })
4. db.people.find({ "first_name": { $gt: "J" } }).sort({ "address.city": -1 })
5. db.people.find({ "first_name": "Jessica", "address.state": { $lt: "S"} }).sort({ "address.state": 1 })

## Answer
1, 3, 5