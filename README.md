# DMongo - Dynamic Mongo a wrapper for the CSharp Mongo Driver

This is an wrapper of the CSharpDriver for Mongo, using the Microsoft Dynamic syntax.

The idea behind this implementation is to create a DSL simple to use, more oriented to the Mongo Shell commands.

##Using the CSharpDriver for Mongo

* Code:

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


##Using DMongo

*Code:
		
	```csharp
	//Instance
	var mongo = new Mongo("mongo://localhost/?safe=true");
	var db = mongo.GetDatabase("test");	
	
	//Actions
	var entity = db.mycollection.insert(new {name = "John" });
	var result = db.mycollection.findOne(new { name = "John" });
	Console.WriteLine("Result: {0}", result.name);
	```



[My Blog](http://felipeg48.blogspot.com)