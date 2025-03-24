// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> Assessment Status. </summary>
    public readonly partial struct MigrationAssessmentStatus : IEquatable<MigrationAssessmentStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MigrationAssessmentStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MigrationAssessmentStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CreatedValue = "Created";
        private const string UpdatedValue = "Updated";
        private const string RunningValue = "Running";
        private const string CompletedValue = "Completed";
        private const string InvalidValue = "Invalid";
        private const string OutOfSyncValue = "OutOfSync";
        private const string OutDatedValue = "OutDated";
        private const string DeletedValue = "Deleted";

        /// <summary> Assessment is Created. </summary>
        public static MigrationAssessmentStatus Created { get; } = new MigrationAssessmentStatus(CreatedValue);
        /// <summary> Assessment is Updated. </summary>
        public static MigrationAssessmentStatus Updated { get; } = new MigrationAssessmentStatus(UpdatedValue);
        /// <summary> Assessment is currently running. </summary>
        public static MigrationAssessmentStatus Running { get; } = new MigrationAssessmentStatus(RunningValue);
        /// <summary> Assessment is Completed or Ready. </summary>
        public static MigrationAssessmentStatus Completed { get; } = new MigrationAssessmentStatus(CompletedValue);
        /// <summary> Assessment is Failed i.e. it is now invalid. </summary>
        public static MigrationAssessmentStatus Invalid { get; } = new MigrationAssessmentStatus(InvalidValue);
        /// <summary> Assessment is Out of Sync. </summary>
        public static MigrationAssessmentStatus OutOfSync { get; } = new MigrationAssessmentStatus(OutOfSyncValue);
        /// <summary> Assessment is Out Dated. </summary>
        public static MigrationAssessmentStatus OutDated { get; } = new MigrationAssessmentStatus(OutDatedValue);
        /// <summary> Assessment is Deleted. </summary>
        public static MigrationAssessmentStatus Deleted { get; } = new MigrationAssessmentStatus(DeletedValue);
        /// <summary> Determines if two <see cref="MigrationAssessmentStatus"/> values are the same. </summary>
        public static bool operator ==(MigrationAssessmentStatus left, MigrationAssessmentStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MigrationAssessmentStatus"/> values are not the same. </summary>
        public static bool operator !=(MigrationAssessmentStatus left, MigrationAssessmentStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MigrationAssessmentStatus"/>. </summary>
        public static implicit operator MigrationAssessmentStatus(string value) => new MigrationAssessmentStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MigrationAssessmentStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MigrationAssessmentStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
