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
        public static string AppServicePlanRG = "Ocelot";
        public static string AppServicePlan = "DemosWin";
        public static string DbImage = "https://cmakers.blob.core.windows.net/images/dbImage.bacpac";
        public static string StorageKey = "";
        public static string DbConnectionKey = "Database:Connection";
        public static string DbConnectionValue = "Server=tcp:cmakers.database.windows.net,1433;Initial Catalog=t-{0};Persist Security Info=False;User ID={1};Password={2};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static string TenantKey = "TenantID";
        public static string CustomDomain = "demo.cloudmakers.xyz";
        public static string WebAppImage = "https://cmakers.blob.core.windows.net/images/webApp.zip?st=2019-04-26T20%3A48%3A43Z&se=2020-04-27T20%3A48%3A00Z&sp=r&sv=2018-03-28&sr=b&sig=2%2BymnYEA8eGfY4lRTpBRjmvIQW5qOSJbosFgc9fPz9c%3D";
        public static int DNSTtl = 60;
        public static string EventGridTopicEndpoint = "https://cmakers.westeurope-1.eventgrid.azure.net/api/events";
        public static string EventGridTopicKey = "";
        public static string ServiceBus = "Endpoint=sb://cmakers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=";
        public static string ServiceBusTopic = "acquisition";
        public static string ServiceBusSubscription = "AzureProvisioner";
        public static string AzureClientID = "25e992fd-bdcf-4c52-ba29-bdef95c507ac";
        public static string AzureClientSecret = "";
        public static string AzureTenantId = "";
        public static string AzureSubscription = "";


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
