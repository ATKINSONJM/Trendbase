using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Trendbase.Web.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Trendbase.Web.Controllers
{
    public class HomeController : Controller
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public ActionResult Index()
        {
          ViewBag.Title = "Home Page";
          return View();
        }

        public HttpResponseMessage Post(object[] data)
        {
            Thread thread = new Thread(() => InsertDataForExport(data));
            thread.Start();
            while (thread.IsAlive)
            {
                Console.WriteLine("Exporting Trends");
            }
            
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public static void InsertDataForExport(object[] data)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("trendDatabase");

            var document = new BsonDocument
            {
                {
                    "trendRecord", new BsonDocument
                    {
                        
                        {"1",data[1].ToString()},
                        {"2",data[2].ToString()},
                        {"3",data[3].ToString()},
                        {"4",data[4].ToString()},
                        {"5",data[5].ToString()},
                        {"6",data[6].ToString()},
                        {"7",data[7].ToString()},
                        {"8",data[8].ToString()},
                        {"9",data[9].ToString()},
                        {"10",data[10].ToString()},
                        {"11",data[11].ToString()},
                        {"12",data[12].ToString()},
                        {"13",data[13].ToString()},
                        {"14",data[14].ToString()},
                        {"15",data[15].ToString()},
                        {"16",data[16].ToString()},
                        {"17",data[17].ToString()},
                        {"18",data[18].ToString()},
                        {"19",data[19].ToString()},
                        {"20",data[20].ToString()},
                        {"21",data[21].ToString()},
                        {"22",data[22].ToString()},
                        {"23",data[23].ToString()},
                        {"24",data[24].ToString()},
                        {"25",data[25].ToString()},
                        {"26",data[126].ToString()},
                        {"27",data[27].ToString()},
                        {"28",data[28].ToString()},
                        {"29",data[29].ToString()},
                        {"30",data[30].ToString()},
                    }
                }
            };
            
            var collection = _database.GetCollection<BsonDocument>("Trends");
            collection.InsertOne(document);
        }

        public static void DataImport()
        {
            //string ETLPackageFileLocation;
            //Package ETLpackage;
            //Microsoft.SqlServer.Dts.Runtime.Application application;
            //DTSExecResult EltPackageResults;
        } 

        public ActionResult SsasService()
        {
            return View();
        }

        public ActionResult TrendbaseService()
        {
            return View();
        }

        public ActionResult AzureMachineLearningService()
        {
            return View();
        }
    }
}
