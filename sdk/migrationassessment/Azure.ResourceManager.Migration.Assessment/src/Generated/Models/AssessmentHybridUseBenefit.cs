// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> The AssessmentHybridUseBenefit. </summary>
    public readonly partial struct AssessmentHybridUseBenefit : IEquatable<AssessmentHybridUseBenefit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AssessmentHybridUseBenefit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AssessmentHybridUseBenefit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string YesValue = "Yes";
        private const string NoValue = "No";

        /// <summary> Unknown. </summary>
        public static AssessmentHybridUseBenefit Unknown { get; } = new AssessmentHybridUseBenefit(UnknownValue);
        /// <summary> Yes. </summary>
        public static AssessmentHybridUseBenefit Yes { get; } = new AssessmentHybridUseBenefit(YesValue);
        /// <summary> No. </summary>
        public static AssessmentHybridUseBenefit No { get; } = new AssessmentHybridUseBenefit(NoValue);
        /// <summary> Determines if two <see cref="AssessmentHybridUseBenefit"/> values are the same. </summary>
        public static bool operator ==(AssessmentHybridUseBenefit left, AssessmentHybridUseBenefit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AssessmentHybridUseBenefit"/> values are not the same. </summary>
        public static bool operator !=(AssessmentHybridUseBenefit left, AssessmentHybridUseBenefit right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AssessmentHybridUseBenefit"/>. </summary>
        public static implicit operator AssessmentHybridUseBenefit(string value) => new AssessmentHybridUseBenefit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssessmentHybridUseBenefit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AssessmentHybridUseBenefit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
