# DMongo - Dynamic Mongo Driver

This is an implemention of the CSharpDriver for Mongo, using the Microsoft Dynamic syntax.

The idea behind this implementation is to create a DSL simple to use, more oriented to the Mongo Shell commands.

Examples:
	var mongo = new Mongo("mongo://localhost/?safe=true");
	var db = mongo.GetDatabase("test");
	
	var result = db.mycollection.find(new { name = "John" });


[My Blog](http://felipeg48.blogspot.com)