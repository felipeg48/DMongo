using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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

			var result = db.test.find(query);
			Assert.AreEqual(1,result.Count);
			Assert.AreEqual(query.name,result[0].name);
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
	}
}

