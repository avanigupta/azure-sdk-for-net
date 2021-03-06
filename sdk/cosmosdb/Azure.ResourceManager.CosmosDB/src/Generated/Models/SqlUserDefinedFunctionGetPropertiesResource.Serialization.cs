// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class SqlUserDefinedFunctionGetPropertiesResource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            if (Optional.IsDefined(Body))
            {
                writer.WritePropertyName("body");
                writer.WriteStringValue(Body);
            }
            writer.WriteEndObject();
        }

        internal static SqlUserDefinedFunctionGetPropertiesResource DeserializeSqlUserDefinedFunctionGetPropertiesResource(JsonElement element)
        {
            Optional<string> Rid = default;
            Optional<object> Ts = default;
            Optional<string> Etag = default;
            string id = default;
            Optional<string> body = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("_rid"))
                {
                    Rid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("_ts"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Ts = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("_etag"))
                {
                    Etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("body"))
                {
                    body = property.Value.GetString();
                    continue;
                }
            }
            return new SqlUserDefinedFunctionGetPropertiesResource(id, body.Value, Rid.Value, Ts.Value, Etag.Value);
        }
    }
}
