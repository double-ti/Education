# Question 10

## Problem

Now, for our temporary data mart, once again from a mongo shell connected to the cluster:


1) create an index { N2 : 1, mutant : 1 } for the "snps.elegans" collection.
2) now run:
```
db.elegans.find( { N2 : "T", mutant : "A" } ).limit( 5 ).explain( "executionStats" )
```
Based on the explain output, which of the following statements below are true?

1. No shards are queried.
2. 1 shard in total is queried.
3. 2 shards in total are queried.
4. 5 documents in total are examined.
5. 7 documents in total are examined.
6. 8 documents in total are examined.
7. Thousands of documents are examined.

## Answer
3, 6