// ***
// *** Copyright(C) 2014-2025, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
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
				Assert.That(Is.Equals(1, model2.Id));
				Assert.That(Is.Equals("Model1", model2.Name));
				Assert.That(Is.Equals("Model 1", model2.Description));
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
				DifferentId = 1,
				DifferentName = "Model1",
				DifferentDescription = "Model 1"
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
				Assert.That(Is.Equals(0, model2.Id));
				Assert.That(model2.Name, Is.Null);
				Assert.That(model2.Description, Is.Null);
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
			Assert.That(model2, Is.Null);
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
				Assert.That(Is.Equals(11, model2.Id));
				Assert.That(Is.Equals("This is a test.", model2.Comment));
				Assert.That(model2.Model, Is.Not.Null);
				Assert.That(Is.Equals(1, model2.Model.Id));
				Assert.That(Is.Equals("Model1", model2.Model.Name));
				Assert.That(Is.Equals("Model 1", model2.Model.Description));
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
				Assert.That(Is.Equals(11, model2.Id));
				Assert.That(Is.Equals("This is a test.", model2.Comment));
				Assert.That(model2.Model, Is.Null);
			});
		}
	}
}