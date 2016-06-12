using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace CapstoneDeliveryService.Models
{

    
    public static class Configuration
    {
        //these variables will store the clientID and clientSecret
        //by reading them from the web.config
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        private static string accessToken;
        private static readonly Dictionary<string, string> config;

        static Configuration()
        {

            // Get a reference to the config
            config = ConfigManager.Instance.GetProperties();

            // Use OAuthTokenCredential to request an access token from PayPal
            accessToken = new OAuthTokenCredential(config).GetAccessToken();

            //var config = GetConfig();
            //ClientId = config["clientId"];
            //ClientSecret = config["clientSecret"];
        }

        //// getting properties from the web.config
        //public static Dictionary<string, string> GetConfig()
        //{
        //    return PayPal.Manager.ConfigManager.Instance.GetProperties();
        //}

        //private static string GetAccessToken()
        //{
        //    // getting accesstocken from paypal                
        //    string accessToken = new OAuthTokenCredential
        //(ClientId, ClientSecret, GetConfig()).GetAccessToken();

        //    return accessToken;
        //}

        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(accessToken);
            apiContext.Config = config;
            return apiContext;
        }
    }
}
//    public static class Configuration
//    {
//        //these variables will store the clientID and clientSecret
//        //by reading them from the web.config
//        public readonly static string ClientId;
//        public readonly static string ClientSecret;

//        static Configuration()
//        {
//            var config = GetConfig();
//            ClientId = config["clientId"];
//            ClientSecret = config["clientSecret"];
//        }

//        // getting properties from the web.config
//        //public static Dictionary<string, string> GetConfig()
//        //{
//        //    return PayPal.Manager.ConfigManager.Instance.GetProperties();
//        //}

//        //private static string GetAccessToken()
//        //{
//        //    // getting accesstocken from paypal                
//        //    string accessToken = new OAuthTokenCredential
//        //(ClientId, ClientSecret, GetConfig()).GetAccessToken();

//        //    return accessToken;
//        //}

//        public static APIContext GetAPIContext()
//        {
//            // return apicontext object by invoking it with the accesstoken
//            APIContext apiContext = new APIContext(accessToken);
//            apiContext.Config = GetConfig();
//            return apiContext;
//        }
//    }
//}