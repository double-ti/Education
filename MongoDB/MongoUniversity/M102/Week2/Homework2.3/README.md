# Homework 2.3

## Problem

How many products have a voice limit? (That is, have a voice field present in the limits subdocument.)

Input your answer below, (just a number, no other characters).

While you can parse this one by eye, please try to use a query that will do the work of counting it for you.

Just to clarify, the answer should be a number, not a document. There should be no brackets, spaces, quotation marks, etc.

## Solution
```
db.products.find({"limits.voice": {$exists: true}}).count()
```
## Answer
```
3
```