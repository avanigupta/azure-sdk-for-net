// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Avs;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs.Samples
{
    public partial class Sample_AvsPrivateCloudAddonResource
    {
        // Addons_Get_ArcReg
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_AddonsGetArcReg()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_Get_ArcReg.json
            // this example is just showing the usage of "Addons_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "arc";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonResource result = await avsPrivateCloudAddon.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_Get_HCX
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_AddonsGetHCX()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_Get_HCX.json
            // this example is just showing the usage of "Addons_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "hcx";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonResource result = await avsPrivateCloudAddon.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_Get_SRM
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_AddonsGetSRM()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_Get_SRM.json
            // this example is just showing the usage of "Addons_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "srm";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonResource result = await avsPrivateCloudAddon.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_Get_VR
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_AddonsGetVR()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_Get_VR.json
            // this example is just showing the usage of "Addons_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "vr";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonResource result = await avsPrivateCloudAddon.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_CreateOrUpdate_Arc
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_AddonsCreateOrUpdateArc()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_CreateOrUpdate_ArcReg.json
            // this example is just showing the usage of "Addons_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "arc";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonData data = new AvsPrivateCloudAddonData()
            {
                Properties = new AddonArcProperties()
                {
                    VCenter = "subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg_test/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vcenter",
                },
            };
            ArmOperation<AvsPrivateCloudAddonResource> lro = await avsPrivateCloudAddon.UpdateAsync(WaitUntil.Completed, data);
            AvsPrivateCloudAddonResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_CreateOrUpdate_HCX
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_AddonsCreateOrUpdateHCX()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_CreateOrUpdate_HCX.json
            // this example is just showing the usage of "Addons_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "hcx";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonData data = new AvsPrivateCloudAddonData()
            {
                Properties = new AddonHcxProperties("VMware MaaS Cloud Provider (Enterprise)"),
            };
            ArmOperation<AvsPrivateCloudAddonResource> lro = await avsPrivateCloudAddon.UpdateAsync(WaitUntil.Completed, data);
            AvsPrivateCloudAddonResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_CreateOrUpdate_SRM
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_AddonsCreateOrUpdateSRM()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_CreateOrUpdate_SRM.json
            // this example is just showing the usage of "Addons_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "srm";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonData data = new AvsPrivateCloudAddonData()
            {
                Properties = new AddonSrmProperties()
                {
                    LicenseKey = "41915178-A8FF-4A4D-B683-6D735AF5E3F5",
                },
            };
            ArmOperation<AvsPrivateCloudAddonResource> lro = await avsPrivateCloudAddon.UpdateAsync(WaitUntil.Completed, data);
            AvsPrivateCloudAddonResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_CreateOrUpdate_VR
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_AddonsCreateOrUpdateVR()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_CreateOrUpdate_VR.json
            // this example is just showing the usage of "Addons_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "vr";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            AvsPrivateCloudAddonData data = new AvsPrivateCloudAddonData()
            {
                Properties = new AddonVrProperties(1),
            };
            ArmOperation<AvsPrivateCloudAddonResource> lro = await avsPrivateCloudAddon.UpdateAsync(WaitUntil.Completed, data);
            AvsPrivateCloudAddonResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AvsPrivateCloudAddonData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Addons_Delete
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_AddonsDelete()
        {
            // Generated from example definition: specification/vmware/resource-manager/Microsoft.AVS/stable/2023-03-01/examples/Addons_Delete.json
            // this example is just showing the usage of "Addons_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AvsPrivateCloudAddonResource created on azure
            // for more information of creating AvsPrivateCloudAddonResource, please refer to the document of AvsPrivateCloudAddonResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "group1";
            string privateCloudName = "cloud1";
            string addonName = "srm";
            ResourceIdentifier avsPrivateCloudAddonResourceId = AvsPrivateCloudAddonResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, addonName);
            AvsPrivateCloudAddonResource avsPrivateCloudAddon = client.GetAvsPrivateCloudAddonResource(avsPrivateCloudAddonResourceId);

            // invoke the operation
            await avsPrivateCloudAddon.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}
