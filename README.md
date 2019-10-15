# Newtonsoft.Json.Interface
The Json.NET Interface Converter/Mapper is a JsonConverter attribute that allows interfaces to be mapped to concrete implementations of those interfaces for use when deserializing an object.

## Using the atrribute
Place the attribute over the interface definition and specify the class to be used
for deserialiszation.

```/// <summary>
/// Specifies that the an object serialized as IUser should be
/// deserialized into an instance of User.
/// </summary>
[JsonConverter(typeof(InterfaceToConcreteConverter<IUser, User>))]
public interface IUser : IUser<string>
{
