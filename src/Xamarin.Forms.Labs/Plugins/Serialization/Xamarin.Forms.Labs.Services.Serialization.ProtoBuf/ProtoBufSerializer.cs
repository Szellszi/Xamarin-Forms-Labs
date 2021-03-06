﻿using System.Diagnostics.CodeAnalysis;
using ProtoBuf;

namespace Xamarin.Forms.Labs.Services.Serialization.ProtoBuf
{
    /// <summary>
    /// The protobuf serializer.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class ProtoBufSerializer : StreamSerializer, IProtoBufSerializer
    {
        /// <summary>
        /// Gets the serialization format.
        /// </summary>
        /// <value>Serialization format.</value>
        public override SerializationFormat Format
        {
            get { return SerializationFormat.ProtoBuffer; }
        }

        /// <summary>
        /// Cleans memory.
        /// </summary>
        public override void Flush()
        {
            Serializer.FlushPool();
        }

        /// <summary>
        /// Serializes object to a stream.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="stream">Stream to serialize to.</param>
        public override void Serialize<T>(T obj, System.IO.Stream stream)
        {
            Serializer.Serialize(stream, obj);
        }

        /// <summary>
        /// Deserializes stream into an object.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize to.</typeparam>
        /// <param name="stream">Stream to deserialize from.</param>
        /// <returns>Object of type T.</returns>
        public override T Deserialize<T>(System.IO.Stream stream)
        {
            return Serializer.Deserialize<T>(stream);
        }
    }
}
