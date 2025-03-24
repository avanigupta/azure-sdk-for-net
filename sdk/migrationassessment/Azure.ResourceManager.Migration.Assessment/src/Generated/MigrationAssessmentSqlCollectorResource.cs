// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Migration.Assessment
{
    /// <summary>
    /// A Class representing a MigrationAssessmentSqlCollector along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MigrationAssessmentSqlCollectorResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMigrationAssessmentSqlCollectorResource method.
    /// Otherwise you can get one from its parent resource <see cref="MigrationAssessmentProjectResource"/> using the GetMigrationAssessmentSqlCollector method.
    /// </summary>
    public partial class MigrationAssessmentSqlCollectorResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MigrationAssessmentSqlCollectorResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="projectName"> The projectName. </param>
        /// <param name="collectorName"> The collectorName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string collectorName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics;
        private readonly SqlCollectorRestOperations _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient;
        private readonly MigrationAssessmentSqlCollectorData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Migrate/assessmentProjects/sqlcollectors";

        /// <summary> Initializes a new instance of the <see cref="MigrationAssessmentSqlCollectorResource"/> class for mocking. </summary>
        protected MigrationAssessmentSqlCollectorResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MigrationAssessmentSqlCollectorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MigrationAssessmentSqlCollectorResource(ArmClient client, MigrationAssessmentSqlCollectorData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MigrationAssessmentSqlCollectorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MigrationAssessmentSqlCollectorResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Migration.Assessment", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string migrationAssessmentSqlCollectorSqlCollectorOperationsApiVersion);
            _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient = new SqlCollectorRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, migrationAssessmentSqlCollectorSqlCollectorOperationsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MigrationAssessmentSqlCollectorData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MigrationAssessmentSqlCollectorResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Get");
            scope.Start();
            try
            {
                var response = await _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MigrationAssessmentSqlCollectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MigrationAssessmentSqlCollectorResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Get");
            scope.Start();
            try
            {
                var response = _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MigrationAssessmentSqlCollectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Delete");
            scope.Start();
            try
            {
                var response = await _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var uri = _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AssessmentArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Delete");
            scope.Start();
            try
            {
                var response = _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var uri = _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.CreateDeleteRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AssessmentArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MigrationAssessmentSqlCollectorResource>> UpdateAsync(WaitUntil waitUntil, MigrationAssessmentSqlCollectorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Update");
            scope.Start();
            try
            {
                var response = await _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new AssessmentArmOperation<MigrationAssessmentSqlCollectorResource>(new MigrationAssessmentSqlCollectorOperationSource(Client), _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics, Pipeline, _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a SqlCollector
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/assessmentProjects/{projectName}/sqlcollectors/{collectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SqlCollectorOperations_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-15</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MigrationAssessmentSqlCollectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MigrationAssessmentSqlCollectorResource> Update(WaitUntil waitUntil, MigrationAssessmentSqlCollectorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics.CreateScope("MigrationAssessmentSqlCollectorResource.Update");
            scope.Start();
            try
            {
                var response = _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new AssessmentArmOperation<MigrationAssessmentSqlCollectorResource>(new MigrationAssessmentSqlCollectorOperationSource(Client), _migrationAssessmentSqlCollectorSqlCollectorOperationsClientDiagnostics, Pipeline, _migrationAssessmentSqlCollectorSqlCollectorOperationsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
