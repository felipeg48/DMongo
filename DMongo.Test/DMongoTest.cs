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
		[SetUp]
		public void Init()
		{

		}

		[Test]
		[Ignore("Test Ignored: Was just a sample test.")]
		public void CSharpDriverTest()
		{
			CSharpDriverFacade facade = new CSharpDriverFacade("mongodb://localhost/?safe=true","dmongo","test");
			Assert.IsNotNull(facade);

			CSharpDriverModel model = new CSharpDriverModel() { Name = "Felipe" };
			Assert.IsNotNull(model);

			var id = facade.Insert(model);
			Assert.IsNotNull(id);

			var result = facade.FindById(id);
			Assert.IsNotNull(result);
			Assert.AreEqual(result.Name,model.Name);

		}

		[Test]
		public void DMongoGetDBTest()
		{
			Mongo mongo = new Mongo("mongodb://localhost/?safe=true");
			dynamic db = mongo.GetDatabase("dmongo");
			var result = db.test.find( new { name = "felipe" });
			foreach(var row in result)
				Console.WriteLine(row["name"]);
		}

		[Test]
		public void DMongoInsertTest()
		{

		}


	}
}

