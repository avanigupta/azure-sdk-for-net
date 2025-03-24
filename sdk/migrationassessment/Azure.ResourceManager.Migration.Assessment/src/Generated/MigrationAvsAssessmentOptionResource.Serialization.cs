// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class MigrationAvsAssessmentOptionResource : IJsonModel<MigrationAvsAssessmentOptionData>
    {
        void IJsonModel<MigrationAvsAssessmentOptionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAvsAssessmentOptionData>)Data).Write(writer, options);

        MigrationAvsAssessmentOptionData IJsonModel<MigrationAvsAssessmentOptionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAvsAssessmentOptionData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<MigrationAvsAssessmentOptionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        MigrationAvsAssessmentOptionData IPersistableModel<MigrationAvsAssessmentOptionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MigrationAvsAssessmentOptionData>(data, options);

        string IPersistableModel<MigrationAvsAssessmentOptionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MigrationAvsAssessmentOptionData>)Data).GetFormatFromOptions(options);
    }
}
