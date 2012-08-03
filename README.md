# DMongo - Dynamic wrapper for the CSharp Mongo Driver

This is an wrapper of the CSharpDriver for Mongo, using the Microsoft Dynamic syntax.

The idea behind this implementation is to create a DSL simple to use, more oriented to the Mongo Shell commands.

* Using the CSharpDriver for Mongo

	```csharp
	//Connection
	var connectionString = "mongodb://localhost/?safe=true";
	var server = MongoServer.Create(connectionString);
    var database = server.GetDatabase("test");
    var collection = database.GetCollection<Entity>("mycollection");
    
    //Insert:
    var entity = new Entity { Name = "Tom" };
    collection.Insert(entity);
    var id = entity.Id;
    
    //Query:
    var query = Query.EQ("_id", id);
    entity = collection.FindOne(query);
    Console.WriteLine("Result: {0}",entity.Name);
    ```

This example was taken from: [CSharp Driver Quick Start](http://www.mongodb.org/display/DOCS/CSharp+Driver+Quickstart)
There is a Test case based on the example above. 

* Using DMongo: A simple way to use the collections (like the mongo shell)
		
	```csharp
	//Instance
	var mongo = new Mongo("mongo://localhost/?safe=true");
	var db = mongo.GetDatabase("test");	
	
	//Actions
	var entity = db.mycollection.insert(new {name = "John" });
	var result = db.mycollection.findOne(new { name = "John" });
	Console.WriteLine("Result: {0}", result.name);
	```

### Features:

1. Dynamic Collections (work in progress)
2. Data Types (work in progress). Note: For now only annonymous types are accepted.
3. DB Actions - Update, Insert, Delete (work in progress)
4. DB Query - all Finders and Linq (not done)
5. Extra functionallity from the CSharp Driver (not done)
6. Multithread - (not done)
7. More and more...


### Notes:

This project is being develop on Mono for Mac using the CSharpDriver Libraries, NUnit and Mono implementation of the C# language.
I haven't tested it yet on a windows environment, but this inital commit should work.
I used the .NET Framework 4.0

[My Blog](http://felipeg48.blogspot.com)
