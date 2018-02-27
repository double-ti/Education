# Question 6

## Problem

Suppose you have a collection of students of the following form:
```
{
    "_id" : ObjectId("50c598f582094fb5f92efb96"),
    "first_name" : "John",
    "last_name" : "Doe",
    "date_of_admission" : ISODate("2010-02-21T05:00:00Z"),
    "residence_hall" : "Fairweather",
    "has_car" : true,
    "student_id" : "2348023902",
    "current_classes" : [
        "His343",
        "Math234",
        "Phy123",
        "Art232"
    ]
}
```
Now suppose that basic inserts into the collection, which only include the last name, first name and student_id, are too slow (we can't do enough of them per second from our program). And while there are many potential application/hardware solutions such as batching, increasing bandwidth (or RAM), etc., which of the following listed options could potentially improve the speed of inserts?

Check all that apply.

1. Add an index on last_name, first_name if one does not already exist.
2. Remove all indexes from the collection, leaving only the index on _id in place
3. Provide a hint to MongoDB that it should not use an index for the inserts
4. Set w=0, j=false on writes
5. Build a replica set and insert data into the secondary nodes to free up the primary nodes.

## Answer
2, 4
