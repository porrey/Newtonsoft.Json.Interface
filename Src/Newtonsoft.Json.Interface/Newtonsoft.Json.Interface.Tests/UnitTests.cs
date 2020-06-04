using NUnit.Framework;

namespace Newtonsoft.Json.Interface.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test(Author = "Daniel M. Porrey", Description = "Ensures and object implementing an interface is deserialized properly by that interface.")]
		public void ModelConversionTest()
		{
			// ***
			// *** Create the model.
			// ***
			TestModel model1 = new TestModel()
			{
				Id = 1,
				Name = "Model1",
				Description = "Model 1"
			};

			// ***
			// *** Serialize the model.
			// ***
			string json = JsonConvert.SerializeObject(model1);

			// ***
			// *** Serialize the model using the interface.
			// ***
			ITestModel model2 = JsonConvert.DeserializeObject<ITestModel>(json);

			// ***
			// *** Check the model.
			// ***
			Assert.Multiple(() =>
			{
				Assert.AreEqual(1, model2.Id);
				Assert.AreEqual("Model1", model2.Name);
				Assert.AreEqual("Model 1", model2.Description);
			});
		}

		[Test(Author = "Daniel M. Porrey", Description = "Ensures that an object is not deserialized by interface if that object does not implement the interface.")]
		public void DifferentModelConversionTest()
		{
			// ***
			// *** Create the model.
			// ***
			DifferentTestModel model1 = new DifferentTestModel()
			{
				ModelId = 1,
				ModelName = "Model1",
				ModelDescription = "Model 1"
			};

			// ***
			// *** Serialize the model.
			// ***
			string json = JsonConvert.SerializeObject(model1);

			// ***
			// *** Serialize the model using the interface.
			// ***
			ITestModel model2 = JsonConvert.DeserializeObject<ITestModel>(json);

			// ***
			// *** Check the model.
			// ***
			Assert.Multiple(() =>
			{
				Assert.AreEqual(0, model2.Id);
				Assert.IsNull(model2.Name);
				Assert.IsNull(model2.Description);
			});
		}

		[Test(Author = "Daniel M. Porrey", Description = "Ensures and null object implementing an interface is deserialized properly by that interface.")]
		public void NullModelConversionTest()
		{
			// ***
			// *** Create the model.
			// ***
			TestModel model1 = null;

			// ***
			// *** Serialize the model.
			// ***
			string json = JsonConvert.SerializeObject(model1);

			// ***
			// *** Serialize the model using the interface.
			// ***
			ITestModel model2 = JsonConvert.DeserializeObject<ITestModel>(json);

			// ***
			// *** Check the model.
			// ***
			Assert.IsNull(model2);
		}

		[Test(Author = "Daniel M. Porrey", Description = "Ensures that a property of a model with a interface type can be deserialized.")]
		public void PropertyConversionTest()
		{
			// ***
			// *** Create the model.
			// ***
			TestPropertyModel model1 = new TestPropertyModel()
			{
				Id = 11,
				Comment = "This is a test.",
				Model = new TestModel()
				{
					Id = 1,
					Name = "Model1",
					Description = "Model 1"
				}
			};

			// ***
			// *** Serialize the model.
			// ***
			string json = JsonConvert.SerializeObject(model1);

			// ***
			// *** Serialize the model using the interface.
			// ***
			TestPropertyModel model2 = JsonConvert.DeserializeObject<TestPropertyModel>(json);

			// ***
			// *** Check the model.
			// ***
			Assert.Multiple(() =>
			{
				Assert.AreEqual(11, model2.Id);
				Assert.AreEqual("This is a test.", model2.Comment);
				Assert.IsNotNull(model2.Model);
				Assert.AreEqual(1, model2.Model.Id);
				Assert.AreEqual("Model1", model2.Model.Name);
				Assert.AreEqual("Model 1", model2.Model.Description);
			});
		}

		[Test(Author = "Daniel M. Porrey", Description = "Ensures that a property of a model with a interface type can be deserialized from null.")]
		public void PropertyConversionNullTest()
		{
			// ***
			// *** Create the model.
			// ***
			TestPropertyModel model1 = new TestPropertyModel()
			{
				Id = 11,
				Comment = "This is a test.",
				Model = null
			};

			// ***
			// *** Serialize the model.
			// ***
			string json = JsonConvert.SerializeObject(model1);

			// ***
			// *** Serialize the model using the interface.
			// ***
			TestPropertyModel model2 = JsonConvert.DeserializeObject<TestPropertyModel>(json);

			// ***
			// *** Check the model.
			// ***
			Assert.Multiple(() =>
			{
				Assert.AreEqual(11, model2.Id);
				Assert.AreEqual("This is a test.", model2.Comment);
				Assert.IsNull(model2.Model);
			});
		}
	}
}