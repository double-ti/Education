# Homework 5.2

## Problem

Crunching the Zipcode dataset
Please calculate the average population of cities in California (abbreviation CA) and New York (NY) (taken together) with populations over 25,000.
For this problem, assume that a city name that appears in more than one state represents two separate cities.
Please round the answer to a whole number.
Hint: The answer for CT and NJ (using this data set) is 38177.
Please note:
* Different states might have the same city name.
* A city might have multiple zip codes.

For this problem, we have used a subset of the data you previously used in zips.json, not the full set. For this set, there are only 200 documents (and 200 zip codes), and all of them are in New York, Connecticut, New Jersey, and California.
You can download the handout and perform your analysis on your machine with
```
mongoimport --drop -d test -c zips small_zips.json
```
Note

This is raw data from the United States Postal Service. If you notice that while importing, there are a few duplicates fear not, this is expected and will not affect your answer.


Once you've generated your aggregation query and found your answer, select it from the choices below.
Please use the Aggregation pipeline to solve this problem.
## Solution

```sh
> db.zips.aggregate([
    {
        $match:
        {
            "state": {$in:["NY", "CA"]}
        }
    },
    {
        $group:
        {
            _id:{state:"$state", city:"$city"}, "pop":{"$sum":"$pop"}
        }
    },
    {
        $match: 
		{
			"pop": { $gt:25000 }
		}
    },
    {
        $group: 
		{ 
			_id:null, avg: { $avg:"$pop" } 
		}
    }
])
```
## Answer

44805
