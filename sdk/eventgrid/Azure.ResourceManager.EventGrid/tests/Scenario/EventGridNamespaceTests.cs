﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridNamespaceTests : EventGridManagementTestBase
    {
        public EventGridNamespaceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private EventGridNamespaceCollection NamespaceCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task NamespaceCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceName2 = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceName3 = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true
            };

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getNamespaceResponse.Data.ProvisioningState);
            Assert.IsTrue(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag1"));
            Assert.AreEqual(getNamespaceResponse.Data.Tags["originalTag1"], "originalValue1");
            Assert.IsTrue(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag2"));
            Assert.AreEqual(getNamespaceResponse.Data.Tags["originalTag2"], "originalValue2");
            Assert.AreEqual(getNamespaceResponse.Data.Sku.Name.Value.ToString(), namespaceSkuName);
            Assert.AreEqual(getNamespaceResponse.Data.Sku.Capacity.Value, 1);
            Assert.IsTrue(getNamespaceResponse.Data.IsZoneRedundant.Value);

            // update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
            };
            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.NotNull(updateNamespaceResponse);
            Assert.AreEqual(updateNamespaceResponse.Data.Name, namespaceName);
            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getUpdatedNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getUpdatedNamespaceResponse.Data.ProvisioningState);
            Assert.IsTrue(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag1"));
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Tags["updatedTag1"], "updatedValue1");
            Assert.IsTrue(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag2"));
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Tags["updatedTag2"], "updatedValue2");
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Sku.Name.Value.ToString(), namespaceSkuName);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Sku.Capacity.Value, 2);
            Assert.IsTrue(getUpdatedNamespaceResponse.Data.IsZoneRedundant.Value);

            //Create 2nd and 3rd Namespace
            var createNamespaceResponse2 = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse2);
            Assert.AreEqual(createNamespaceResponse2.Data.Name, namespaceName2);
            var createNamespaceResponse3 = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName3, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse3);
            Assert.AreEqual(createNamespaceResponse3.Data.Name, namespaceName3);

            // Get the created namespaces
            var getNamespace2Response = (await NamespaceCollection.GetAsync(namespaceName2)).Value;
            Assert.NotNull(getNamespace2Response);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getNamespace2Response.Data.ProvisioningState);
            var getNamespace3Response = (await NamespaceCollection.GetAsync(namespaceName3)).Value;
            Assert.NotNull(getNamespace3Response);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getNamespace3Response.Data.ProvisioningState);

            // List Shared Access Keys and Regenerate keys
            var sharedAccessKeys = (await getNamespaceResponse.GetSharedAccessKeysAsync()).Value;
            var sharedAccessKey1Before = sharedAccessKeys.Key1;
            var sharedAccessKey2Before = sharedAccessKeys.Key2;
            NamespaceRegenerateKeyContent namespaceRegenerateKeyContent = new NamespaceRegenerateKeyContent("key1");
            var regenKeysResponse = (await getNamespaceResponse.RegenerateKeyAsync(WaitUntil.Completed, namespaceRegenerateKeyContent)).Value;
            Assert.AreNotEqual(regenKeysResponse.Key1, sharedAccessKey1Before);
            Assert.AreEqual(regenKeysResponse.Key2, sharedAccessKey2Before);

            // List all namespaces
            var namespacesInResourceGroup = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(namespacesInResourceGroup);
            Assert.AreEqual(namespacesInResourceGroup.Count, 3);

            // Check Exists method
            var namespaceExists = await NamespaceCollection.ExistsAsync(namespaceName3);
            Assert.True(namespaceExists);

            // Delete namespace3
            await getNamespace3Response.DeleteAsync(WaitUntil.Completed);

            // List all namespaces under resourc group again to check updated number of namespaces.
            var namespacesInResourceGroupUpdated = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(namespacesInResourceGroupUpdated);
            Assert.AreEqual(namespacesInResourceGroupUpdated.Count, 2);

            // Get all namespaces created within the subscription irrespective of the resourceGroup
            var namespacesInAzureSubscription = await DefaultSubscription.GetEventGridNamespacesAsync().ToEnumerableAsync();
            Assert.NotNull(namespacesInAzureSubscription);
            Assert.GreaterOrEqual(namespacesInAzureSubscription.Count, 1);
            var falseFlag = false;
            foreach (var item in namespacesInAzureSubscription)
            {
                if (item.Data.Name == namespaceName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.IsTrue(falseFlag);

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await getNamespace2Response.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.False(namespace1Exists);
            var namespace2Exists = await NamespaceCollection.ExistsAsync(namespaceName2);
            Assert.False(namespace2Exists);

            // List all namespaces under resource group again to check updated number of namespaces.
            var namespacesInResourceGroupDeleted = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(namespacesInResourceGroupDeleted);
            Assert.AreEqual(namespacesInResourceGroupDeleted.Count, 0);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
        [Ignore("The operation failed due to an internal server error. The initial state of the impacted resources (if any) are restored. Please try again in few minutes. If error still persists, report ca1db280-5595-40f0-8e85-2070691a5466:3/11/2025 11:54:13 AM (UTC) to our forums for assistance or raise a support ticket .")]
        [Test]
        public async Task NamespaceCustomDomainsCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned),
                IsZoneRedundant = true
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_centraleaup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getNamespaceResponse.Data.ProvisioningState);
            Assert.IsTrue(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag1"));
            Assert.AreEqual(getNamespaceResponse.Data.Tags["originalTag1"], "originalValue1");
            Assert.IsTrue(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag2"));
            Assert.AreEqual(getNamespaceResponse.Data.Tags["originalTag2"], "originalValue2");
            Assert.AreEqual(getNamespaceResponse.Data.Sku.Name.Value.ToString(), namespaceSkuName);
            Assert.AreEqual(getNamespaceResponse.Data.Sku.Capacity.Value, 1);
            Assert.IsTrue(getNamespaceResponse.Data.IsZoneRedundant.Value);

            // update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
                TopicsConfiguration = new UpdateTopicsConfigurationInfo(),
            };

            // Validate Custom Domain Ownership
            var customDomainValidationResponse = await createNamespaceResponse.ValidateCustomDomainOwnershipAsync(
              WaitUntil.Completed,
             new CancellationToken()
            ).ConfigureAwait(false);

            Assert.NotNull(customDomainValidationResponse);
            Assert.IsNotNull(customDomainValidationResponse.Value);
            namespacePatch.TopicsConfiguration.CustomDomains.Add(new CustomDomainConfiguration()
            {
                FullyQualifiedDomainName = "www.contoso.com",
                Identity = new CustomDomainIdentity()
                {
                    IdentityType = CustomDomainIdentityType.UserAssigned,
                    UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_centraleaup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"
                },
                CertificateUri = new Uri("https://sdk-centraleuap-testakv.vault.azure.net/certificates/test-custom-domain/"),
            });
            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.NotNull(updateNamespaceResponse);
            Assert.AreEqual(updateNamespaceResponse.Data.Name, namespaceName);

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getUpdatedNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getUpdatedNamespaceResponse.Data.ProvisioningState);
            Assert.IsTrue(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag1"));
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Tags["updatedTag1"], "updatedValue1");
            Assert.IsTrue(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag2"));
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Tags["updatedTag2"], "updatedValue2");
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Sku.Name.Value.ToString(), namespaceSkuName);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.Sku.Capacity.Value, 2);
            // verify custom domain
            Assert.NotNull(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains.Count, 1);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains.FirstOrDefault().FullyQualifiedDomainName, "www.contoso.com");

            // Delete 1st custom domain
            namespacePatch.TopicsConfiguration.CustomDomains.RemoveAt(0);
            var updateNamespaceResponse2 = (await getUpdatedNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.NotNull(updateNamespaceResponse2);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, updateNamespaceResponse2.Data.ProvisioningState);

            var getUpdatedNamespaceResponse2 = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            // verify 1st custom domain is deleted
            Assert.NotNull(getUpdatedNamespaceResponse2.Data.TopicsConfiguration.CustomDomains);
            Assert.AreEqual(getUpdatedNamespaceResponse2.Data.TopicsConfiguration.CustomDomains.Count, 0);

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.False(namespace1Exists);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        // Test commented out: CustomJwtAuthenticationSettings feature is in preview (2024-06-01-preview) only
        // and not included in GA version 2025-02-15
        /*
        [Test]
        public async Task NamespaceCustomJwtAuthCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true
            };

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getNamespaceResponse.Data.ProvisioningState);

            // update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
                TopicSpacesConfiguration = new UpdateTopicSpacesConfigurationInfo(),
            };
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication = new ClientAuthenticationSettings();
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication = new CustomJwtAuthenticationSettings()
            {
                TokenIssuer = "sts.windows.net",
            };

            // Add custom jwt auth
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.Add(new IssuerCertificateInfo()
            {
                CertificateUri = new Uri("https://nokjwttest.vault.azure.net/certificates/jwtcert1/11c1bd6003b24e81b6a9d72f0dd1bf70"),
                Identity = new CustomJwtAuthenticationManagedIdentity(CustomJwtAuthenticationManagedIdentityType.SystemAssigned),
            });

            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.NotNull(updateNamespaceResponse);
            Assert.AreEqual(updateNamespaceResponse.Data.Name, namespaceName);

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.NotNull(getUpdatedNamespaceResponse);
            Assert.AreEqual(NamespaceProvisioningState.Succeeded, getUpdatedNamespaceResponse.Data.ProvisioningState);
            // verify custom jwt auth
            Assert.NotNull(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.Count, 1);
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.FirstOrDefault().CertificateUri.AbsoluteUri, "https://nokjwttest.vault.azure.net/certificates/jwtcert1/11c1bd6003b24e81b6a9d72f0dd1bf70");
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.TokenIssuer, "sts.windows.net");
            Assert.AreEqual(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.FirstOrDefault().Identity.IdentityType, CustomJwtAuthenticationManagedIdentityType.SystemAssigned);

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.False(namespace1Exists);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
        */

        // Please run this test in live mode if you make any change, this doesn't work in playback mode due to expiry date field
        /*[Test]
        public async Task NamespaceTopicsSubscriptionWithDeadletterCreateUpdateDelete()
        {
            await SetCollection();
            var topicCollection = ResourceGroup.GetEventGridTopics();

            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    { "originalTag1", "originalValue1" },
                    { "originalTag2", "originalValue2" }
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };

            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse1.Data.EventRetentionInDays, 1);

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();
            var deadLetterDestination = new DeadLetterWithResourceIdentity()
            {
                Identity = new EventSubscriptionIdentity()
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                },
                DeadLetterDestination = new StorageBlobDeadLetterDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.Storage/storageAccounts/testcontosso2"),
                    BlobContainerName = "contosocontainer",
                }
            };
            deadLetterDestination.Identity.UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity";

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                // instead of queue info create push info with event hub destination
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(1),
                    MaxDeliveryCount = 5,
                    ReceiveLockDurationInSeconds = 120,
                    DeadLetterDestinationWithResourceIdentity = deadLetterDestination
                }
            };
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(8);
            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration,
                ExpirationTimeUtc = expirationTime,
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription1);
            Assert.AreEqual(createEventsubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getEventSubscription1);
            Assert.AreEqual(getEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Queue.ToString());
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(1));
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount, 5);

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(0.5),
                    MaxDeliveryCount = 6,
                    ReceiveLockDurationInSeconds = 120
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.NotNull(updateEventSubscription1);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getUpdatedEventSubscription1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Queue.ToString());
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(0.5));
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount, 6);

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsBefore);
            Assert.AreEqual(listAllSubscriptionsBefore.Count, 1);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfter);
            Assert.AreEqual(listAllSubscriptionsAfter.Count, 0);

            // delete all resources
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }*/

        [Test]
        public async Task NamespaceSubscriptionToEventHubCRUD()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName2 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName3 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                {"originalTag1", "originalValue1"},
                {"originalTag2", "originalValue2"}
            },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse1.Data.EventRetentionInDays, 1);

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };

            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription1);
            Assert.AreEqual(createEventsubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription2);
            Assert.AreEqual(createEventsubscription2.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription3);
            Assert.AreEqual(createEventsubscription3.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getEventSubscription1);
            Assert.AreEqual(getEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.NotNull(updateEventSubscription1);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getUpdatedEventSubscription1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsBefore);
            Assert.AreEqual(listAllSubscriptionsBefore.Count, 3);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfter);
            Assert.AreEqual(listAllSubscriptionsAfter.Count, 2);

            // delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfterAllDeleted);
            Assert.AreEqual(listAllSubscriptionsAfterAllDeleted.Count, 0);
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [Ignore("Skipping due to playback mode issue. Needs investigation.")]
        public async Task NamespaceSubscriptionToWebhook()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName2 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName3 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                {"originalTag1", "originalValue1"},
                {"originalTag2", "originalValue2"}
            },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse1.Data.EventRetentionInDays, 1);

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration
            {
                DeliveryMode = DeliveryMode.Push,
                Push = new PushInfo
                {
                    // For the webhook endpoint, replace "SANITIZED_FUNCTION_KEY" with the function key
                    // from the Logic App "mylogicappkish2" in the East US region under the
                    // "Azure Event Grid SDK" subscription.
                    Destination = new WebHookEventSubscriptionDestination
                    {
                        Endpoint = new Uri("https://prod-71.eastus.logic.azure.com:443/workflows/b60c5432896846608c05de3a96be6de2/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=SANITIZED_FUNCTION_KEY"),
                    }
                }
            };
            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration,
                EventDeliverySchema = DeliverySchema.CloudEventSchemaV10,
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription1);
            Assert.AreEqual(createEventsubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription2);
            Assert.AreEqual(createEventsubscription2.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription3);
            Assert.AreEqual(createEventsubscription3.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getEventSubscription1);
            Assert.AreEqual(getEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());
            // test for full uri of event subscription
             var eventSubscription1FullUri = (await getEventSubscription1.GetFullUriAsync());
             Assert.NotNull(eventSubscription1FullUri);

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.NotNull(updateEventSubscription1);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getUpdatedEventSubscription1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsBefore);
            Assert.AreEqual(listAllSubscriptionsBefore.Count, 3);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfter);
            Assert.AreEqual(listAllSubscriptionsAfter.Count, 2);

            // delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfterAllDeleted);
            Assert.AreEqual(listAllSubscriptionsAfterAllDeleted.Count, 0);
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceMQTTOperations()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                TopicSpacesConfiguration = new TopicSpacesConfiguration()
                {
                    State = TopicSpacesConfigurationState.Enabled
                },
            };
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;

            // create caCertificate
            var caCertificatesCollection = createNamespaceResponse.GetCaCertificates();
            var encodedCertificate = "-----BEGIN CERTIFICATE-----\r\nMIIDQTCCAimgAwIBAgITBmyfz5m/jAo54vB4ikPmljZbyjANBgkqhkiG9w0BAQsFADA5MQswCQYDVQQGEwJVUzEPMA0GA1UEChMGQW1hem9uMRkwFwYDVQQDExBBbWF6b24gUm9vdCBDQSAxMB4XDTE1MDUyNjAwMDAwMFoXDTM4MDExNzAwMDAwMFowOTELMAkGA1UEBhMCVVMxDzANBgNVBAoTBkFtYXpvbjEZMBcGA1UEAxMQQW1hem9uIFJvb3QgQ0EgMTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALJ4gHHKeNXjca9HgFB0fW7Y14h29Jlo91ghYPl0hAEvrAIthtOgQ3pOsqTQNroBvo3bSMgHFzZM9O6II8c+6zf1tRn4SWiw3te5djgdYZ6k/oI2peVKVuRF4fn9tBb6dNqcmzU5L/qwIFAGbHrQgLKm+a/sRxmPUDgH3KKHOVj4utWp+UhnMJbulHheb4mjUcAwhmahRWa6VOujw5H5SNz/0egwLX0tdHA114gk957EWW67c4cX8jJGKLhD+rcdqsq08p8kDi1L93FcXmn/6pUCyziKrlA4b9v7LWIbxcceVOF34GfID5yHI9Y/QCB/IIDEgEw+OyQmjgSubJrIqg0CAwEAAaNCMEAwDwYDVR0TAQH/BAUwAwEB/zAOBgNVHQ8BAf8EBAMCAYYwHQYDVR0OBBYEFIQYzIU07LwMlJQuCFmcx7IQTgoIMA0GCSqGSIb3DQEBCwUAA4IBAQCY8jdaQZChGsV2USggNiMOruYou6r4lK5IpDB/G/wkjUu0yKGX9rbxenDIU5PMCCjjmCXPI6T53iHTfIUJrU6adTrCC2qJeHZERxhlbI1Bjjt/msv0tadQ1wUsN+gDS63pYaACbvXy8MWy7Vu33PqUXHeeE6V/Uq2V8viTO96LXFvKWlJbYK8U90vvo/ufQJVtMVT8QtPHRh8jrdkPSHCa2XV4cdFyQzR1bldZwgJcJmApzyMZFo6IQ6XU5MsI+yMRQ+hDKXJioaldXgjUkK642M4UwtBV8ob2xJNDd2ZhwLnoQdeXeGADbkpyrqXRfboQnoZsG4q5WTP468SQvvG5\r\n-----END CERTIFICATE-----";
            var caCertificateData1 = new CaCertificateData()
            {
                Description = "TestCertificate1",
                EncodedCertificate = encodedCertificate
            };
            var caCertificateData2 = new CaCertificateData()
            {
                Description = "TestCertificate2",
                EncodedCertificate = encodedCertificate
            };
            var caCertificateData3 = new CaCertificateData()
            {
                Description = "TestCertificate3",
                EncodedCertificate = encodedCertificate
            };
            var createCaCertificateResponse1 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate1", caCertificateData1)).Value;
            Assert.IsNotNull(createCaCertificateResponse1);
            Assert.AreEqual(createCaCertificateResponse1.Data.ProvisioningState, CaCertificateProvisioningState.Succeeded);
            var createCaCertificateResponse2 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate2", caCertificateData2)).Value;
            Assert.IsNotNull(createCaCertificateResponse2);
            Assert.AreEqual(createCaCertificateResponse2.Data.ProvisioningState, CaCertificateProvisioningState.Succeeded);
            var createCaCertificateResponse3 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate3", caCertificateData3)).Value;
            Assert.IsNotNull(createCaCertificateResponse3);
            Assert.AreEqual(createCaCertificateResponse3.Data.ProvisioningState, CaCertificateProvisioningState.Succeeded);

            //Get CaCertificate
            var getCaCertificate1Response = (await caCertificatesCollection.GetAsync("testCertificate1")).Value;
            Assert.IsNotNull(getCaCertificate1Response);
            Assert.AreEqual(getCaCertificate1Response.Data.Name, "testCertificate1");
            Assert.AreEqual(getCaCertificate1Response.Data.EncodedCertificate, caCertificateData1.EncodedCertificate);

            //List CaCertificates
            var listCaCertificatesBeforeDeletion = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listCaCertificatesBeforeDeletion);
            Assert.AreEqual(listCaCertificatesBeforeDeletion.Count, 3);

            await getCaCertificate1Response.DeleteAsync(WaitUntil.Completed);

            var listCaCertificatesAfterDeletion = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listCaCertificatesAfterDeletion);
            Assert.AreEqual(listCaCertificatesAfterDeletion.Count, 2);

            await createCaCertificateResponse2.DeleteAsync(WaitUntil.Completed);
            await createCaCertificateResponse3.DeleteAsync(WaitUntil.Completed);
            var listCaCertificatesAfterAllDeleted = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listCaCertificatesAfterAllDeleted);
            Assert.AreEqual(listCaCertificatesAfterAllDeleted.Count, 0);

            // create clients
            var clientCollection = createNamespaceResponse.GetEventGridNamespaceClients();
            string clientName1 = "clientName1";
            string clientName2 = "clientName2";
            var clientCertificateAuthentication = new ClientCertificateAuthentication()
            {
                ValidationScheme = ClientCertificateValidationScheme.ThumbprintMatch,
            };
            clientCertificateAuthentication.AllowedThumbprints.Add("934367bf1c97033f877db0f15cb1b586957d313");
            EventGridNamespaceClientData clientData = new EventGridNamespaceClientData()
            {
                ClientCertificateAuthentication = clientCertificateAuthentication,
                Description = "Before"
            };

            var createClientResponse1 = (await clientCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientName1, clientData)).Value;
            Assert.IsNotNull(createClientResponse1);
            Assert.AreEqual(createClientResponse1.Data.Name, clientName1);
            Assert.AreEqual(createClientResponse1.Data.ProvisioningState, EventGridNamespaceClientProvisioningState.Succeeded);
            var createClientResponse2 = (await clientCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientName2, clientData)).Value;
            Assert.IsNotNull(createClientResponse2);
            Assert.AreEqual(createClientResponse2.Data.Name, clientName2);
            Assert.AreEqual(createClientResponse2.Data.ProvisioningState, EventGridNamespaceClientProvisioningState.Succeeded);

            //update client
            EventGridNamespaceClientData updatedClientData = new EventGridNamespaceClientData()
            {
                ClientCertificateAuthentication = clientCertificateAuthentication,
                Description = "After"
            };
            var updateClientResponse = (await createClientResponse1.UpdateAsync(WaitUntil.Completed, updatedClientData)).Value;
            Assert.IsNotNull(updateClientResponse);
            Assert.AreEqual(updateClientResponse.Data.ProvisioningState, EventGridNamespaceClientProvisioningState.Succeeded);

            // Get updated client
            var getClientResponse = (await updateClientResponse.GetAsync()).Value;
            Assert.IsNotNull(getClientResponse);
            Assert.AreEqual(getClientResponse.Data.ProvisioningState, EventGridNamespaceClientProvisioningState.Succeeded);
            Assert.AreEqual(getClientResponse.Data.Name, clientName1);
            Assert.AreEqual(getClientResponse.Data.Description, "After");

            // List clients
            var getAllClientsBeforeDeletion = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(getAllClientsBeforeDeletion);
            Assert.AreEqual(getAllClientsBeforeDeletion.Count, 2);
            await getClientResponse.DeleteAsync(WaitUntil.Completed);
            await createClientResponse2.DeleteAsync(WaitUntil.Completed);
            var getAllClientsAfterDeletion = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(getAllClientsAfterDeletion);
            Assert.AreEqual(getAllClientsAfterDeletion.Count, 0);

            //create client groups
            var clientGroupCollection = createNamespaceResponse.GetEventGridNamespaceClientGroups();
            string clientGroupName1 = "clientGroupName1";
            string clientGroupName2 = "clientGroupName2";
            EventGridNamespaceClientGroupData clientGroupData = new EventGridNamespaceClientGroupData()
            {
                Query = "attributes.testType = 'synthetics'"
            };

            var createClientGroupResponse1 = (await clientGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientGroupName1, clientGroupData)).Value;
            Assert.IsNotNull(createClientGroupResponse1);
            Assert.AreEqual(createClientGroupResponse1.Data.Name, clientGroupName1);
            Assert.AreEqual(createClientGroupResponse1.Data.ProvisioningState, ClientGroupProvisioningState.Succeeded);
            var createClientGroupResponse2 = (await clientGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientGroupName2, clientGroupData)).Value;
            Assert.IsNotNull(createClientGroupResponse2);
            Assert.AreEqual(createClientGroupResponse2.Data.Name, clientGroupName2);
            Assert.AreEqual(createClientGroupResponse2.Data.ProvisioningState, ClientGroupProvisioningState.Succeeded);

            //Get Client Group
            var getClientGroup1Response = (await clientGroupCollection.GetAsync("clientGroupName1")).Value;
            Assert.IsNotNull(getClientGroup1Response);
            Assert.AreEqual(getClientGroup1Response.Data.Name, "clientGroupName1");

            //List Client Groups ==> Note : 1 extra default client group is added by the service.
            var listCientGroupBeforeDeletion = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listCientGroupBeforeDeletion);
            Assert.AreEqual(listCientGroupBeforeDeletion.Count, 3);

            await getClientGroup1Response.DeleteAsync(WaitUntil.Completed);

            var listCientGroupAfterDeletion = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listCientGroupAfterDeletion);
            Assert.AreEqual(listCientGroupAfterDeletion.Count, 2);

            // Create topic spaces
            var topicSpacesCollection = createNamespaceResponse.GetTopicSpaces();
            var topicSpaceName1 = "topicSpace1";
            var topicSpaceName2 = "topicSpace2";
            TopicSpaceData topicSpaceData = new TopicSpaceData();
            topicSpaceData.TopicTemplates.Add("testTopicTemplate1");
            var topicSpaceResponse1 = (await topicSpacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName1, topicSpaceData)).Value;
            Assert.IsNotNull(topicSpaceResponse1);
            Assert.AreEqual(topicSpaceResponse1.Data.ProvisioningState, TopicSpaceProvisioningState.Succeeded);
            Assert.AreEqual(topicSpaceResponse1.Data.Name, topicSpaceName1);
            var topicSpaceResponse2 = (await topicSpacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName2, topicSpaceData)).Value;
            Assert.IsNotNull(topicSpaceResponse2);
            Assert.AreEqual(topicSpaceResponse2.Data.ProvisioningState, TopicSpaceProvisioningState.Succeeded);
            Assert.AreEqual(topicSpaceResponse2.Data.Name, topicSpaceName2);

            // get topic spaces
            var getTopicSpaceResponse1 = (await topicSpacesCollection.GetAsync(topicSpaceName1)).Value;
            Assert.IsNotNull(getTopicSpaceResponse1);
            Assert.AreEqual(getTopicSpaceResponse1.Data.ProvisioningState, TopicSpaceProvisioningState.Succeeded);
            Assert.AreEqual(getTopicSpaceResponse1.Data.Name, topicSpaceName1);
            Assert.AreEqual(getTopicSpaceResponse1.Data.TopicTemplates.Count, 1);

            // update topic spaces
            TopicSpaceData updateTopicSpaceData = new TopicSpaceData();
            updateTopicSpaceData.TopicTemplates.Add("testTopicTemplate1");
            updateTopicSpaceData.TopicTemplates.Add("testTopicTemplate2");
            var updateTopicSpaceResponse = (await getTopicSpaceResponse1.UpdateAsync(WaitUntil.Completed, updateTopicSpaceData)).Value;
            Assert.IsNotNull(updateTopicSpaceResponse);
            Assert.AreEqual(updateTopicSpaceResponse.Data.ProvisioningState, TopicSpaceProvisioningState.Succeeded);
            Assert.AreEqual(updateTopicSpaceResponse.Data.Name, topicSpaceName1);
            Assert.AreEqual(updateTopicSpaceResponse.Data.TopicTemplates.Count, 2);

            //List topic spaces
            var listTopicSpacesBeforeDeletion = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listTopicSpacesBeforeDeletion);
            Assert.AreEqual(listTopicSpacesBeforeDeletion.Count, 2);
            await getTopicSpaceResponse1.DeleteAsync(WaitUntil.Completed);
            var listTopicSpacesAfterDeletion = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listTopicSpacesAfterDeletion);
            Assert.AreEqual(listTopicSpacesAfterDeletion.Count, 1);

            // Create Permission Bindings
            var permissionBindingsCollection = createNamespaceResponse.GetEventGridNamespacePermissionBindings();
            var PermissionBindingName1 = "PermissionBinding1";
            var PermissionBindingName2 = "PermissionBinding2";
            EventGridNamespacePermissionBindingData permissionBindingData = new EventGridNamespacePermissionBindingData()
            {
                TopicSpaceName = topicSpaceName2,
                ClientGroupName = clientGroupName2,
                Permission = PermissionType.Subscriber
            };
            var permissionBindingResponse1 = (await permissionBindingsCollection.CreateOrUpdateAsync(WaitUntil.Completed, PermissionBindingName1, permissionBindingData)).Value;
            Assert.IsNotNull(permissionBindingResponse1);
            Assert.AreEqual(permissionBindingResponse1.Data.ProvisioningState, PermissionBindingProvisioningState.Succeeded);
            Assert.AreEqual(permissionBindingResponse1.Data.Name, PermissionBindingName1);
            Assert.AreEqual(permissionBindingResponse1.Data.Permission, PermissionType.Subscriber);

            var permissionBindingResponse2 = (await permissionBindingsCollection.CreateOrUpdateAsync(WaitUntil.Completed, PermissionBindingName2, permissionBindingData)).Value;
            Assert.IsNotNull(permissionBindingResponse2);
            Assert.AreEqual(permissionBindingResponse2.Data.ProvisioningState, PermissionBindingProvisioningState.Succeeded);
            Assert.AreEqual(permissionBindingResponse2.Data.Name, PermissionBindingName2);

            // udpate permission bindings
            EventGridNamespacePermissionBindingData permissionBindingDataAfter = new EventGridNamespacePermissionBindingData()
            {
                TopicSpaceName = topicSpaceName2,
                ClientGroupName = clientGroupName2,
                Permission = PermissionType.Publisher
            };
            var updatePermissionBindingResponse = (await permissionBindingResponse1.UpdateAsync(WaitUntil.Completed, permissionBindingDataAfter)).Value;
            Assert.IsNotNull(updatePermissionBindingResponse);
            Assert.AreEqual(updatePermissionBindingResponse.Data.ProvisioningState, PermissionBindingProvisioningState.Succeeded);

            // get permission bindings
            var getPermissionBindingResponse = (await permissionBindingsCollection.GetAsync(PermissionBindingName1)).Value;
            Assert.IsNotNull(getPermissionBindingResponse);
            Assert.AreEqual(getPermissionBindingResponse.Data.Name, PermissionBindingName1);
            Assert.AreEqual(getPermissionBindingResponse.Data.Permission, PermissionType.Publisher);

            // list permission bindings
            var getAllPermissionBindingsBeforeDelete = await permissionBindingsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(getAllPermissionBindingsBeforeDelete);
            Assert.AreEqual(getAllPermissionBindingsBeforeDelete.Count, 2);

            // delete permission bindings
            await getPermissionBindingResponse.DeleteAsync(WaitUntil.Completed);
            await permissionBindingResponse2.DeleteAsync(WaitUntil.Completed);

            var getAllPermissionBindingsAfterDelete = await permissionBindingsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(getAllPermissionBindingsAfterDelete);
            Assert.AreEqual(getAllPermissionBindingsAfterDelete.Count, 0);

            //Delete client, client group and topic space
            await createClientResponse2.DeleteAsync(WaitUntil.Completed);
            await createClientGroupResponse2.DeleteAsync(WaitUntil.Completed);
            var listCientGroupAfterAllDeleted = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            var listClientsAfterAllDeleted = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listClientsAfterAllDeleted);
            Assert.AreEqual(listClientsAfterAllDeleted.Count, 0);
            Assert.IsNotNull(listCientGroupAfterAllDeleted);
            Assert.AreEqual(listCientGroupAfterAllDeleted.Count, 1);

            await topicSpaceResponse2.DeleteAsync(WaitUntil.Completed);
            var listTopicSpaceAfterAllDeleted = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listTopicSpaceAfterAllDeleted);
            Assert.AreEqual(listTopicSpaceAfterAllDeleted.Count, 0);

            // delete namespace and resource group
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
