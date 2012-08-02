using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DMongo.Driver
{
	sealed class DBExpando : DynamicObject
	{
		private Dictionary<string, object> collection = new Dictionary<string, object>();
		private MongoDatabase _database;

		public DBExpando(MongoDatabase database)
		{
			this._database = database;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{		   
		    string name = binder.Name.ToLower();
			if(!collection.ContainsKey(name))
				collection.Add(name,new CollectionExpando(this._database.GetCollection(name)));

		    return collection.TryGetValue(name, out result);
		}

	}

	sealed class CollectionExpando : DynamicObject
	{
		private MongoCollection _collection;
		private Dictionary<string, Type> action = new Dictionary<string, Type>();
		private DBAction dbaction = new DBAction();
		public CollectionExpando(MongoCollection collection)
		{
			this._collection = collection;

		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
	    {
			if(!action.ContainsKey(binder.Name.ToLower()))
				action.Add(binder.Name,typeof(DBAction));
			var newargs = new object[] { _collection, args};
			result = action[binder.Name].InvokeMember(binder.Name,System.Reflection.BindingFlags.InvokeMethod,null,dbaction,newargs);
			return true;
	    }
	}

	sealed class DBAction
	{
		public object find(MongoCollection collection,object[] args)
		{
			Type type = args[0].GetType();
			PropertyInfo[] properties = type.GetProperties();
			Dictionary<string,object> dictionary = new Dictionary<string, object>();
			foreach(var property in properties)
				dictionary[property.Name] = property.GetValue(args[0],null);

			var query = new QueryDocument(dictionary);
			var result = collection.FindAs<BsonDocument>(query); 
			return result;
		}

	}
}

