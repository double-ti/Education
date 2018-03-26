# Homework 1.4

## Problem

How would you print out, in the shell, just the value in the "name" field, for all the product documents in the collection, without extraneous characters or braces, sorted alphabetically, ascending? (Check all that would apply.)

 1. db.products.find( { }, { name : 1, _id : 0 } ).sort( { name : 1 } )
 2. var c = db.products.find( { }, { name : 1, _id : 0 } ).sort( { name : 1 } );
		while( c.hasNext() ) {
		print( c.next().name);
	}
 3. var c = db.products.find( { } ).sort( { name : 1 } );
	c.forEach( function( doc ) { print( doc.name ) } );
 4. var c = db.products.find( { } ).sort( { name : -1 } );
		while( c.hasNext() ) {
		print( c.next().name);
	}

## Answer
2, 3