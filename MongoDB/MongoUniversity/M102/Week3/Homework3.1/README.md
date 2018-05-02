# Homework 3.1

## Problem

Start a mongod server instance (if you still have a replica set, that would work too).

Next, download the handout and run:

```
mongo --shell localhost/performance performance.js
homework.init()
```
Build an index on the "active" and "tstamp" fields. You can verify that you've done your job with
```
db.sensor_readings.getIndexes()
```
When you are done, run:
```
homework.a()
```
and enter the numeric result below (no spaces).

Note: if you would like to try different indexes, you can use db.sensor_readings.dropIndexes() to drop your old index before creating a new one. (For this problem you will only need one index beyond the _id index which is present by default.)

## Solution
```sh
> mongo --shell localhost/performance performance.js
> homework.init()
> db.sensor_readings.createIndex({"active": 1, "tstamp": 1})
> homework.a()
```
## Answer
```
6
```