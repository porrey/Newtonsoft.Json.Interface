namespace Newtonsoft.Json.Interface.Tests
{
	/// <summary>
	/// Specifies that the an object serialized as ITestModel should be
	/// deserialized into an instance of TestModel.
	/// </summary>
	[JsonConverter(typeof(InterfaceToConcreteConverter<ITestModel, TestModel>))]
	public interface ITestModel
	{
		int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
	}
}