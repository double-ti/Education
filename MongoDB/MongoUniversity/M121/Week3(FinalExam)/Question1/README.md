# Question 1

## Problem

Consider the following aggregation pipelines:

* Pipeline 1
```
db.coll.aggregate([
  {"$match": {"field_a": {"$gt": 1983}}},
  {"$project": { "field_a": "$field_a.1", "field_b": 1, "field_c": 1  }},
  {"$replaceRoot":{"newRoot": {"_id": "$field_c", "field_b": "$field_b"}}},
  {"$out": "coll2"},
  {"$match": {"_id.field_f": {"$gt": 1}}},
  {"$replaceRoot":{"newRoot": {"_id": "$field_b", "field_c": "$_id"}}}
])
```
* Pipeline 2
```
db.coll.aggregate([
  {"$match": {"field_a": {"$gt": 111}}},
  {"$geoNear": {
    "near": { "type": "Point", "coordinates": [ -73.99279 , 40.719296 ] },
    "distanceField": "distance"}},
  {"$project": { "distance": "$distance", "name": 1, "_id": 0  }}
])
```
* Pipeline 3
```
db.coll.aggregate([
  {
    "$facet": {
      "averageCount": [
        {"$unwind": "$array_field"},
        {"$group": {"_id": "$array_field", "count": {"$sum": 1}}}
      ],
      "categorized": [{"$sortByCount": "$arrayField"}]
    },
  },
  {
    "$facet": {
      "new_shape": [{"$project": {"range": "$categorized._id"}}],
      "stats": [{"$match": {"range": 1}}, {"$indexStats": {}}]
    }
  }
])
```
Which of the following statements are correct?

1. Pipeline 3 executes correctly
2. Pipeline 1 fails since $out is required to be the last stage of the pipeline
3. Pipeline 3 fails because $indexStats must be the first stage in a pipeline and may not be used within a $facet
4. Pipeline 2 fails because we cannot project distance field
5. Pipeline 2 is incorrect because $geoNear needs to be the first stage of our pipeline
6. Pipeline 1 is incorrect because you can only have one $replaceRoot stage in your pipeline
7. Pipeline 3 fails since you can only have one $facet stage per pipeline

## Answer

2, 3, 5
