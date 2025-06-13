﻿// ***
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
namespace Newtonsoft.Json.Interface.Example
{
	/// <summary>
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