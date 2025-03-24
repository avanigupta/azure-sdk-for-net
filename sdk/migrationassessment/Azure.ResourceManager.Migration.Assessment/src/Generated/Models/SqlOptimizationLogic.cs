// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> The SqlOptimizationLogic. </summary>
    public readonly partial struct SqlOptimizationLogic : IEquatable<SqlOptimizationLogic>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SqlOptimizationLogic"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SqlOptimizationLogic(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MinimizeCostValue = "MinimizeCost";
        private const string ModernizeToPaaSValue = "ModernizeToPaaS";
        private const string ModernizeToAzureSqlMIValue = "ModernizeToAzureSqlMi";
        private const string ModernizeToAzureSqlDBValue = "ModernizeToAzureSqlDb";

        /// <summary> MinimizeCost. </summary>
        public static SqlOptimizationLogic MinimizeCost { get; } = new SqlOptimizationLogic(MinimizeCostValue);
        /// <summary> ModernizeToPaaS. </summary>
        public static SqlOptimizationLogic ModernizeToPaaS { get; } = new SqlOptimizationLogic(ModernizeToPaaSValue);
        /// <summary> ModernizeToAzureSqlMi. </summary>
        public static SqlOptimizationLogic ModernizeToAzureSqlMI { get; } = new SqlOptimizationLogic(ModernizeToAzureSqlMIValue);
        /// <summary> ModernizeToAzureSqlDb. </summary>
        public static SqlOptimizationLogic ModernizeToAzureSqlDB { get; } = new SqlOptimizationLogic(ModernizeToAzureSqlDBValue);
        /// <summary> Determines if two <see cref="SqlOptimizationLogic"/> values are the same. </summary>
        public static bool operator ==(SqlOptimizationLogic left, SqlOptimizationLogic right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SqlOptimizationLogic"/> values are not the same. </summary>
        public static bool operator !=(SqlOptimizationLogic left, SqlOptimizationLogic right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SqlOptimizationLogic"/>. </summary>
        public static implicit operator SqlOptimizationLogic(string value) => new SqlOptimizationLogic(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SqlOptimizationLogic other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SqlOptimizationLogic other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
