# Lab $graphLookup

## Problem

Now that you have been introduced to $graphLookup, let's use it to solve an interesting need. You are working for a travel agency and would like to find routes for a client! For this exercise, we'll be using the air_airlines, air_alliances, and air_routes collections in the aggregations database.

* The air_airlines collection will use the following schema:
```
{
    "_id" : ObjectId("56e9b497732b6122f8790280"),
    "airline" : 4,
    "name" : "2 Sqn No 1 Elementary Flying Training School",
    "alias" : "",
    "iata" : "WYT",
    "icao" : "",
    "active" : "N",
    "country" : "United Kingdom",
    "base" : "HGH"
}
```
* The air_routes collection will use this schema:
```
{
    "_id" : ObjectId("56e9b39b732b6122f877fa31"),
    "airline" : {
            "id" : 410,
            "name" : "Aerocondor",
            "alias" : "2B",
            "iata" : "ARD"
    },
    "src_airport" : "CEK",
    "dst_airport" : "KZN",
    "codeshare" : "",
    "stops" : 0,
    "airplane" : "CR2"
}
```
* Finally, the air_alliances collection will show the airlines that are in each alliance, with this schema:
```
{
    "_id" : ObjectId("581288b9f374076da2e36fe5"),
    "name" : "Star Alliance",
    "airlines" : [
            "Air Canada",
            "Adria Airways",
            "Avianca",
            "Scandinavian Airlines",
            "All Nippon Airways",
            "Brussels Airlines",
            "Shenzhen Airlines",
            "Air China",
            "Air New Zealand",
            "Asiana Airlines",
            "Brussels Airlines",
            "Copa Airlines",
            "Croatia Airlines",
            "EgyptAir",
            "TAP Portugal",
            "United Airlines",
            "Turkish Airlines",
            "Swiss International Air Lines",
            "Lufthansa",
            "EVA Air",
            "South African Airways",
            "Singapore Airlines"
    ]
}
```
Determine the approach that satisfies the following question in the most efficient manner:

Find the list of all possible distinct destinations, with at most one layover, departing from the base airports of airlines that make part of the "OneWorld" alliance. The airlines should be national carriers from Germany, Spain or Canada only. Include both the destination and which airline services that location. As a small hint, you should find 158 destinations.
Select the correct pipeline.

## Answer
```
db.air_alliances.aggregate([{
  $match: { name: "OneWorld" }
}, {
  $graphLookup: {
    startWith: "$airlines",
    from: "air_airlines",
    connectFromField: "name",
    connectToField: "name",
    as: "airlines",
    maxDepth: 0,
    restrictSearchWithMatch: {
      country: { $in: ["Germany", "Spain", "Canada"] }
    }
  }
}, {
  $graphLookup: {
    startWith: "$airlines.base",
    from: "air_routes",
    connectFromField: "dst_airport",
    connectToField: "src_airport",
    as: "connections",
    maxDepth: 1
  }
}, {
  $project: {
    validAirlines: "$airlines.name",
    "connections.dst_airport": 1,
    "connections.airline.name": 1
  }
},
{ $unwind: "$connections" },
{
  $project: {
    isValid: { $in: ["$connections.airline.name", "$validAirlines"] },
    "connections.dst_airport": 1
  }
},
{ $match: { isValid: true } },
{ $group: { _id: "$connections.dst_airport" } }
])
```