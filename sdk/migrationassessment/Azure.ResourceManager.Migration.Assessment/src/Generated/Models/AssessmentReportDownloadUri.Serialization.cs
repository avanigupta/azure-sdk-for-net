// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    public partial class AssessmentReportDownloadUri : IUtf8JsonSerializable, IJsonModel<AssessmentReportDownloadUri>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AssessmentReportDownloadUri>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<AssessmentReportDownloadUri>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentReportDownloadUri>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssessmentReportDownloadUri)} does not support writing '{format}' format.");
            }

            if (options.Format != "W")
            {
                writer.WritePropertyName("assessmentReportUrl"u8);
                writer.WriteStringValue(AssessmentReportUri.AbsoluteUri);
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("expirationTime"u8);
                writer.WriteStringValue(ExpireOn, "O");
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        AssessmentReportDownloadUri IJsonModel<AssessmentReportDownloadUri>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentReportDownloadUri>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssessmentReportDownloadUri)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAssessmentReportDownloadUri(document.RootElement, options);
        }

        internal static AssessmentReportDownloadUri DeserializeAssessmentReportDownloadUri(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri assessmentReportUrl = default;
            DateTimeOffset expirationTime = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("assessmentReportUrl"u8))
                {
                    assessmentReportUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("expirationTime"u8))
                {
                    expirationTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AssessmentReportDownloadUri(assessmentReportUrl, expirationTime, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AssessmentReportDownloadUri>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentReportDownloadUri>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AssessmentReportDownloadUri)} does not support writing '{options.Format}' format.");
            }
        }

        AssessmentReportDownloadUri IPersistableModel<AssessmentReportDownloadUri>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssessmentReportDownloadUri>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeAssessmentReportDownloadUri(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AssessmentReportDownloadUri)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AssessmentReportDownloadUri>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
