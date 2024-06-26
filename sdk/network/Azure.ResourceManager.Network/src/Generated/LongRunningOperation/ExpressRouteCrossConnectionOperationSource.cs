// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    internal class ExpressRouteCrossConnectionOperationSource : IOperationSource<ExpressRouteCrossConnectionResource>
    {
        private readonly ArmClient _client;

        internal ExpressRouteCrossConnectionOperationSource(ArmClient client)
        {
            _client = client;
        }

        ExpressRouteCrossConnectionResource IOperationSource<ExpressRouteCrossConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ExpressRouteCrossConnectionData.DeserializeExpressRouteCrossConnectionData(document.RootElement);
            return new ExpressRouteCrossConnectionResource(_client, data);
        }

        async ValueTask<ExpressRouteCrossConnectionResource> IOperationSource<ExpressRouteCrossConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ExpressRouteCrossConnectionData.DeserializeExpressRouteCrossConnectionData(document.RootElement);
            return new ExpressRouteCrossConnectionResource(_client, data);
        }
    }
}
