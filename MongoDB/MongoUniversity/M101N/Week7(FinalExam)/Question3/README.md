# Question 3

## Problem

In this problem you will update a document in the Enron dataset to illustrate your mastery of updating documents from the shell.

The command for mongorestore is:
```
mongorestore --port <port number> -d enron -c messages <path to BSON file>
```
This will put the documents into the "enron.messages" namespace.

Please add the email address "mrpotatohead@mongodb.com" to the list of addresses in the "headers.To" array for the document with "headers.Message-ID" of "<8147308.1075851042335.JavaMail.evans@thyme>"

After you have completed that task, please download final3-validate-mongo-shell.js from the Download Handout link and run
```
mongo final3-validate-mongo-shell.js
```
to get the validation code and put it in the box below without any extra spaces. The validation script assumes that it is connecting to a simple mongo instance on the standard port on localhost.

Note: The validation script will look for the document in the "enron.messages" namespace. If the documents aren't there, then the validation will not work.

## Solution
```sh
> db.messages.findAndModify({
    query: { "headers.Message-ID":"<8147308.1075851042335.JavaMail.evans@thyme>" },
    update: { $push: { "headers.To": "mrpotatohead@mongodb.com" } }
})
```
## Answer
After starting the validation file, I got this message:
"Welcome to the Final Exam Q3 Checker. My job is to make sure you correctly updated the document
Final Exam Q3 Validated successfully!
Your validation code is: vOnRg05kwcqyEFSve96R"
