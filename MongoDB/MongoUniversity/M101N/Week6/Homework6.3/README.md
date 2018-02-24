# Homework 6.3

## Problem

Which of the following statements are true about choosing and using a shard key?

1. The shard key must be unique
2. There must be a index on the collection that starts with the shard key.
3. MongoDB can not enforce unique indexes on a sharded collection other than the shard key itself, or indexes prefixed by the shard key.
4. Any single update that does not contain the shard key or _id field will result in an error.
5. You can change the shard key on a collection if you desire.

## Answer

2, 3, 4
