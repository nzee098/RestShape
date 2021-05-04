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

        public static System.Timers.Timer timer = new System.Timers.Timer(  1000); //24h
        // public static string mainHostCamera = "https://192.168.1.40:7001"; // link cam gs
        // public static string mainHostCamera = "http://127.31.3.251:7001"; // link cam nv
        public static string mainHostCamera = "http://localhost:7001";   // link cam nv
        public static string urlBookingData = "https://dev-ni-operation-gateway.novaland.com.vn/api/v1/booking-room";
        public static string apiUserNameCamera = "adminapi";
        public static string apiPasswordCamera = "adminapi123";
        public static string idCamPhongHop3 = "01545f02-922f-9fa9-5769-41781d6ecd03";
        public static string idCamPhongHop3_1 = "aaac6172-b2f7-1ea6-a099-519d751ffcdc";
        public static string idCamPhongHop4 = "c217acf2-6906-786f-2e32-0b34f8c37003";
        public static string idCamPhongHop4_1 = "d9baff15-f4f0-561e-1e99-038df483cf3f";

        public static bool showMenu = true;
        //public static List<CameraExClass.Root> listCameraEx;
        public static List<BookingApiResponse.Root> ListBooking;



        static void Main(string[] args)
        {

     

            while (showMenu)
            {
                DisplayMenu();
            }
        }


        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // do action here
            addBookmark();
        
        }

        static public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("BookMark NX Camera Manage");
            Console.WriteLine();
           
            Console.WriteLine("1. Run");
            Console.WriteLine("2. Config Info");
            Console.WriteLine("3. Exit");
            string result = Console.ReadLine();

            switch (result)
            {
        
                case "1":
                    timer.Enabled = true;
                    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                    timer.Start();
                  //  Console.WriteLine("Get Bookmark Data Successfull");
                    Console.ReadLine();
                    break;
                case "2":
                    configInfo();
                    Console.ReadLine();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    break;

            }
        }

        public static void getBookingData()
        {
  
            IRestClient restClient = new RestClient(urlBookingData+ "?StartTime="+ getCurrentDateStart() + "&EndTime="+ getCurrentDateEnd());

            IRestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Q.BThOYoGjVv~p5.l.HWK2l.Jcamerax6x2762w");
            request.AddHeader("Content-Type", "application/json");


            IRestResponse restResponse = restClient.Get(request);

            //Resend the request if we get 401
            int numericStatusCode = (int)restResponse.StatusCode;
            if (numericStatusCode == 401)
            {
                var redirectedClient = new RestClient(restResponse.ResponseUri.ToString());
                IRestResponse newResponse = redirectedClient.Execute(request);
                Console.WriteLine(newResponse.ResponseStatus);
            }
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code :" + restResponse.StatusCode);
                if (ListBooking.Count>0)
                {
                    ListBooking.Clear();
                }
                ListBooking = JsonConvert.DeserializeObject<List<BookingApiResponse.Root>>(restResponse.Content);
             //  Console.WriteLine(ListBooking[0].StartTime);
            }
         

        }
        public static void configInfo()
        {
            Console.WriteLine("Main Host NxCamera: "+ mainHostCamera);
            Console.WriteLine("Username NxCamera: " + apiUserNameCamera);
            Console.WriteLine("Password NxCamera: " + apiPasswordCamera);
            Console.WriteLine("Main Host BookingData: " + urlBookingData);
            Console.WriteLine("ID Cam Phòng Họp 3: " + idCamPhongHop3);
            Console.WriteLine("ID Cam Phòng Họp 3_1: " + idCamPhongHop3_1);
            Console.WriteLine("ID Cam Phòng Họp 4: " + idCamPhongHop4);
            Console.WriteLine("ID Cam Phòng Họp 4_1: " + idCamPhongHop4_1);
            Console.WriteLine("List Data: " + ListBooking.Count);
         //   Console.WriteLine("List Cam: " + listCameraEx.Count);

            Console.ReadLine();
        }
        //public static void getListCamnerOnSever()
        //{
        //    string getUrl = mainHostCamera + "/ec2/getCamerasEx";
        //    Console.WriteLine("Hello World!");

        //    IRestClient restClient = new RestClient();
        //    restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        //    restClient.Authenticator = new HttpBasicAuthenticator(apiUserNameCamera, apiPasswordCamera);
        //    IRestRequest restRequest = new RestRequest(getUrl);
        //    IRestResponse restResponse = restClient.Get(restRequest);
        //    if (restResponse.IsSuccessful)
        //    {
        //        Console.WriteLine("Status Code :" + restResponse.StatusCode);
        //        Console.WriteLine("lenght :"+restResponse.Content.Length);
        //        Console.WriteLine(restResponse.Content);
               
        //        listCameraEx = JsonConvert.DeserializeObject<List<CameraExClass.Root>>(restResponse.Content);
        //        Console.WriteLine(listCameraEx[0].id);
        //    }
        //}

        public static void addBookmark()
        {

            if (ListBooking.Count != 0)
                // chạy theo list bookmark
                for (int i = 0; i < ListBooking.Count; i++)
                {
                    if (ListBooking[i].StatusCode == "Approved")

                        if (ListBooking[i].ResourceId == "608640e06f67970d379dbb52")
                        {
                            //  case "5fd1a31791ccac0b95adc597": // phòng 3
                            getAddBookmarkCall(idCamPhongHop3, ListBooking[i].Title, ListBooking[i].StartTime, ListBooking[i].EndTime, ListBooking[i].Description, "");
                            getAddBookmarkCall(idCamPhongHop3_1, ListBooking[i].Title, ListBooking[i].StartTime, ListBooking[i].EndTime, ListBooking[i].Description, "");
                        }
                        else
                        {
                            if (ListBooking[i].ResourceId == "6086418d6f67970d379dbeb3")
                            {
                                getAddBookmarkCall(idCamPhongHop4, ListBooking[i].Title, ListBooking[i].StartTime, ListBooking[i].EndTime, ListBooking[i].Description, "");
                                getAddBookmarkCall(idCamPhongHop4_1, ListBooking[i].Title, ListBooking[i].StartTime, ListBooking[i].EndTime, ListBooking[i].Description, "");
                            }
                        }
                }
            else
            {
                //chỗ này
                getBookingData();
                addBookmark();
            }
        }

        //        "StartTime": "2020-11-10T05:20:00.000Z",
        //"EndTime": "2020-11-10T05:30:00.000Z",
        public static void getAddBookmarkCall(string cameraId, string bookmarkName, string timeStart, string timeEnd, string description, string tag)
        {
            // string cameraId, string bookmarkName, int startTime, int duration, string description,string tag, CameraExClass camera
            long timeS = parseDate(timeStart);
            long timeE = parseDate(timeEnd);
            long durations = timeE - timeS;

            String guid = System.Guid.NewGuid().ToString(); // guid is automatic initialization 
            String url = mainHostCamera + "/ec2/bookmarks/add?guid=" + guid + "&cameraId=" + cameraId +
                 "&name=" + bookmarkName + "&description=" + description + "&startTime=" + timeS + "&duration=" + durations + "&tag=" + tag;
            Console.WriteLine(url);

            IRestClient restClient = new RestClient();
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            restClient.Authenticator = new HttpBasicAuthenticator(apiUserNameCamera, apiPasswordCamera);
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

        public static string getCurrentDateStart()
        {
            DateTime utcDate = DateTime.UtcNow;
            string a = utcDate.ToString("yyyy-MM-dd");
            String b = a + "T00:00:00.000Z";
            return b;
        }
        public static string getCurrentDateEnd()
        {
            DateTime utcDate = DateTime.UtcNow;
            string a = utcDate.ToString("yyyy-MM-dd");
             String b = a+ "T23:59:59.000Z";
            return b;
        }


    }
}
