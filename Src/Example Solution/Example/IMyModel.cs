using Newtonsoft.Json;

namespace Example
{
	/// Specifies that the an object serialized as IUser should be
	/// deserialized into an instance of User.
	/// </summary>
	[JsonConverter(typeof(InterfaceToConcreteConverter<IMyModel, MyModel>))]
	public interface IMyModel
	{
		string Description { get; set; }
		int Id { get; set; }
		string Name { get; set; }
	}
}