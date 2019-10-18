using System;
using System.Collections.Generic;
using System.Text;

namespace CMakersDryRun
{
    public static class S
    {
        public static string SqlServer = "cmakers";
        public static string SqlUser = "cmakersAdmin";
        public static string SqlPassword = "";
        public static string SqlPool = "CMakersBasic";
        public static string ResourceGroup = "CMakers";
        public static string AppServicePlanRG = "Demos";
        public static string AppServicePlan = "DemosWin";
        public static string DbImage = "https://cmakers.blob.core.windows.net/images/dbImage.bacpac";
        public static string StorageKey = "";
        public static string DbConnectionKey = "Database:Connection";
        public static string DbConnectionValue = "Server=tcp:cmakers.database.windows.net,1433;Initial Catalog=t-{0};Persist Security Info=False;User ID={1};Password={2};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static string TenantKey = "TenantID";
        public static string CustomDomainRG = "CloudMakers";
        public static string CustomDomain = "demo.cloudmakers.xyz";
        public static string WebAppImage = "https://cmakers.blob.core.windows.net/images/webApp.zip?sp=r&st=2019-10-18T09:56:15Z&se=2019-10-27T18:56:15Z&spr=https&sv=2019-02-02&sr=b&sig=Cg0ZmjElpdgSxOu3W4wHBQ6%2FC6KwFJnMD4TYZiLbnKA%3D";
        public static int DNSTtl = 60;
        public static string EventGridTopicEndpoint = "https://cmakers.westeurope-1.eventgrid.azure.net/api/events";
        public static string EventGridTopicKey = "";
        public static string ServiceBus = "Endpoint=sb://cmakers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=";
        public static string ServiceBusTopic = "acquisition";
        public static string ServiceBusSubscription = "AzureProvisioner";
        public static string AzureClientID = "";
        public static string AzureClientSecret = "";
        public static string AzureTenantId = "";
        public static string AzureSubscription = "";
        public static string PfxPassword = "cmakers";


    }

    public class Rootobject
    {
        public string RequestID { get; set; }
        public string TenantName { get; set; }
    }

    public class DataModel
    {
        public string URL { get; set; }
    }
}
