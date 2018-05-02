# Homework 3.3

## Problem

Download and extract the json file in products.zip

Then perform the following in the terminal (or at the command prompt):

```
mongoimport --drop -d pcat -c products products.json
```
If that looks somewhat familiar, that's because it's (nearly) the same command you used to import the pcat.products collection for Homework 2.1, with the only difference in the command being that it will drop the collection if it's already present. This version of the collection, however, contains the state of the collection as it would exist once you've solved all of the homework of chapter 2.

Next, go into the pcat database.
```
mongo pcat
```
Create an index on the products collection for the field, "for".

After creating the index, do a find() for products that work with an "ac3" phone ("ac3" is present in the "for" field).

* Q1: How many products match this query?
* Q2: Run the same query, but this time do an explain(). How many documents were examined?
* Q3: Does the explain() output indicate that an index was used?

## Solution
```sh
> db.products.explane.find({for: "ac3"}).count()
> db.products.find({for: "ac3"}).explain("executionStats")
```

## Answer

Q1: 4  
Q2: 4  
Q3: Yes
