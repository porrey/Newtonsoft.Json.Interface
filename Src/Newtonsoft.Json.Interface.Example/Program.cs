// ***
// *** Copyright(C) 2014-2024, Daniel M. Porrey. All rights reserved.
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
using System.Collections.Generic;

namespace Newtonsoft.Json.Interface.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			// ***
			// *** Create an array of IMyModel items.
			// ***
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

			// ***
			// *** Serialize the array
			// ***
			string json = JsonConvert.SerializeObject(models);

			// ***
			// *** Deserialize the items as a list of interfaces.
			// ***
			IEnumerable<IMyModel> deserializedItems = JsonConvert.DeserializeObject<IEnumerable<IMyModel>>(json);
		}
	}
}
