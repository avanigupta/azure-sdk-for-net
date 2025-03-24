// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> The QuorumWitnessDtoQuorumWitnessType. </summary>
    public readonly partial struct QuorumWitnessDtoQuorumWitnessType : IEquatable<QuorumWitnessDtoQuorumWitnessType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QuorumWitnessDtoQuorumWitnessType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QuorumWitnessDtoQuorumWitnessType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string CloudValue = "Cloud";
        private const string DiskValue = "Disk";

        /// <summary> Unknown. </summary>
        public static QuorumWitnessDtoQuorumWitnessType Unknown { get; } = new QuorumWitnessDtoQuorumWitnessType(UnknownValue);
        /// <summary> Cloud. </summary>
        public static QuorumWitnessDtoQuorumWitnessType Cloud { get; } = new QuorumWitnessDtoQuorumWitnessType(CloudValue);
        /// <summary> Disk. </summary>
        public static QuorumWitnessDtoQuorumWitnessType Disk { get; } = new QuorumWitnessDtoQuorumWitnessType(DiskValue);
        /// <summary> Determines if two <see cref="QuorumWitnessDtoQuorumWitnessType"/> values are the same. </summary>
        public static bool operator ==(QuorumWitnessDtoQuorumWitnessType left, QuorumWitnessDtoQuorumWitnessType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QuorumWitnessDtoQuorumWitnessType"/> values are not the same. </summary>
        public static bool operator !=(QuorumWitnessDtoQuorumWitnessType left, QuorumWitnessDtoQuorumWitnessType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="QuorumWitnessDtoQuorumWitnessType"/>. </summary>
        public static implicit operator QuorumWitnessDtoQuorumWitnessType(string value) => new QuorumWitnessDtoQuorumWitnessType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QuorumWitnessDtoQuorumWitnessType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QuorumWitnessDtoQuorumWitnessType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
