# DMongo - Dynamic Mongo a wrapper for the CSharp Mongo Driver

This is an wrapper of the CSharpDriver for Mongo, using the Microsoft Dynamic syntax.

The idea behind this implementation is to create a DSL simple to use, more oriented to the Mongo Shell commands.

Examples:

	//Using the CSharpDriver for Mongo
	var connectionString = "mongodb://localhost/?safe=true";
	var server = MongoServer.Create(connectionString);
    var database = server.GetDatabase("test");
    var collection = database.GetCollection<Entity>("entities");
    var entity = new Entity { Name = "Tom" };
    collection.Insert(entity);
    var id = entity.Id;
    var query = Query.EQ("_id", id);
    entity = collection.FindOne(query);
    Console.WriteLine("Result: {0}",entity.Name);

	//Using DMongo
	var mongo = new Mongo("mongo://localhost/?safe=true");
	var db = mongo.GetDatabase("test");	
	var result = db.mycollection.findOne(new { name = "John" });
	

[My Blog](http://felipeg48.blogspot.com)