// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Migration.Assessment.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Samples
{
    public partial class Sample_MigrationAvsAssessmentResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_AvsAssessmentsOperationsGetMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentsOperations_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentsOperations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAvsAssessmentResource created on azure
            // for more information of creating MigrationAvsAssessmentResource, please refer to the document of MigrationAvsAssessmentResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            string groupName = "kuchatur-test";
            string assessmentName = "asm2";
            ResourceIdentifier migrationAvsAssessmentResourceId = MigrationAvsAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAvsAssessmentResource migrationAvsAssessment = client.GetMigrationAvsAssessmentResource(migrationAvsAssessmentResourceId);

            // invoke the operation
            MigrationAvsAssessmentResource result = await migrationAvsAssessment.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MigrationAvsAssessmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_AvsAssessmentsOperationsDeleteMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentsOperations_Delete_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentsOperations_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAvsAssessmentResource created on azure
            // for more information of creating MigrationAvsAssessmentResource, please refer to the document of MigrationAvsAssessmentResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            string groupName = "kuchatur-test";
            string assessmentName = "asm2";
            ResourceIdentifier migrationAvsAssessmentResourceId = MigrationAvsAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAvsAssessmentResource migrationAvsAssessment = client.GetMigrationAvsAssessmentResource(migrationAvsAssessmentResourceId);

            // invoke the operation
            await migrationAvsAssessment.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_AvsAssessmentsOperationsCreateMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentsOperations_Create_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentsOperations_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAvsAssessmentResource created on azure
            // for more information of creating MigrationAvsAssessmentResource, please refer to the document of MigrationAvsAssessmentResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            string groupName = "kuchatur-test";
            string assessmentName = "asm2";
            ResourceIdentifier migrationAvsAssessmentResourceId = MigrationAvsAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAvsAssessmentResource migrationAvsAssessment = client.GetMigrationAvsAssessmentResource(migrationAvsAssessmentResourceId);

            // invoke the operation
            MigrationAvsAssessmentData data = new MigrationAvsAssessmentData
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                FailuresToTolerateAndRaidLevel = FttAndRaidLevel.Ftt1Raid1,
                VcpuOversubscription = 4,
                NodeType = AssessmentAvsNodeType.Av36,
                ReservedInstance = AssessmentReservedInstance.RI3Year,
                MemOvercommit = 1,
                DedupeCompression = 1.5,
                IsStretchClusterEnabled = true,
                AzureLocation = new AzureLocation("EastUs"),
                AzureOfferCode = AssessmentOfferCode.MSAZR0003P,
                Currency = AssessmentCurrency.USD,
                ScalingFactor = 1,
                Percentile = PercentileOfUtilization.Percentile95,
                TimeRange = AssessmentTimeRange.Day,
                PerfDataStartOn = DateTimeOffset.Parse("2023-09-25T13:35:56.5671462Z"),
                PerfDataEndOn = DateTimeOffset.Parse("2023-09-26T13:35:56.5671462Z"),
                DiscountPercentage = 0,
                SizingCriterion = AssessmentSizingCriterion.AsOnPremises,
            };
            ArmOperation<MigrationAvsAssessmentResource> lro = await migrationAvsAssessment.UpdateAsync(WaitUntil.Completed, data);
            MigrationAvsAssessmentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MigrationAvsAssessmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task DownloadUrl_AvsAssessmentsOperationsDownloadUrlMaximumSetGen()
        {
            // Generated from example definition: specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/stable/2023-03-15/examples/AvsAssessmentsOperations_DownloadUrl_MaximumSet_Gen.json
            // this example is just showing the usage of "AvsAssessmentsOperations_DownloadUrl" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MigrationAvsAssessmentResource created on azure
            // for more information of creating MigrationAvsAssessmentResource, please refer to the document of MigrationAvsAssessmentResource
            string subscriptionId = "4bd2aa0f-2bd2-4d67-91a8-5a4533d58600";
            string resourceGroupName = "ayagrawrg";
            string projectName = "app18700project";
            string groupName = "kuchatur-test";
            string assessmentName = "asm2";
            ResourceIdentifier migrationAvsAssessmentResourceId = MigrationAvsAssessmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, projectName, groupName, assessmentName);
            MigrationAvsAssessmentResource migrationAvsAssessment = client.GetMigrationAvsAssessmentResource(migrationAvsAssessmentResourceId);

            // invoke the operation
            BinaryData body = BinaryData.FromObjectAsJson(new object());
            ArmOperation<AssessmentReportDownloadUri> lro = await migrationAvsAssessment.DownloadUrlAsync(WaitUntil.Completed, body);
            AssessmentReportDownloadUri result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
