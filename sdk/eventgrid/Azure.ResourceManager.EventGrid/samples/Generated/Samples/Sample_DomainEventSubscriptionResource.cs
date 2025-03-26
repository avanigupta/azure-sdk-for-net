// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.EventGrid.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Samples
{
    public partial class Sample_DomainEventSubscriptionResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_DomainEventSubscriptionsGet()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/DomainEventSubscriptions_Get.json
            // this example is just showing the usage of "DomainEventSubscriptions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DomainEventSubscriptionResource created on azure
            // for more information of creating DomainEventSubscriptionResource, please refer to the document of DomainEventSubscriptionResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            string domainName = "exampleDomain1";
            string eventSubscriptionName = "examplesubscription1";
            ResourceIdentifier domainEventSubscriptionResourceId = DomainEventSubscriptionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, domainName, eventSubscriptionName);
            DomainEventSubscriptionResource domainEventSubscription = client.GetDomainEventSubscriptionResource(domainEventSubscriptionResourceId);

            // invoke the operation
            DomainEventSubscriptionResource result = await domainEventSubscription.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            EventGridSubscriptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DomainEventSubscriptionsDelete()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/DomainEventSubscriptions_Delete.json
            // this example is just showing the usage of "DomainEventSubscriptions_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DomainEventSubscriptionResource created on azure
            // for more information of creating DomainEventSubscriptionResource, please refer to the document of DomainEventSubscriptionResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            string domainName = "exampleDomain1";
            string eventSubscriptionName = "examplesubscription1";
            ResourceIdentifier domainEventSubscriptionResourceId = DomainEventSubscriptionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, domainName, eventSubscriptionName);
            DomainEventSubscriptionResource domainEventSubscription = client.GetDomainEventSubscriptionResource(domainEventSubscriptionResourceId);

            // invoke the operation
            await domainEventSubscription.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_DomainEventSubscriptionsUpdate()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/DomainEventSubscriptions_Update.json
            // this example is just showing the usage of "DomainEventSubscriptions_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DomainEventSubscriptionResource created on azure
            // for more information of creating DomainEventSubscriptionResource, please refer to the document of DomainEventSubscriptionResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            string domainName = "exampleDomain1";
            string eventSubscriptionName = "exampleEventSubscriptionName1";
            ResourceIdentifier domainEventSubscriptionResourceId = DomainEventSubscriptionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, domainName, eventSubscriptionName);
            DomainEventSubscriptionResource domainEventSubscription = client.GetDomainEventSubscriptionResource(domainEventSubscriptionResourceId);

            // invoke the operation
            EventGridSubscriptionPatch patch = new EventGridSubscriptionPatch
            {
                Destination = new WebHookEventSubscriptionDestination
                {
                    Endpoint = new Uri("https://requestb.in/15ksip71"),
                },
                Filter = new EventSubscriptionFilter
                {
                    SubjectBeginsWith = "existingPrefix",
                    SubjectEndsWith = "newSuffix",
                    IsSubjectCaseSensitive = true,
                },
                Labels = { "label1", "label2" },
            };
            ArmOperation<DomainEventSubscriptionResource> lro = await domainEventSubscription.UpdateAsync(WaitUntil.Completed, patch);
            DomainEventSubscriptionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            EventGridSubscriptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetDeliveryAttributes_DomainEventSubscriptionsGetDeliveryAttributes()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/DomainEventSubscriptions_GetDeliveryAttributes.json
            // this example is just showing the usage of "DomainEventSubscriptions_GetDeliveryAttributes" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DomainEventSubscriptionResource created on azure
            // for more information of creating DomainEventSubscriptionResource, please refer to the document of DomainEventSubscriptionResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            string domainName = "exampleDomain1";
            string eventSubscriptionName = "examplesubscription1";
            ResourceIdentifier domainEventSubscriptionResourceId = DomainEventSubscriptionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, domainName, eventSubscriptionName);
            DomainEventSubscriptionResource domainEventSubscription = client.GetDomainEventSubscriptionResource(domainEventSubscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (DeliveryAttributeMapping item in domainEventSubscription.GetDeliveryAttributesAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetFullUri_DomainEventSubscriptionsGetFullUrl()
        {
            // Generated from example definition: specification/eventgrid/resource-manager/Microsoft.EventGrid/stable/2025-02-15/examples/DomainEventSubscriptions_GetFullUrl.json
            // this example is just showing the usage of "DomainEventSubscriptions_GetFullUri" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DomainEventSubscriptionResource created on azure
            // for more information of creating DomainEventSubscriptionResource, please refer to the document of DomainEventSubscriptionResource
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "examplerg";
            string domainName = "exampleDomain1";
            string eventSubscriptionName = "examplesubscription1";
            ResourceIdentifier domainEventSubscriptionResourceId = DomainEventSubscriptionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, domainName, eventSubscriptionName);
            DomainEventSubscriptionResource domainEventSubscription = client.GetDomainEventSubscriptionResource(domainEventSubscriptionResourceId);

            // invoke the operation
            EventSubscriptionFullUri result = await domainEventSubscription.GetFullUriAsync();

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
