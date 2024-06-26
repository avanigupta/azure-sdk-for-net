// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Security.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The Defender for Containers AWS offering
    /// </summary>
    [Newtonsoft.Json.JsonObject("DefenderForContainersAws")]
    public partial class DefenderForContainersAwsOffering : CloudOffering
    {
        /// <summary>
        /// Initializes a new instance of the DefenderForContainersAwsOffering
        /// class.
        /// </summary>
        public DefenderForContainersAwsOffering()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DefenderForContainersAwsOffering
        /// class.
        /// </summary>
        /// <param name="description">The offering description.</param>
        /// <param name="kubernetesService">The kubernetes service connection
        /// configuration</param>
        /// <param name="kubernetesScubaReader">The kubernetes to scuba
        /// connection configuration</param>
        /// <param name="cloudWatchToKinesis">The cloudwatch to kinesis
        /// connection configuration</param>
        /// <param name="kinesisToS3">The kinesis to s3 connection
        /// configuration</param>
        /// <param name="containerVulnerabilityAssessment">The container
        /// vulnerability assessment configuration</param>
        /// <param name="containerVulnerabilityAssessmentTask">The container
        /// vulnerability assessment task configuration</param>
        /// <param name="enableContainerVulnerabilityAssessment">Enable
        /// container vulnerability assessment feature</param>
        /// <param name="autoProvisioning">Is audit logs pipeline auto
        /// provisioning enabled</param>
        /// <param name="kubeAuditRetentionTime">The retention time in days of
        /// kube audit logs set on the CloudWatch log group</param>
        /// <param name="scubaExternalId">The externalId used by the data
        /// reader to prevent the confused deputy attack</param>
        public DefenderForContainersAwsOffering(string description = default(string), DefenderForContainersAwsOfferingKubernetesService kubernetesService = default(DefenderForContainersAwsOfferingKubernetesService), DefenderForContainersAwsOfferingKubernetesScubaReader kubernetesScubaReader = default(DefenderForContainersAwsOfferingKubernetesScubaReader), DefenderForContainersAwsOfferingCloudWatchToKinesis cloudWatchToKinesis = default(DefenderForContainersAwsOfferingCloudWatchToKinesis), DefenderForContainersAwsOfferingKinesisToS3 kinesisToS3 = default(DefenderForContainersAwsOfferingKinesisToS3), DefenderForContainersAwsOfferingContainerVulnerabilityAssessment containerVulnerabilityAssessment = default(DefenderForContainersAwsOfferingContainerVulnerabilityAssessment), DefenderForContainersAwsOfferingContainerVulnerabilityAssessmentTask containerVulnerabilityAssessmentTask = default(DefenderForContainersAwsOfferingContainerVulnerabilityAssessmentTask), bool? enableContainerVulnerabilityAssessment = default(bool?), bool? autoProvisioning = default(bool?), long? kubeAuditRetentionTime = default(long?), string scubaExternalId = default(string))
            : base(description)
        {
            KubernetesService = kubernetesService;
            KubernetesScubaReader = kubernetesScubaReader;
            CloudWatchToKinesis = cloudWatchToKinesis;
            KinesisToS3 = kinesisToS3;
            ContainerVulnerabilityAssessment = containerVulnerabilityAssessment;
            ContainerVulnerabilityAssessmentTask = containerVulnerabilityAssessmentTask;
            EnableContainerVulnerabilityAssessment = enableContainerVulnerabilityAssessment;
            AutoProvisioning = autoProvisioning;
            KubeAuditRetentionTime = kubeAuditRetentionTime;
            ScubaExternalId = scubaExternalId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the kubernetes service connection configuration
        /// </summary>
        [JsonProperty(PropertyName = "kubernetesService")]
        public DefenderForContainersAwsOfferingKubernetesService KubernetesService { get; set; }

        /// <summary>
        /// Gets or sets the kubernetes to scuba connection configuration
        /// </summary>
        [JsonProperty(PropertyName = "kubernetesScubaReader")]
        public DefenderForContainersAwsOfferingKubernetesScubaReader KubernetesScubaReader { get; set; }

        /// <summary>
        /// Gets or sets the cloudwatch to kinesis connection configuration
        /// </summary>
        [JsonProperty(PropertyName = "cloudWatchToKinesis")]
        public DefenderForContainersAwsOfferingCloudWatchToKinesis CloudWatchToKinesis { get; set; }

        /// <summary>
        /// Gets or sets the kinesis to s3 connection configuration
        /// </summary>
        [JsonProperty(PropertyName = "kinesisToS3")]
        public DefenderForContainersAwsOfferingKinesisToS3 KinesisToS3 { get; set; }

        /// <summary>
        /// Gets or sets the container vulnerability assessment configuration
        /// </summary>
        [JsonProperty(PropertyName = "containerVulnerabilityAssessment")]
        public DefenderForContainersAwsOfferingContainerVulnerabilityAssessment ContainerVulnerabilityAssessment { get; set; }

        /// <summary>
        /// Gets or sets the container vulnerability assessment task
        /// configuration
        /// </summary>
        [JsonProperty(PropertyName = "containerVulnerabilityAssessmentTask")]
        public DefenderForContainersAwsOfferingContainerVulnerabilityAssessmentTask ContainerVulnerabilityAssessmentTask { get; set; }

        /// <summary>
        /// Gets or sets enable container vulnerability assessment feature
        /// </summary>
        [JsonProperty(PropertyName = "enableContainerVulnerabilityAssessment")]
        public bool? EnableContainerVulnerabilityAssessment { get; set; }

        /// <summary>
        /// Gets or sets is audit logs pipeline auto provisioning enabled
        /// </summary>
        [JsonProperty(PropertyName = "autoProvisioning")]
        public bool? AutoProvisioning { get; set; }

        /// <summary>
        /// Gets or sets the retention time in days of kube audit logs set on
        /// the CloudWatch log group
        /// </summary>
        [JsonProperty(PropertyName = "kubeAuditRetentionTime")]
        public long? KubeAuditRetentionTime { get; set; }

        /// <summary>
        /// Gets or sets the externalId used by the data reader to prevent the
        /// confused deputy attack
        /// </summary>
        [JsonProperty(PropertyName = "scubaExternalId")]
        public string ScubaExternalId { get; set; }

    }
}
