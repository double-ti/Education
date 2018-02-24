# Homework 4.4

## Problem

In this problem you will analyze a profile log taken from a different mongoDB instance and you will import it into a collection named sysprofile. To start, please download sysprofile.json from Download Handout link and import it with the following command:
```
mongoimport --drop -d m101 -c sysprofile sysprofile.json
```
Now query the profile data, looking for all queries to the students collection in the database school2, sorted in order of decreasing latency. What is the latency of the longest running operation to the collection, in milliseconds?

## Solution

```
> db.profile.find({}, {millis: 1}).sort({millis: -1}).limit(1)

```
## Answer
```
15820
```