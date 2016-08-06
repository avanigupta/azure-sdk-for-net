// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.KeyVault.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
    /// </summary>
    public partial class JsonWebKey
    {
        /// <summary>
        /// Initializes a new instance of the JsonWebKey class.
        /// </summary>
        public JsonWebKey() { }

        /// <summary>
        /// Initializes a new instance of the JsonWebKey class.
        /// </summary>
        /// <param name="kid">Key Identifier</param>
        /// <param name="kty">Key type, usually RSA. Possible values include:
        /// 'EC', 'RSA', 'RSA-HSM', 'oct'</param>
        /// <param name="n">RSA modulus</param>
        /// <param name="e">RSA public exponent</param>
        /// <param name="d">RSA private exponent</param>
        /// <param name="dP">RSA Private Key Parameter</param>
        /// <param name="dQ">RSA Private Key Parameter</param>
        /// <param name="qI">RSA Private Key Parameter</param>
        /// <param name="p">RSA secret prime</param>
        /// <param name="q">RSA secret prime, with p < q</param>
        /// <param name="k">Symmetric key</param>
        /// <param name="t">HSM Token, used with Bring Your Own Key</param>
        public JsonWebKey(string kid = default(string), string kty = default(string), IList<string> keyOps = default(IList<string>), byte[] n = default(byte[]), byte[] e = default(byte[]), byte[] d = default(byte[]), byte[] dp = default(byte[]), byte[] dq = default(byte[]), byte[] qi = default(byte[]), byte[] p = default(byte[]), byte[] q = default(byte[]), byte[] k = default(byte[]), byte[] t = default(byte[]))
        {
            Kid = kid;
            Kty = kty;
            KeyOps = keyOps;
            N = n;
            E = e;
            D = d;
            DP = dp;
            DQ = dq;
            QI = qi;
            P = p;
            Q = q;
            K = k;
            T = t;
        }

        /// <summary>
        /// Gets or sets key Identifier
        /// </summary>
        [JsonProperty(PropertyName = "kid")]
        public string Kid { get; set; }

        /// <summary>
        /// Gets or sets key type, usually RSA. Possible values include: 'EC',
        /// 'RSA', 'RSA-HSM', 'oct'
        /// </summary>
        [JsonProperty(PropertyName = "kty")]
        public string Kty { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key_ops")]
        public IList<string> KeyOps { get; set; }

        /// <summary>
        /// Gets or sets RSA modulus
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "n")]
        public byte[] N { get; set; }

        /// <summary>
        /// Gets or sets RSA public exponent
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "e")]
        public byte[] E { get; set; }

        /// <summary>
        /// Gets or sets RSA private exponent
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "d")]
        public byte[] D { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "dp")]
        public byte[] DP { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "dq")]
        public byte[] DQ { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "qi")]
        public byte[] QI { get; set; }

        /// <summary>
        /// Gets or sets RSA secret prime
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "p")]
        public byte[] P { get; set; }

        /// <summary>
        /// Gets or sets RSA secret prime, with p &lt; q
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "q")]
        public byte[] Q { get; set; }

        /// <summary>
        /// Gets or sets symmetric key
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "K")]
        public byte[] K { get; set; }

        /// <summary>
        /// Gets or sets HSM Token, used with Bring Your Own Key
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "key_hsm")]
        public byte[] T { get; set; }

    }
}
