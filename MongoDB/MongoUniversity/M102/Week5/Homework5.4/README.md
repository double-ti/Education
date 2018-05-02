# Homework 5.4

## Problem

Consider the following scenario: You have a two member replica set, a primary, and a secondary.

The data center with the primary goes down, and is expected to remain down for the foreseeable future. Your secondary is now the only copy of your data, and it is not accepting writes. You want to reconfigure your replica set config to exclude the primary, and allow your secondary to be elected, but you run into trouble. Find out the optional parameter that you'll need, and input it into the box below for your rs.reconfig(new_cfg, OPTIONAL PARAMETER).

Hint: You may want to use this [documentation page](https://docs.mongodb.com/manual/tutorial/reconfigure-replica-set-with-unavailable-members/?_ga=2.85309017.1358190295.1525173435-63979293.1516532029) to solve this problem.

Your answer should be of the form { key : value } (including brackets). Do not include the rs.reconfig portion of the query, just the options document.

## Answer

```
{ force: true }
```