# IDocumentDatabase

Interface + Implementation (with MongoDB) for Document Databases. This is a basic interface that _should_ apply to all NoSQL Document Databases. Your classes may inherit from `IDocumentDatabase`. 

## Implementation

This interface uses generics `<db, col>` that must be implemented by you.

`string ToConnectionString();`: Returns a valid connection string for your document database.
`db Database(string connectionString);`: Returns a valid, active database client for your document database.
`col Collection(string collectionName);`: Returns a valid, active collection from your document database.

## Example

A basic MongoDB example has been provided. It may be instantiated like so:

```csharp
var db = new Mongo("somewhere.mongolab.com", "9000", "databasename", "myusername", "supersecretpassword");
return db.Collection("test");
```
