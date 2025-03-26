// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Samples
{
    public partial class Sample_PartnerRegistrationCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_PartnerRegistrationsCreateOrUpdate()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/PartnerRegistrations_CreateOrUpdate.json
            // this example is just showing the usage of "PartnerRegistrations_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this PartnerRegistrationResource
            PartnerRegistrationCollection collection = resourceGroupResource.GetPartnerRegistrations();

            // invoke the operation
            string partnerRegistrationName = "examplePartnerRegistrationName1";
            PartnerRegistrationData data = new PartnerRegistrationData(new AzureLocation("global"))
            {
                Tags =
{
["key1"] = "value1",
["key2"] = "Value2",
["key3"] = "Value3"
},
            };
            ArmOperation<PartnerRegistrationResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, partnerRegistrationName, data);
            PartnerRegistrationResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            PartnerRegistrationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_PartnerRegistrationsGet()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/PartnerRegistrations_Get.json
            // this example is just showing the usage of "PartnerRegistrations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this PartnerRegistrationResource
            PartnerRegistrationCollection collection = resourceGroupResource.GetPartnerRegistrations();

            // invoke the operation
            string partnerRegistrationName = "examplePartnerRegistrationName1";
            PartnerRegistrationResource result = await collection.GetAsync(partnerRegistrationName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            PartnerRegistrationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_PartnerRegistrationsListByResourceGroup()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/PartnerRegistrations_ListByResourceGroup.json
            // this example is just showing the usage of "PartnerRegistrations_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this PartnerRegistrationResource
            PartnerRegistrationCollection collection = resourceGroupResource.GetPartnerRegistrations();

            // invoke the operation and iterate over the result
            await foreach (PartnerRegistrationResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                PartnerRegistrationData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_PartnerRegistrationsGet()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/PartnerRegistrations_Get.json
            // this example is just showing the usage of "PartnerRegistrations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this PartnerRegistrationResource
            PartnerRegistrationCollection collection = resourceGroupResource.GetPartnerRegistrations();

            // invoke the operation
            string partnerRegistrationName = "examplePartnerRegistrationName1";
            bool result = await collection.ExistsAsync(partnerRegistrationName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_PartnerRegistrationsGet()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/PartnerRegistrations_Get.json
            // this example is just showing the usage of "PartnerRegistrations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this PartnerRegistrationResource
            PartnerRegistrationCollection collection = resourceGroupResource.GetPartnerRegistrations();

            // invoke the operation
            string partnerRegistrationName = "examplePartnerRegistrationName1";
            NullableResponse<PartnerRegistrationResource> response = await collection.GetIfExistsAsync(partnerRegistrationName);
            PartnerRegistrationResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                PartnerRegistrationData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
