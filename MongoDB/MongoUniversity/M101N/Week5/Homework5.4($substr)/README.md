# Homework 5.4 ($substr)

## Problem

Prefered Cities to Live!

In this problem you will calculate the number of people who live in a zip code in the US where the city starts with one of the following characthers:

B, D, O, G, N or M .
We will take these are the prefered cities to live in (chosen by this instructor, given is special affection to this set of characters!).

You will be using the zip code collection data set, which you will find in the 'handouts' link in this page.

Import it into your mongod using the following command from the command line:
```
mongoimport --drop -d test -c zips zips.json
```
If you imported it correctly, you can go to the test database in the mongo shell and confirm that
```sh
> db.zips.count()
```
yields 29353 documents.

The $project stage can extract the first character from any field. For example, to extract the first character from the city field, you could write this pipeline:
```
db.zips.aggregate([
    {$project:
     {
    first_char: {$substr : ["$city",0,1]},
     }
   }
])
```
Using the aggregation framework, calculate the sum total of people who are living in a zip code where the city starts with one of those possible first characters. Choose the answer below.

You will need to probably change your projection to send more info through than just that first character. Also, you will need a filtering step to get rid of all documents where the city does not start with the select set of initial characters.
## Solution

```sh
> db.zips.aggregate([ 
	{
		$project: { first_char: {$substr : ["$city",0,1]}, pop: "$pop" }
	}, 
	{
		$group:{ "_id": "$first_char", popSum:{$sum: "$pop"} }
	}, 
	{
		$match:{ "_id" : {$in: ["B", "D", "O", "G", "N", "M"]} }
	}, 
	{
		$group:{ "_id": null, "popSum": {$sum:"$popSum"} }
	}
])
```
## Answer

76394871
