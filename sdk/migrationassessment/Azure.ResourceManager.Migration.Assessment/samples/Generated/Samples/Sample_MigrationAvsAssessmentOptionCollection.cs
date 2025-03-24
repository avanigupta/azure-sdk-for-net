// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Samples
{
    public partial class Sample_MigrationAvsAssessmentOptionCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_AvsAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationAvsAssessmentOptionResource
            MigrationAvsAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationAvsAssessmentOptions();

            // invoke the operation
            string avsAssessmentOptionsName = "default";
            MigrationAvsAssessmentOptionResource result = await collection.GetAsync(avsAssessmentOptionsName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MigrationAvsAssessmentOptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_AvsAssessmentOptionsOperationsListByAssessmentProjectMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentOptionsOperations_ListByAssessmentProject_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentOptionsOperations_ListByAssessmentProject" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationAvsAssessmentOptionResource
            MigrationAvsAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationAvsAssessmentOptions();

            // invoke the operation and iterate over the result
            await foreach (MigrationAvsAssessmentOptionResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationAvsAssessmentOptionData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_AvsAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationAvsAssessmentOptionResource
            MigrationAvsAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationAvsAssessmentOptions();

            // invoke the operation
            string avsAssessmentOptionsName = "default";
            bool result = await collection.ExistsAsync(avsAssessmentOptionsName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_AvsAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationAvsAssessmentOptionResource
            MigrationAvsAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationAvsAssessmentOptions();

            // invoke the operation
            string avsAssessmentOptionsName = "default";
            NullableResponse<MigrationAvsAssessmentOptionResource> response = await collection.GetIfExistsAsync(avsAssessmentOptionsName);
            MigrationAvsAssessmentOptionResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationAvsAssessmentOptionData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
