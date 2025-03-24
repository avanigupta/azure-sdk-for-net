// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class MigrationAssessmentPrivateEndpointConnectionResource : IJsonModel<MigrationAssessmentPrivateEndpointConnectionData>
    {
        void IJsonModel<MigrationAssessmentPrivateEndpointConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAssessmentPrivateEndpointConnectionData>)Data).Write(writer, options);

        MigrationAssessmentPrivateEndpointConnectionData IJsonModel<MigrationAssessmentPrivateEndpointConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAssessmentPrivateEndpointConnectionData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<MigrationAssessmentPrivateEndpointConnectionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        MigrationAssessmentPrivateEndpointConnectionData IPersistableModel<MigrationAssessmentPrivateEndpointConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MigrationAssessmentPrivateEndpointConnectionData>(data, options);

        string IPersistableModel<MigrationAssessmentPrivateEndpointConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MigrationAssessmentPrivateEndpointConnectionData>)Data).GetFormatFromOptions(options);
    }
}
