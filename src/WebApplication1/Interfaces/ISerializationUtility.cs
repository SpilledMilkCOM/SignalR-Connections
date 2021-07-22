using System;
using System.IO;

namespace SM.Serialization {
	/// <summary>
	/// An interface for typical serialization operations.
	/// </summary>
	public interface ISerializationUtility {
		/// <summary>
		/// Deserialize the JSON data to the type given.
		/// </summary>
		/// <typeparam name="TType">Desired object type.</typeparam>
		/// <param name="jsonData">The JSON data.</param>
		/// <returns>Desired type of object from the data.</returns>
		TType Deserialize<TType>(string jsonData);

		/// <summary>
		/// Deserialize the JSON data to the type given.
		/// </summary>
		/// <param name="jsonData">The JSON data.</param>
		/// <param name="type">Desired object type.</param>
		/// <returns>The deserialized object.</returns>
		object Deserialize(string jsonData, Type type);

		/// <summary>
		/// Deserialize the JSON data to the type given.
		/// </summary>
		/// <typeparam name="TType">Desired object type.</typeparam>
		/// <param name="streamReader">The JSON data.</param>
		/// <returns></returns>
		TType Deserialize<TType>(TextReader streamReader);

		/// <summary>
		/// Deserialize the JSON data to the type given.
		/// </summary>
		/// <param name="streamReader">The JSON data.</param>
		/// <param name="type">Desired object type.</param>
		/// <returns>The JSON data.</returns>
		object Deserialize(TextReader streamReader, Type type);

		string Serialize(object obj);

		void Serialize(StreamWriter streamWriter, object obj);
	}
}