# Question 5

## Problem

Suppose we have blog posts in a (not sharded*) postings collection, of the form:
```
{
  _id : ...,
  author : 'joe',
  title : 'Too big to fail',
  text : '...',
  tags : [ 'business', 'finance' ],
  when : ISODate("2008-11-03"),
  views : 23002,
  votes : 4,
  voters : ['joe', 'jane', 'bob', 'somesh'],
  comments : [
    { commenter : 'allan',
      comment : 'Well, i don't think so…',
      flagged : false,
      plus : 2
    },
    ...
  ]
}
```
Which of these statements is true?

Note: to get a multiple answer question right in this final you must get all the components right, so even if some parts are simple, take your time.

*Certain restrictions apply to unique constraints on indexes when sharded, so I mention this to be clear.

1. We can create an index to make the following query fast/faster:  
   db.postings.find( { "comments.flagged" : true } )
2. One way to assure people vote at most once per posting is to use this form of update:  
  db.postings.update(
  \{ _id: . . . \},
  { $inc : {votes:1}, $push : {voters:'joe'} }
);  
combined with an index on { voters : 1 } which has a unique key constraint.
3. One way to assure people vote at most once per posting is to use this form of update:  
  db.postings.update(
  { _id: . . . , voters:{$ne:'joe'} },
  { $inc : {votes:1}, $push : {voters:'joe'} } );


## Answer
1, 3
