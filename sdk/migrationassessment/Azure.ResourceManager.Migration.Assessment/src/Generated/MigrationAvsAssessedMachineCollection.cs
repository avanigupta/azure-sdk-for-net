// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Migration.Assessment
{
    /// <summary>
    /// A class representing a collection of <see cref="MigrationAvsAssessedMachineResource"/> and their operations.
    /// Each <see cref="MigrationAvsAssessedMachineResource"/> in the collection will belong to the same instance of <see cref="MigrationAvsAssessmentResource"/>.
    /// To get a <see cref="MigrationAvsAssessedMachineCollection"/> instance call the GetMigrationAvsAssessedMachines method from an instance of <see cref="MigrationAvsAssessmentResource"/>.
    /// </summary>
    public partial class MigrationAvsAssessedMachineCollection : ArmCollection, IEnumerable<MigrationAvsAssessedMachineResource>, IAsyncEnumerable<MigrationAvsAssessedMachineResource>
    {
        private readonly ClientDiagnostics _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics;
        private readonly AvsAssessedMachinesRestOperations _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MigrationAvsAssessedMachineCollection"/> class for mocking. </summary>
        protected MigrationAvsAssessedMachineCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MigrationAvsAssessedMachineCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MigrationAvsAssessedMachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Migration.Assessment", MigrationAvsAssessedMachineResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MigrationAvsAssessedMachineResource.ResourceType, out string migrationAvsAssessedMachineAvsAssessedMachinesOperationsApiVersion);
            _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient = new AvsAssessedMachinesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, migrationAvsAssessedMachineAvsAssessedMachinesOperationsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != MigrationAvsAssessmentResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, MigrationAvsAssessmentResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a AvsAssessedMachine
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual async Task<Response<MigrationAvsAssessedMachineResource>> GetAsync(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.Get");
            scope.Start();
            try
            {
                var response = await _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MigrationAvsAssessedMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a AvsAssessedMachine
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual Response<MigrationAvsAssessedMachineResource> Get(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.Get");
            scope.Start();
            try
            {
                var response = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MigrationAvsAssessedMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List AvsAssessedMachine resources by AvsAssessment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_ListByAvsAssessment</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter query. </param>
        /// <param name="pageSize"> Optional parameter for page size. </param>
        /// <param name="continuationToken"> Optional parameter for continuation token. </param>
        /// <param name="totalRecordCount"> Total record count. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MigrationAvsAssessedMachineResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MigrationAvsAssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = null, string continuationToken = null, int? totalRecordCount = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.CreateListByAvsAssessmentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, pageSizeHint, continuationToken, totalRecordCount);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.CreateListByAvsAssessmentNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, pageSizeHint, continuationToken, totalRecordCount);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MigrationAvsAssessedMachineResource(Client, MigrationAvsAssessedMachineData.DeserializeMigrationAvsAssessedMachineData(e)), _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics, Pipeline, "MigrationAvsAssessedMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List AvsAssessedMachine resources by AvsAssessment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_ListByAvsAssessment</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter query. </param>
        /// <param name="pageSize"> Optional parameter for page size. </param>
        /// <param name="continuationToken"> Optional parameter for continuation token. </param>
        /// <param name="totalRecordCount"> Total record count. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MigrationAvsAssessedMachineResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MigrationAvsAssessedMachineResource> GetAll(string filter = null, int? pageSize = null, string continuationToken = null, int? totalRecordCount = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.CreateListByAvsAssessmentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, pageSizeHint, continuationToken, totalRecordCount);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.CreateListByAvsAssessmentNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, pageSizeHint, continuationToken, totalRecordCount);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MigrationAvsAssessedMachineResource(Client, MigrationAvsAssessedMachineData.DeserializeMigrationAvsAssessedMachineData(e)), _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics, Pipeline, "MigrationAvsAssessedMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.Exists");
            scope.Start();
            try
            {
                var response = await _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual Response<bool> Exists(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.Exists");
            scope.Start();
            try
            {
                var response = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual async Task<NullableResponse<MigrationAvsAssessedMachineResource>> GetIfExistsAsync(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MigrationAvsAssessedMachineResource>(response.GetRawResponse());
                return Response.FromValue(new MigrationAvsAssessedMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/groups/{groupName}/avsAssessments/{assessmentName}/avsAssessedMachines/{avsAssessedMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvsAssessedMachinesOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAvsAssessedMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="avsAssessedMachineName"> AVS assessment Assessed Machine ARM name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="avsAssessedMachineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="avsAssessedMachineName"/> is null. </exception>
        public virtual NullableResponse<MigrationAvsAssessedMachineResource> GetIfExists(string avsAssessedMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(avsAssessedMachineName, nameof(avsAssessedMachineName));

            using var scope = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsClientDiagnostics.CreateScope("MigrationAvsAssessedMachineCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _migrationAvsAssessedMachineAvsAssessedMachinesOperationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, avsAssessedMachineName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MigrationAvsAssessedMachineResource>(response.GetRawResponse());
                return Response.FromValue(new MigrationAvsAssessedMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MigrationAvsAssessedMachineResource> IEnumerable<MigrationAvsAssessedMachineResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MigrationAvsAssessedMachineResource> IAsyncEnumerable<MigrationAvsAssessedMachineResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
