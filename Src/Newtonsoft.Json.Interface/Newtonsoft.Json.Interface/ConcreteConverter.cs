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
using System;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json
{
	/// <summary>
	/// Provides direction to the serializer and deserializer to use
	/// specific concrete class.
	/// </summary>
	/// <typeparam name="TConcrete"></typeparam>
	public class ConcreteConverter<TConcrete> : JsonConverter
		where TConcrete : new()
	{
		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>Returns true if this instance can convert the specified object type, false otherwise.</returns>
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(TConcrete));
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="JsonConverter"/> can read.
		/// </summary>
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="JsonConverter"/> can write
		/// JSON.
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object returnValue = null;

			// ***
			// *** Deserialize the object to a temporary instance
			// ***
			JToken jsonToken = JToken.Load(reader);

			if (jsonToken is JObject || jsonToken is JArray)
			{
				// ***
				// *** Create the concrete type
				// ***
				returnValue = new TConcrete();

				using (JsonReader serializerReader = jsonToken.CreateReader())
				{
					// ***
					// *** Populate the object
					// ***
					serializer.Populate(serializerReader, returnValue);
				}
			}

			return returnValue;
		}

		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// ***
			// *** Use the given serialize to perform serialization.
			// ***
			serializer.Serialize(writer, value);
		}
	}
}
