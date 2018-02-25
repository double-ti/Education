# Optional Lab - Expressions with $project

## Problem

Let's find how many movies in our movies collection are a "labor of love", where the same person appears in cast, directors, and writers

To get a count after you have defined your pipeline, there are two simple methods.
```
// add the $count stage to the end of your pipeline
// you will learn about this stage shortly!
db.movies.aggregate([
  {$stage1},
  {$stage2},
  ...$stageN,
  { $count: "labors of love" }
])

// or use itcount()
db.movies.aggregate([
  {$stage1},
  {$stage2},
  {...$stageN},
]).itcount()
```
How many movies are "labors of love"?

## Solution
```sh
> db.movies.aggregate([{
			$match: {
				cast: {
					$elemMatch: {
						$exists: true
					}
				},
				directors: {
					$elemMatch: {
						$exists: true
					}
				},
				writers: {
					$elemMatch: {
						$exists: true
					}
				}
			}
		}, {
			$project: {
				_id: 0,
				cast: 1,
				directors: 1,
				writers: {
					$map: {
						input: "$writers",
						as: "writer",
						in: {
							$arrayElemAt: [{
									$split: ["$$writer", " ("]
								}, 0]
						}
					}
				}
			}
		}, {
			$project: {
				laborOfLove: {
					$gt: [{
							$size: {
								$setIntersection: ["$cast", "$directors", "$writers"]
							}
						}, 0]
				}
			}
		}, {
			$match: {
				laborOfLove: true
			}
		}, {
			$count: "labors of love"
		}
	])
```
## Answer
1597