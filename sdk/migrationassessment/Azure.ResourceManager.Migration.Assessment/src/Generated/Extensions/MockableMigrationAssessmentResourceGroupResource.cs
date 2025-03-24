// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Migration.Assessment.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMigrationAssessmentResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMigrationAssessmentResourceGroupResource"/> class for mocking. </summary>
        protected MockableMigrationAssessmentResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMigrationAssessmentResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMigrationAssessmentResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of MigrationAssessmentProjectResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of MigrationAssessmentProjectResources and their operations over a MigrationAssessmentProjectResource. </returns>
        public virtual MigrationAssessmentProjectCollection GetMigrationAssessmentProjects()
        {
            return GetCachedClient(client => new MigrationAssessmentProjectCollection(client, Id));
        }

        /// <summary>
        /// Get a AssessmentProject
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssessmentProjectsOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentProjectResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> Assessment Project Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MigrationAssessmentProjectResource>> GetMigrationAssessmentProjectAsync(string projectName, CancellationToken cancellationToken = default)
        {
            return await GetMigrationAssessmentProjects().GetAsync(projectName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a AssessmentProject
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssessmentProjectsOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentProjectResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> Assessment Project Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MigrationAssessmentProjectResource> GetMigrationAssessmentProject(string projectName, CancellationToken cancellationToken = default)
        {
            return GetMigrationAssessmentProjects().Get(projectName, cancellationToken);
        }
    }
}
