# Lab - $group and Accumulators

## Problem

In the last lab, we calculated a normalized rating that required us to know what the minimum and maximum values for imdb.votes were. These values were found using the $group stage!

For all films that won at least 1 Oscar, calculate the standard deviation, highest, lowest, and average imdb.rating. Use the sample standard deviation expression.

HINT - All movies in the collection that won an Oscar begin with a string resembling one of the following in their awards field

```
Won 13 Oscars
Won 1 Oscar
```

Select the correct answer from the choices below. Numbers are truncated to 4 decimal places.

## Solution
```sh
> db.movies.aggregate([
	{
        $match: {
            'awards': /Won.\d*.Oscars?/
        }
    },
    {
        $group: {
            _id: null,
            highest_rating: { $max: '$imdb.rating' },
            lowest_rating: { $min: '$imdb.rating' },
            average_rating: { $avg: '$imdb.rating' },
            deviation: { $stdDevSamp: '$imdb.rating' }
        }
    }
])
```
## Answer
{ "highest_rating" : 9.2, "lowest_rating" : 4.5, "average_rating" : 7.5270, "deviation" : 0.5988 }