using Newtonsoft.Json;
using RestShape.Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace RestShape
{
    class Program
    {

        public static string mainHost = "https://192.168.1.40:7001";
        public static string apiUserName = "adminapi";
        public static string apiPassword = "adminapi123";
        public static bool showMenu = true;
        public static List<CameraExClass.Root> listCameraEx;


        static void Main(string[] args)
        {

            while (showMenu)
            {
                DisplayMenu();
            }
        }


        static public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("BookMark NX Camera Manage");
            Console.WriteLine();
            Console.WriteLine("1. Get List Camera On Sever");
            Console.WriteLine("2. Addbookmark");
            Console.WriteLine("3. Get Bookmark Data From NovaLand Apis");
            Console.WriteLine("4. Config Info");
            Console.WriteLine("5. Exit");
            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    getListCamnerOnSever();
                    Console.WriteLine("Get List Successfull");
                    Console.WriteLine("List Length:" + listCameraEx.Count);
                    Console.ReadLine();
                    break;
                case "2":
                    addBookmark();
                    Console.WriteLine("Addbookmark Successfull");
                    break;
                case "3":
                    getBookingData();
                    Console.WriteLine("Get Bookmark Data Successfull");
                    Console.ReadLine();
                    break;
                case "4":
                    configInfo();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    break;

            }
        }

        public static void getBookingData()
        {
          
        }
        public static void configInfo()
        {
            Console.WriteLine("Main Host: "+ mainHost);
            Console.WriteLine("Username: "+ apiUserName);
            Console.WriteLine("Password: "+ apiPassword);
            Console.ReadLine();
        }
        public static void getListCamnerOnSever()
        {
            string getUrl = mainHost + "/ec2/getCamerasEx";
            Console.WriteLine("Hello World!");

            IRestClient restClient = new RestClient();
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            restClient.Authenticator = new HttpBasicAuthenticator(apiUserName, apiPassword);
            IRestRequest restRequest = new RestRequest(getUrl);
            IRestResponse restResponse = restClient.Get(restRequest);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code :" + restResponse.StatusCode);
                listCameraEx = JsonConvert.DeserializeObject<List<CameraExClass.Root>>(restResponse.Content);
                Console.WriteLine(listCameraEx[0].id);
            }
        }

        public static void addBookmark()
        {
            if (listCameraEx == null)
            {
                getListCamnerOnSever();
            }
            else
            {
                for (int i = 0; i < listCameraEx.Count; i++)
                {
                    getAddBookmarkCall(listCameraEx[i].id, "asd", "2021-04-14T06:00:00.000Z", "2021-04-14T07:00:00.000Z", "asdgas", "asdas");
                }
            }

        }

        public static void getAddBookmarkCall(string cameraId, string bookmarkName, string timeStart, string timeEnd, string description, string tag)
        {
            // string cameraId, string bookmarkName, int startTime, int duration, string description,string tag, CameraExClass camera
            long timeS = parseDate(timeStart);
            long timeE = parseDate(timeEnd);
            long durations = timeE - timeS;

            String guid = System.Guid.NewGuid().ToString(); // guid is automatic initialization 
            string camid = "";

            for (int i = 1; i < listCameraEx[0].id.Length - 1; i++)
            {
                camid += listCameraEx[0].id[i];
            }
   
            String url = mainHost + "/ec2/bookmarks/add?guid=" + guid + "&cameraId=" + camid +
                 "&name=" + bookmarkName + "&description=" + description + "&startTimeMs=" + timeStart + "&durationMs=" + durations + "&tag=" + tag;

            Console.WriteLine(url);

            IRestClient restClient = new RestClient();
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            restClient.Authenticator = new HttpBasicAuthenticator(apiUserName, apiPassword);
            IRestRequest restRequest = new RestRequest(url);
            IRestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.IsSuccessful);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine(restResponse.StatusCode);
                Console.WriteLine(restResponse.ErrorMessage);
                DisplayMenu();
            }

        }
        public static long parseDate(String Date)
        {
            DateTime dateSt = DateTime.Parse(Date);
            long milisecondTime = (long)(dateSt.Subtract(new DateTime(1970, 1, 1, 14, 0, 0, 0)).TotalSeconds * 1000);
            return milisecondTime;
        }
    }
}
