# Lab - Changing Document Shape with $project

## Problem

Our first movie night was a success. Unfortunately, our ISP called to let us know we're close to our bandwidth quota, but we need another movie recommendation!

Using the same $match stage from the previous lab, add a $project stage to only display the the title and film rating (title and rated fields).

* Assign the results to a variable called pipeline.
```
var pipeline = [{ $match: {. . .} }, { $project: { . . . } }]
```

* Load validateLab2.js which was included in the same handout as validateLab1.js and execute validateLab2(pipeline)?
```
load('./validateLab2.js')
```
* And run the validateLab2 validation method
```
validateLab2(pipeline)
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
					{ "rated": { $in: ["PG", "G"] } },
					{ "languages": { $all: [ "English", "Japanese" ]}
				]
			}
	},
	{ $project: { _id: 0, title:1, rated:1 }}
]
```
## Answer
15