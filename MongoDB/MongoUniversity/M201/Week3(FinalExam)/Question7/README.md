# Question 7

## Problem

Given the following indexes:

{ categories: 1, price: 1 }
{ in_stock: 1, price: 1, name: 1 }
The following documents:

{ price: 2.99, name: "Soap", in_stock: true, categories: ['Beauty', 'Personal Care'] }
{ price: 7.99, name: "Knife", in_stock: false, categories: ['Outdoors'] }
And the following queries:

db.products.find({ in_stock: true, price: { $gt: 1, $lt: 5 } }).sort({ name: 1 })
db.products.find({ in_stock: true })
db.products.find({ categories: 'Beauty' }).sort({ price: 1 })

Which of the following is/are true?

1. There would be a total of 4 index keys created across all of these documents and indexes.
2. Index #2 can be used by both query #1 and #2.
3. Index #1 would provide a sort to query #3.
4. Index #2 properly uses the equality, sort, range rule for query #1.

## Answer
2, 3