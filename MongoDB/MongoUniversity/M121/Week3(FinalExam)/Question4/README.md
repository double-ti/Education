# Question 4

## Problem

$facet is an aggregation stage that allows for sub-pipelines to be executed.
```
var pipeline = [
  {
    $match: { a: { $type: "integer" } }
  },
  {
    $project: {
      _id: 0,
      a_times_b: { $multiply: ["$a", "$b"] }
    }
  },
  {
    $facet: {
      facet_1: [{ $sortByCount: "a_times_b" }],
      facet_2: [{ $project: { abs_facet1: { $abs: "$facet_1._id" } } }],
      facet_3: [
        {
          $facet: {
            facet_3_1: [{ $bucketAuto: { groupBy: "$_id", buckets: 2 } }]
          }
        }
      ]
    }
  }
]
```
In the above pipeline, which uses $facet, there are some incorrect stages or/and expressions being used.

Which of the following statements point out errors in the pipeline?

1. a $multiply expression takes a document as input, not an array.
2. a $type expression does not take a string as its value; only the BSON numeric values can be specified to identify the types.
3. $sortByCount cannot be used within $facet stage.
4. can not nest a $facet stage as a sub-pipeline.
5. facet_2 uses the output of a parallel sub-pipeline, facet_1, to compute an expression

## Answer
4, 5