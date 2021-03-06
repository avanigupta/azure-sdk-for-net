// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DeviceProvisioningServices.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Description of the shared access key.
    /// </summary>
    public partial class SharedAccessSignatureAuthorizationRuleAccessRightsDescription
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SharedAccessSignatureAuthorizationRuleAccessRightsDescription
        /// class.
        /// </summary>
        public SharedAccessSignatureAuthorizationRuleAccessRightsDescription()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SharedAccessSignatureAuthorizationRuleAccessRightsDescription
        /// class.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="rights">Rights that this key has. Possible values
        /// include: 'ServiceConfig', 'EnrollmentRead', 'EnrollmentWrite',
        /// 'DeviceConnect', 'RegistrationStatusRead',
        /// 'RegistrationStatusWrite'</param>
        /// <param name="primaryKey">Primary SAS key value.</param>
        /// <param name="secondaryKey">Secondary SAS key value.</param>
        public SharedAccessSignatureAuthorizationRuleAccessRightsDescription(string keyName, string rights, string primaryKey = default(string), string secondaryKey = default(string))
        {
            KeyName = keyName;
            PrimaryKey = primaryKey;
            SecondaryKey = secondaryKey;
            Rights = rights;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of the key.
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets primary SAS key value.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets secondary SAS key value.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// Gets or sets rights that this key has. Possible values include:
        /// 'ServiceConfig', 'EnrollmentRead', 'EnrollmentWrite',
        /// 'DeviceConnect', 'RegistrationStatusRead',
        /// 'RegistrationStatusWrite'
        /// </summary>
        [JsonProperty(PropertyName = "rights")]
        public string Rights { get; set; }

    }
}
