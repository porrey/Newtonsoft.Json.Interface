![.NET Core Build/Test](https://github.com/porrey/Newtonsoft.Json.Interface/workflows/.NET%20Core%20Build/Test/badge.svg) ![NuGet Publish](https://github.com/porrey/Newtonsoft.Json.Interface/workflows/NuGet%20Publish/badge.svg)

![Travis (.com) branch](https://img.shields.io/travis/com/porrey/Newtonsoft.Json.Interface/master?label=Travis%20CI%20Build)

[![Nuget](https://img.shields.io/nuget/v/Newtonsoft.Json.Interface?label=Newtonsoft%2EJson.Interface%20-%20NuGet)
![Nuget](https://img.shields.io/nuget/dt/Newtonsoft.Json.Interface?label=Downloads)](https://www.nuget.org/packages/Newtonsoft.Json.Interface/)

# Newtonsoft.Json.Interface
The Json.NET Interface Converter/Mapper is a JsonConverter attribute that allows interfaces to be mapped to concrete implementations of those interfaces for use when deserializing an object.

This is useful when retrieving objects from a container that does not have access to the concrete implementation, but those objects need to be serialized and deserialized using he interface.

## Using the attribute
Place the attribute over the interface definition and specify the class to be used
for deserialization.

## Basic Usage

### Model Conversion

Place an attribute over the interface to define the concrete class to use when deserializing objects with the given interface.

	/// <summary>
	/// Specifies that the an object serialized as IUser should be
	/// deserialized into an instance of User.
	/// </summary>
	[JsonConverter(typeof(InterfaceToConcreteConverter<IUser, User>))]
	public interface IUser : IUser<string>
	{

### Model Property Conversion

Place an  attribute over a model property that uses an interface as the type as shown below.

    public class TestPropertyModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
    
        [JsonConverter(typeof(ConcreteConverter<TestModel>))]
        public ITestModel Model { get; set; }
    }

## Example

### Model Conversion

This example shows how to use the attribute on an interface to direct deserialization to a specific model or entity.

Define an interface as shown below.

	public interface IMyModel
	{
		string Description { get; set; }
		int Id { get; set; }
		string Name { get; set; }
	}

Create a concrete implementation for the interface.

	public class MyModel : IMyModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

Create an array of objects using the interface and then serialize the array to a JSON string.

	IMyModel[] models = new MyModel[]
	{
		new MyModel()
		{
			Id = 1,
			Name = "Model 1",
			Description = "My new model 1."
		},
		new MyModel()
		{
			Id = 2,
			Name = "Model 2",
			Description = "My new model 2."
		},
		new MyModel()
		{
			Id = 3,
			Name = "Model 3",
			Description = "My new model 3."
		},
	};
	
	string json = JsonConvert.SerializeObject(models);

An attempt to deserialize the above array without the attribute would result in the error shown below.

![](https://github.com/porrey/Newtonsoft.Json.Interface/raw/master/Images/ScreenShot.png)

Now go back and add the attribute to the interface definition.

	[JsonConverter(typeof(InterfaceToConcreteConverter<IMyModel, MyModel>))]
	public interface IMyModel
	{
		string Description { get; set; }
		int Id { get; set; }
		string Name { get; set; }
	}

With the attribute on the the interface, the below code would run perfectly. Note that the interface is used in the call to **JsonConvert.DeserializeObject** and not the concrete class reference.

	// ***
	// *** Deserialize the items as a list of interfaces.
	// ***
	IEnumerable<IMyModel> deserializedItems = JsonConvert.DeserializeObject<IEnumerable<IMyModel>>(json);
