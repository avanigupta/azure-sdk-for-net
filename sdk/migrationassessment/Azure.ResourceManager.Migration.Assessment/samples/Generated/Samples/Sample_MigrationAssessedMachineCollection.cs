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
    public partial class Sample_MigrationAssessedMachineCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_AssessedMachinesOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AssessedMachinesOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AssessedMachinesOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentResource created on azure
            // for more information of creating MigrationAssessmentResource, please refer to the document of MigrationAssessmentResource
            string subscriptionId = "D8E1C413-E65F-40C0-8A7E-743D6B7A6AE9";
            string resourceGroupName = "rgopenapi";
            string projectName = "pavqtntysjn";
            string groupName = "smawqdmhfngray";
            string assessmentName = "qjlumxyqsitd";
            ResourceIdentifier migrationAssessmentResourceId = MigrationAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAssessmentResource migrationAssessment = client.GetMigrationAssessmentResource(migrationAssessmentResourceId);

            // get the collection of this MigrationAssessedMachineResource
            MigrationAssessedMachineCollection collection = migrationAssessment.GetMigrationAssessedMachines();

            // invoke the operation
            string assessedMachineName = "oqxjeheiipjmuo";
            MigrationAssessedMachineResource result = await collection.GetAsync(assessedMachineName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MigrationAssessedMachineData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_AssessedMachinesOperationsListByAssessmentMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AssessedMachinesOperations_ListByAssessment_MaximumSet_Gen.json
            // this example is just showing the usage of "AssessedMachinesOperations_ListByAssessment" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentResource created on azure
            // for more information of creating MigrationAssessmentResource, please refer to the document of MigrationAssessmentResource
            string subscriptionId = "D8E1C413-E65F-40C0-8A7E-743D6B7A6AE9";
            string resourceGroupName = "rgopenapi";
            string projectName = "sloqixzfjk";
            string groupName = "kjuepxerwseq";
            string assessmentName = "rhzcmubwrrkhtocsibu";
            ResourceIdentifier migrationAssessmentResourceId = MigrationAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAssessmentResource migrationAssessment = client.GetMigrationAssessmentResource(migrationAssessmentResourceId);

            // get the collection of this MigrationAssessedMachineResource
            MigrationAssessedMachineCollection collection = migrationAssessment.GetMigrationAssessedMachines();

            // invoke the operation and iterate over the result
            string filter = "sbkdovsfqldhdb";
            int? pageSize = 10;
            string continuationToken = "hbyseetshbplfkjmpjhsiurqgt";
            int? totalRecordCount = 25;
            await foreach (MigrationAssessedMachineResource item in collection.GetAllAsync(filter: filter, pageSize: pageSize, continuationToken: continuationToken, totalRecordCount: totalRecordCount))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationAssessedMachineData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_AssessedMachinesOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AssessedMachinesOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AssessedMachinesOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentResource created on azure
            // for more information of creating MigrationAssessmentResource, please refer to the document of MigrationAssessmentResource
            string subscriptionId = "D8E1C413-E65F-40C0-8A7E-743D6B7A6AE9";
            string resourceGroupName = "rgopenapi";
            string projectName = "pavqtntysjn";
            string groupName = "smawqdmhfngray";
            string assessmentName = "qjlumxyqsitd";
            ResourceIdentifier migrationAssessmentResourceId = MigrationAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAssessmentResource migrationAssessment = client.GetMigrationAssessmentResource(migrationAssessmentResourceId);

            // get the collection of this MigrationAssessedMachineResource
            MigrationAssessedMachineCollection collection = migrationAssessment.GetMigrationAssessedMachines();

            // invoke the operation
            string assessedMachineName = "oqxjeheiipjmuo";
            bool result = await collection.ExistsAsync(assessedMachineName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_AssessedMachinesOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AssessedMachinesOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AssessedMachinesOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAssessmentResource created on azure
            // for more information of creating MigrationAssessmentResource, please refer to the document of MigrationAssessmentResource
            string subscriptionId = "D8E1C413-E65F-40C0-8A7E-743D6B7A6AE9";
            string resourceGroupName = "rgopenapi";
            string projectName = "pavqtntysjn";
            string groupName = "smawqdmhfngray";
            string assessmentName = "qjlumxyqsitd";
            ResourceIdentifier migrationAssessmentResourceId = MigrationAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAssessmentResource migrationAssessment = client.GetMigrationAssessmentResource(migrationAssessmentResourceId);

            // get the collection of this MigrationAssessedMachineResource
            MigrationAssessedMachineCollection collection = migrationAssessment.GetMigrationAssessedMachines();

            // invoke the operation
            string assessedMachineName = "oqxjeheiipjmuo";
            NullableResponse<MigrationAssessedMachineResource> response = await collection.GetIfExistsAsync(assessedMachineName);
            MigrationAssessedMachineResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MigrationAssessedMachineData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
