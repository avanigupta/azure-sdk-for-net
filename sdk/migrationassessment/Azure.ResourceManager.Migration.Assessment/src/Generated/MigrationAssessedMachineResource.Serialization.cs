// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class MigrationAssessedMachineResource : IJsonModel<MigrationAssessedMachineData>
    {
        void IJsonModel<MigrationAssessedMachineData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAssessedMachineData>)Data).Write(writer, options);

        MigrationAssessedMachineData IJsonModel<MigrationAssessedMachineData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MigrationAssessedMachineData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<MigrationAssessedMachineData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        MigrationAssessedMachineData IPersistableModel<MigrationAssessedMachineData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MigrationAssessedMachineData>(data, options);

        string IPersistableModel<MigrationAssessedMachineData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MigrationAssessedMachineData>)Data).GetFormatFromOptions(options);
    }
}
