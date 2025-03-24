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
    public partial class Sample_MigrationSqlAssessmentOptionCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_SqlAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/SqlAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "SqlAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "rgmigrate";
            string projectName = "fci-test6904project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationSqlAssessmentOptionResource
            MigrationSqlAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationSqlAssessmentOptions();

            // invoke the operation
            string assessmentOptionsName = "default";
            MigrationSqlAssessmentOptionResource result = await collection.GetAsync(assessmentOptionsName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MigrationSqlAssessmentOptionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_SqlAssessmentOptionsOperationsListByAssessmentProjectMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/SqlAssessmentOptionsOperations_ListByAssessmentProject_MaximumSet_Gen.json
            // this example is just showing the usage of "SqlAssessmentOptionsOperations_ListByAssessmentProject" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "rgmigrate";
            string projectName = "fci-test6904project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationSqlAssessmentOptionResource
            MigrationSqlAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationSqlAssessmentOptions();

            // invoke the operation and iterate over the result
            await foreach (MigrationSqlAssessmentOptionResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationSqlAssessmentOptionData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_SqlAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/SqlAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "SqlAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "rgmigrate";
            string projectName = "fci-test6904project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationSqlAssessmentOptionResource
            MigrationSqlAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationSqlAssessmentOptions();

            // invoke the operation
            string assessmentOptionsName = "default";
            bool result = await collection.ExistsAsync(assessmentOptionsName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_SqlAssessmentOptionsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/SqlAssessmentOptionsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "SqlAssessmentOptionsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentProjectResource created on azure
            // for more information of creating MigrationAssessmentProjectResource, please refer to the document of MigrationAssessmentProjectResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "rgmigrate";
            string projectName = "fci-test6904project";
            ResourceIdentifier migrationAssessmentProjectResourceId = MigrationAssessmentProjectResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName);
            MigrationAssessmentProjectResource migrationAssessmentProject = client.GetMigrationAssessmentProjectResource(migrationAssessmentProjectResourceId);

            // get the collection of this MigrationSqlAssessmentOptionResource
            MigrationSqlAssessmentOptionCollection collection = migrationAssessmentProject.GetMigrationSqlAssessmentOptions();

            // invoke the operation
            string assessmentOptionsName = "default";
            NullableResponse<MigrationSqlAssessmentOptionResource> response = await collection.GetIfExistsAsync(assessmentOptionsName);
            MigrationSqlAssessmentOptionResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationSqlAssessmentOptionData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
