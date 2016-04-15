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
using System.Web.Http;
using Trendbase.Web.Models;

namespace Trendbase.Web.Controllers
{
    public class AzureMachineLearningController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string con = ConfigurationManager.ConnectionStrings["trendbase"].ToString();
            List<TicketModel> tickets = new List<TicketModel>(); 
            Hashtable averageTicketPrice = new Hashtable();
            Hashtable totalTicketsPerDay = new Hashtable();

            //declare array for graph and add the first item as the name for the graph series.
            Object[] ticketsForGraph = new Object[32];
            ticketsForGraph[0] = "Average Price";
            
            totalTicketsPerDay = new Hashtable();

            using (SqlConnection trendbaseDb = new SqlConnection(con))
            {
                string query =
                    "SELECT top 100000 ticketId, age, routeId, dateOfPurchase, railcardUsed, price, dateOfTravel FROM[dbo].[ticket] JOIN[dbo].[customer] ON [dbo].[ticket].[customerId] = [dbo].[customer].id WHERE dateOfPurchase > DATEADD(day, -31, GETDATE())";

                for (int i = 1; i < 32; i++)
                {
                    averageTicketPrice.Add(i, 0.0m);
                    totalTicketsPerDay.Add(i, 0);
                }

                SqlCommand queryCommand = new SqlCommand(query, trendbaseDb);
                trendbaseDb.Open();

                using (SqlDataReader dataReader = queryCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        tickets.Add(new TicketModel
                        {
                            Age = Convert.ToInt32(dataReader["age"].ToString()),
                            RouteId = Convert.ToInt32(dataReader["routeId"].ToString()),
                            DateOfPurchase = DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day,
                            RailcardUsed = Convert.ToInt32(dataReader["railCardUsed"]),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            DateOfTravel = dataReader["dateOfTravel"].ToString(),
                        });

                        averageTicketPrice[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day] =
                            (Convert.ToDecimal(
                                averageTicketPrice[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day]) +
                             Convert.ToDecimal(dataReader["price"]));
                        totalTicketsPerDay[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day] =
                            (Convert.ToInt32(
                                totalTicketsPerDay[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day]) + 1);
                    }
                }

                //dividing the total amount of ticket sales by theose of the day to give a daily ticket sales average.
                for (int i = 1; i < averageTicketPrice.Count + 1; i++)
                {
                    if (Convert.ToInt32(totalTicketsPerDay[i]) != 0)
                    {
                        averageTicketPrice[i] =
                            (Convert.ToDecimal(averageTicketPrice[i])/Convert.ToInt32(totalTicketsPerDay[i]));
                        Debug.WriteLine(averageTicketPrice[i].ToString());
                    }
                }
                //closes the connection
                trendbaseDb.Close();

                //load tickets ready for graph
                for (int i = 1; i < averageTicketPrice.Count + 1; i++)
                {
                    ticketsForGraph[i] = Convert.ToInt32(tickets[i].Price);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, ticketsForGraph);
        }
    }
}
