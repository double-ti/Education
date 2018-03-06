# Question 7

## Problem

Using the air_alliances and air_routes collections, find which alliance has the most unique carriers(airlines) operating between the airports JFK and LHR.

Names are distinct, i.e. Delta != Delta Air Lines

src_airport and dst_airport contain the originating and terminating airport information.

## Solution
```sh
> db.air_routes.aggregate([
 {
  $match: {
            $or: [ 
    {$and: [{ src_airport: "JFK" }, { dst_airport : "LHR" }]},
    {$and: [{ dst_airport: "JFK" }, {  src_airport: "LHR" }]}
   ]
        }
 },
 {
  $lookup: {
   "from": "air_alliances",
   "localField": "airline.name",
   "foreignField": "airlines",
   "as": "alliance"
      }
 },
 {
  $match: { "alliance": { $ne: [] } }
 },
    {
        $group: {
            _id: {$arrayElemAt: ["$alliance.name", 0]},
			uniqueAirlines: {$addToSet: "$airline.name"}
        }
    },
 {
  $project: { "count": { $size: "$uniqueAirlines" } }
 },
 {$sort: { "count": -1 }},
 {$limit: 1}
])
```
## Answer
OneWorld, with 4 carriers