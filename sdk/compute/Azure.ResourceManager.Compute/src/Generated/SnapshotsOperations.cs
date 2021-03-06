// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> The Snapshots service client. </summary>
    public partial class SnapshotsOperations
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SnapshotsRestOperations RestClient { get; }

        /// <summary> Initializes a new instance of SnapshotsOperations for mocking. </summary>
        protected SnapshotsOperations()
        {
        }

        /// <summary> Initializes a new instance of SnapshotsOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal SnapshotsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null)
        {
            RestClient = new SnapshotsRestOperations(clientDiagnostics, pipeline, subscriptionId, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Gets information about a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Snapshot>> GetAsync(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(resourceGroupName, snapshotName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Snapshot> Get(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.Get");
            scope.Start();
            try
            {
                return RestClient.Get(resourceGroupName, snapshotName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists snapshots under a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual AsyncPageable<Snapshot> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            async Task<Page<Snapshot>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Snapshot>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupNextPageAsync(nextLink, resourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists snapshots under a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Pageable<Snapshot> ListByResourceGroup(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            Page<Snapshot> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroup(resourceGroupName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Snapshot> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroupNextPage(nextLink, resourceGroupName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists snapshots under a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Snapshot> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Snapshot>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Snapshot>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists snapshots under a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Snapshot> List(CancellationToken cancellationToken = default)
        {
            Page<Snapshot> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.List");
                scope.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Snapshot> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.List");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Creates or updates a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="snapshot"/> is null. </exception>
        public virtual async Task<SnapshotsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string snapshotName, Snapshot snapshot, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(resourceGroupName, snapshotName, snapshot, cancellationToken).ConfigureAwait(false);
                return new SnapshotsCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, snapshotName, snapshot).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="snapshot"/> is null. </exception>
        public virtual SnapshotsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string snapshotName, Snapshot snapshot, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.CreateOrUpdate(resourceGroupName, snapshotName, snapshot, cancellationToken);
                return new SnapshotsCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, snapshotName, snapshot).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates (patches) a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Patch snapshot operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="snapshot"/> is null. </exception>
        public virtual async Task<SnapshotsUpdateOperation> StartUpdateAsync(string resourceGroupName, string snapshotName, SnapshotUpdate snapshot, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.UpdateAsync(resourceGroupName, snapshotName, snapshot, cancellationToken).ConfigureAwait(false);
                return new SnapshotsUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateRequest(resourceGroupName, snapshotName, snapshot).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates (patches) a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="snapshot"> Snapshot object supplied in the body of the Patch snapshot operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="snapshot"/> is null. </exception>
        public virtual SnapshotsUpdateOperation StartUpdate(string resourceGroupName, string snapshotName, SnapshotUpdate snapshot, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Update(resourceGroupName, snapshotName, snapshot, cancellationToken);
                return new SnapshotsUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateRequest(resourceGroupName, snapshotName, snapshot).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="snapshotName"/> is null. </exception>
        public virtual async Task<SnapshotsDeleteOperation> StartDeleteAsync(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsync(resourceGroupName, snapshotName, cancellationToken).ConfigureAwait(false);
                return new SnapshotsDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, snapshotName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="snapshotName"/> is null. </exception>
        public virtual SnapshotsDeleteOperation StartDelete(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete(resourceGroupName, snapshotName, cancellationToken);
                return new SnapshotsDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, snapshotName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Grants access to a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get snapshot access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="grantAccessData"/> is null. </exception>
        public virtual async Task<SnapshotsGrantAccessOperation> StartGrantAccessAsync(string resourceGroupName, string snapshotName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartGrantAccess");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.GrantAccessAsync(resourceGroupName, snapshotName, grantAccessData, cancellationToken).ConfigureAwait(false);
                return new SnapshotsGrantAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateGrantAccessRequest(resourceGroupName, snapshotName, grantAccessData).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Grants access to a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get snapshot access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="snapshotName"/>, or <paramref name="grantAccessData"/> is null. </exception>
        public virtual SnapshotsGrantAccessOperation StartGrantAccess(string resourceGroupName, string snapshotName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartGrantAccess");
            scope.Start();
            try
            {
                var originalResponse = RestClient.GrantAccess(resourceGroupName, snapshotName, grantAccessData, cancellationToken);
                return new SnapshotsGrantAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateGrantAccessRequest(resourceGroupName, snapshotName, grantAccessData).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revokes access to a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="snapshotName"/> is null. </exception>
        public virtual async Task<SnapshotsRevokeAccessOperation> StartRevokeAccessAsync(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartRevokeAccess");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.RevokeAccessAsync(resourceGroupName, snapshotName, cancellationToken).ConfigureAwait(false);
                return new SnapshotsRevokeAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateRevokeAccessRequest(resourceGroupName, snapshotName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revokes access to a snapshot. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="snapshotName"> The name of the snapshot that is being created. The name can&apos;t be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="snapshotName"/> is null. </exception>
        public virtual SnapshotsRevokeAccessOperation StartRevokeAccess(string resourceGroupName, string snapshotName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (snapshotName == null)
            {
                throw new ArgumentNullException(nameof(snapshotName));
            }

            using var scope = _clientDiagnostics.CreateScope("SnapshotsOperations.StartRevokeAccess");
            scope.Start();
            try
            {
                var originalResponse = RestClient.RevokeAccess(resourceGroupName, snapshotName, cancellationToken);
                return new SnapshotsRevokeAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateRevokeAccessRequest(resourceGroupName, snapshotName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
