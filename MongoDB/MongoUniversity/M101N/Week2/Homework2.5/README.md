# Homework 2.5

## Problem

Using the video.movieDetails collection, how many movies list "Sweden" second in the the list of countries.

NOTE: There is a dump of the video database included in the handouts for the "Creating Documents" lesson. Use that data set to answer this question.

## Solution
```sh
> db.movieDetails.find({'countries.1': 'Sweden'}).count()
```
## Answer
6