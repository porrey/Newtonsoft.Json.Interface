using Newtonsoft.Json;

namespace Newtonsoft.Json.Interface.Tests
{
	/// <summary>
	/// Specifies that the an object serialized as IUser should be
	/// deserialized into an instance of User.
	/// </summary>
	public class TestPropertyModel
	{
		public int Id { get; set; }
		public string Comment { get; set; }

		[JsonConverter(typeof(ConcreteConverter<TestModel>))]
		public ITestModel Model { get; set; }
	}
}