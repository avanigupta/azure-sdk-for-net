// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class MigrationSqlAssessmentOptionResource : IJsonModel<MigrationSqlAssessmentOptionData>
    {
        void IJsonModel<MigrationSqlAssessmentOptionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MigrationSqlAssessmentOptionData>)Data).Write(writer, options);

        MigrationSqlAssessmentOptionData IJsonModel<MigrationSqlAssessmentOptionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MigrationSqlAssessmentOptionData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<MigrationSqlAssessmentOptionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        MigrationSqlAssessmentOptionData IPersistableModel<MigrationSqlAssessmentOptionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MigrationSqlAssessmentOptionData>(data, options);

        string IPersistableModel<MigrationSqlAssessmentOptionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MigrationSqlAssessmentOptionData>)Data).GetFormatFromOptions(options);
    }
}
