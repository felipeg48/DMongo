using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;


using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using DMongo.CSharpDriver;
using DMongo.Driver;

namespace DMongo.Test
{
	[TestFixture]
	public class DMongoTest
	{
		private Mongo mongo = null;
		private dynamic db = null;

		[SetUp]
		public void Init()
		{
			//Step. Get Mongo instance
			mongo = new Mongo("mongodb://localhost/?safe=true");
			Assert.IsNotNull(mongo);

			//Step. Get Database
			db = mongo.GetDatabase("dmongo");
			Assert.IsNotNull(db);
		}

		[Test]
		[Ignore("Test Ignored: Was just a sample test for the CSharpDriver.")]
		public void CSharpDriverTest()
		{
			//Step. Get Facade
			CSharpDriverFacade facade = new CSharpDriverFacade("mongodb://localhost/?safe=true","dmongo","test");
			Assert.IsNotNull(facade);

			//Step. Set up model
			CSharpDriverModel model = new CSharpDriverModel() { Name = "Felipe" };
			Assert.IsNotNull(model);

			//Step. Insert
			var id = facade.Insert(model);
			Assert.IsNotNull(id);

			//Step. Find
			var result = facade.FindById(id);
			Assert.IsNotNull(result);
			Assert.AreEqual(result.Name,model.Name);

		}

		[Test]
		[Ignore]
		public void DMongoGetDBTest()
		{
			//Step. Define Query
			dynamic query = new { name = "felipe" };

			//Step. find
			var result = db.test.find(query);
			Assert.AreEqual(1,result.Count);
			Assert.AreEqual(query.name,result[0].name);

			//Step. findOne
			var resultOne = db.test.findOne(query);
			Assert.IsNotNull(resultOne);
			Assert.AreEqual(query.name,resultOne.name);
		}

		[Test]
		[Ignore]
		public void DMongoInsertTest()
		{
			//Step. Define Data. Annonymous Type
			dynamic data = new { name = "Steve" };

			//Step. Insert
			db.test.insert(data);
			Assert.IsNotNull(data);

			//Step. Define a Simple Entity
			SimpleEntity entity = new SimpleEntity() { Name = "John" };

			//Step. Insert
			db.test.insert(entity);
			Assert.IsNotNull(entity);
			Assert.IsNotNull(entity.Id);
 
		}

		[Test]
		[Ignore]
		public void DMongoRegularMethodFindOneTest()
		{

			//Define the Query Using the CSharp Mongo Driver
			//Change it according any record on the db
			//The record is: { "_id" : ObjectId("501aba616f2206705e07ae49"), "name" : "felipe" }
			var query = Query.EQ("_id", "501aba616f2206705e07ae49");
			Assert.IsNotNull(query);

			//Step. Using the FindOne from CSharp Mongo Driver
			var result = db.test.FindOneAs<BsonDocument>(query);
			Assert.IsNotNull(result);

			//BsonDocument
			Assert.AreEqual(result.GetType(),typeof(BsonDocument));

			//Types
			Assert.AreEqual(result[0].GetType(),typeof(BsonObjectId));
			Assert.AreEqual(result[1].GetType(),typeof(BsonString));

			//Values
			Assert.AreEqual((result[0] as BsonObjectId).AsObjectId.ToString() ,"501aba616f2206705e07ae49");
			Assert.AreEqual(result[1].AsString,"felipe");
 
		}
	}
}

