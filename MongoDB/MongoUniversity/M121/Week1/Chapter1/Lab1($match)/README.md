# Lab - $match

## Problem

Help MongoDB pick a movie our next movie night! Based on employee polling, we've decided that potential movies must meet the following criteria.

* imdb.rating is at least 7
* genres does not contain "Crime" or "Horror"
* rated is either "PG" or "G"
* languages contains "English" and "Japanese"

Assign the aggregation to a variable named pipeline, like:
```
var pipeline = [ { $match: { ... } } ]
```
* As a hint, your aggregation should return 23 documents. You can verify this by typing db.movies.aggregate(pipeline).itcount()
* Load validateLab1.js into mongo shell
```
load('validateLab1.js')
```
* And run the validateLab1 validation method
```
validateLab1(pipeline)
```
What is the answer?

## Solution
```sh
> var pipeline = [
	{
		$match: 
			{ 
				$and: 
				[ 
					{ "imdb.rating": { $gte: 7 } }, 
					{ "genres": { $nin: ["Crime", "Horror"]} },
					{ "rated": { $in: ["PG", "G"]} },
					{ "languages": { $all: [ "English", "Japanese" ]}
				]
			}
	}
]
```
## Answer
10