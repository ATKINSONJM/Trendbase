﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMember;

namespace RandomDataGenerator
{
    public class RandomDataGenerator
    {
        public static SqlConnection Con = new SqlConnection();
        public static int MaxCustomerId = 0;
        public static int MaxRouteId = 0;
        public static Random Rand = new Random();
         
        
        public static void Main(string[] args)
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["TrendbaseConnecctionString"].ToString();
            FindMaxRandRanges();
            GenerateData();
        }

        /// <summary>
        /// Method which will genreate data for people buying tickets and will act as a constant stream of data. 
        /// </summary>
        public static void GenerateData()
        {
            var data = TicketData(1000);

            DataTable table = new DataTable("Tickets");
            // construct DataTable
            table.Columns.Add(new DataColumn("ticketId", typeof(int)));
            table.Columns.Add(new DataColumn("customerId", typeof(int)));
            table.Columns.Add(new DataColumn("routeId", typeof(int)));
            table.Columns.Add(new DataColumn("dateOfPurchase", typeof(string)));
            table.Columns.Add(new DataColumn("railcardUsed", typeof(bool)));
            table.Columns.Add(new DataColumn("price", typeof(decimal)));
            table.Columns.Add(new DataColumn("dateOfTravel", typeof(string)));

            // note: if "id_state" is defined as an identity column in your DB,
            // row values for that column will be ignored during the bulk copy
            for(int dataRow = 0; dataRow < data.Count(); dataRow++)
            {
                table.Rows.Add(1,
                    data.ElementAt(dataRow).CustomerId,
                    data.ElementAt(dataRow).RouteId,
                    data.ElementAt(dataRow).DateOfPurchase,
                    data.ElementAt(dataRow).RailcardUsed,
                    data.ElementAt(dataRow).Price,
                    data.ElementAt(dataRow).DateOfTravel);
            }

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Con.ConnectionString))
            {
                bulkCopy.BulkCopyTimeout = 600; // in seconds
                bulkCopy.DestinationTableName = "ticket";
                bulkCopy.WriteToServer(table);
            }
            GenerateData();
        }

        public static void FindMaxRandRanges()
        {
            //finding the max userId
            using (SqlConnection connection = new SqlConnection(Con.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("select MAX(id) as id FROM [Trendbase].[dbo].[customer];", connection))
                {
                    connection.Open();
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MaxCustomerId = Convert.ToInt32(reader["id"]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Write(e.ToString() + "-" + e.InnerException.InnerException);
                    }
                }
            }
            //finding the maz routeId
            using (SqlConnection connection = new SqlConnection(Con.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("select MAX(route_id) as route_id FROM [Trendbase].[dbo].[routes];", connection))
                {
                    connection.Open();
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MaxRouteId = Convert.ToInt32(reader["route_id"]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Write(e.ToString() + "-" +  e.InnerException.InnerException);
                    }
                }
            }
        }
        
        public static IEnumerable<TicketModel> TicketData(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string NewDateOfPurchase = RandomDateGenerator("");
                var obj = new TicketModel
                {
                    CustomerId = Rand.Next(1, MaxCustomerId),
                    RouteId = Rand.Next(1, MaxRouteId),
                    RailcardUsed = Rand.Next(0, 2),
                    Price = Convert.ToDecimal(Rand.Next(10, 600)),
                    DateOfTravel = RandomDateGenerator(NewDateOfPurchase),
                    DateOfPurchase = NewDateOfPurchase,
                };
                yield return obj;
            }
        }

        public static string RandomDateGenerator(string inputDate)
        {
            //this is to ensure that the date of travel is always in the future of the date of purchase
            if (inputDate.Length == 0)
            {
                DateTime start = new DateTime(2015, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(Rand.Next(range)).ToString("yyyy/MM/dd");
            }
            else
            {
                var splitDate = inputDate.Split('/');
                DateTime start = new DateTime(Convert.ToInt32(splitDate[0]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[2]));
                int range = (DateTime.Today - start).Days;
                return start.AddDays(Rand.Next(range)).ToString("yyyy/MM/dd");
            }
        }
    }
}
