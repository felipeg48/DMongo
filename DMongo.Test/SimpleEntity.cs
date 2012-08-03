using System;
using MongoDB.Bson;

namespace DMongo.Test
{
	/// <summary>
	/// Simple entity.
	/// </summary>
	public class SimpleEntity
	{
		public ObjectId Id { get; set; }
        public string Name { get; set; }
	}
}

