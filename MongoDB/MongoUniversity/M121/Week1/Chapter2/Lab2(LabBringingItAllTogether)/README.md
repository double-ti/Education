# Lab - Bringing it all together

## Problem

Calculate an average rating for each movie in our collection where English is an available language, the minimum imdb.rating is at least 1, the minimum imdb.votes is at least 1, and it was released in 1990 or after. You'll be required to rescale (or normalize) imdb.votes. The formula to rescale imdb.votes and calculate normalized_rating is included as a handout.

What film has the lowest normalized_rating?

## Solution
```sh
> db.movies.aggregate([
    {
        $match: {
            'imdb.votes': {
                $exists: true,
                $ne: ''
            }
        }
    },
    {
        $addFields: {
            scaledVotes: {
                $add: [
                    {
                        $multiply: [
                            {
                                $divide: [
                                    {
                                        $subtract: ['$imdb.votes', 5]
                                    },
                                    {
                                        $subtract: [1521105, 5]
                                    }
                                ]
                            },
                            9
                        ]
                    },
                    1
                ]
            }
        }
    },
    {
        $match: {
            'imdb.rating': {
                $gte: 1
            },
            'imdb.votes': {
                $gte: 1
            },
            year: {
                $gte: 1990
            },
            languages: {
                $in: ['English']
            }
        }
    },
    {
        $project: {
            title: 1,
            'imdb.rating': 1,
            'imdb.votes': 1,
            year: 1,
            languages: 1,
            normalizedRating: {
                $avg: ['$scaledVotes', '$imdb.rating']
            },
            _id: 0
        }
    },
    {
        $sort: {
            normalizedRating: 1
        }
    },
    {
        $limit: 1
    }
])
```
## Answer
The Cristmass Tree