using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


namespace DMongo.CSharpDriver
{
	public class CSharpDriverFacade
	{

		private MongoServer _server;
		private MongoDatabase _database;
		private MongoCollection _collection;

		public CSharpDriverFacade (string connectionString, string database, string collectionname)
		{
			this._server = MongoServer.Create(connectionString);
			this._database = this._server.GetDatabase(database);
			this._collection = this._database.GetCollection(collectionname);
		}

		public ObjectId Insert(CSharpDriverModel entity)
		{
			this._collection.Insert(entity);
			return entity.Id;
		}

		public CSharpDriverModel FindById(ObjectId id)
		{
			var query = Query.EQ ("_id",id);
			return this._collection.FindOneAs<CSharpDriverModel>(query);
		}


	}
}

