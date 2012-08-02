using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DMongo.Driver
{
	public class Mongo
	{
		private string _connectionUrl;
		public Mongo (string connectionUrl)
		{
			this._connectionUrl = connectionUrl;
		}

		public dynamic GetDatabase(string database)
		{
			return new DBExpando(MongoServer.Create(this._connectionUrl).GetDatabase(database));
		}
	}
}

