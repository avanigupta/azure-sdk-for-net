// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtTypeSpec.Models;

namespace MgmtTypeSpec
{
    /// <summary></summary>
    public partial class FooResource : ArmResource
    {
        private FooData _data;
        private ClientDiagnostics _fooClientDiagnostics;
        private Foos _fooRestClient;
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "MgmtTypeSpec/foos";

        /// <summary> Initializes a new instance of FooResource for mocking. </summary>
        protected FooResource()
        {
        }

        internal FooResource(ArmClient client, FooData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        internal FooResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fooClientDiagnostics = new ClientDiagnostics("MgmtTypeSpec", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string fooApiVersion);
            _fooRestClient = new Foos(Pipeline, Endpoint, fooApiVersion);
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual FooData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), id);
            }
        }

        /// <summary> Update a Foo. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resource"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
        public virtual ArmOperation<FooResource> Update(WaitUntil waitUntil, FooData resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.createOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, resource, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<FooData> response = Response.FromValue((FooData)result, result);
                MgmtTypeSpecArmOperation<FooResource> operation = new MgmtTypeSpecArmOperation<FooResource>(
                    new FooOperationSource(Client),
                    _fooClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response.GetRawResponse(),
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a Foo. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resource"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
        public virtual async Task<ArmOperation<FooResource>> UpdateAsync(WaitUntil waitUntil, FooData resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.createOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, resource, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<FooData> response = Response.FromValue((FooData)result, result);
                MgmtTypeSpecArmOperation<FooResource> operation = new MgmtTypeSpecArmOperation<FooResource>(
                    new FooOperationSource(Client),
                    _fooClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response.GetRawResponse(),
                    OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a Foo. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<FooResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<FooData> response = Response.FromValue((FooData)result, result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a Foo. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<FooResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<FooData> response = Response.FromValue((FooData)result, result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a Foo. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                MgmtTypeSpecArmOperation operation = new MgmtTypeSpecArmOperation(_fooClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a Foo. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _fooClientDiagnostics.CreateScope("MgmtTypeSpec.delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                }
                ;
                HttpMessage message = _fooRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                MgmtTypeSpecArmOperation operation = new MgmtTypeSpecArmOperation(_fooClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
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
