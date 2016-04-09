using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trenbase.Interface
{
    public partial class form_trendbase : Form
    {
        private static string con = ConfigurationManager.ConnectionStrings["trendbase"].ToString();
        private static List<TicketModel> tickets;
        private static Hashtable averageTicketPrice;
        private static Hashtable totalTicketsPerDay; 
        public form_trendbase()
        {
            InitializeComponent();
            Thread thread = new Thread(InitialDataFetch);
            thread.Start();
            while (!thread.IsAlive)
            {
                buildSSASGraph(this.chart_SQLServerAnalyticalServices);
            }
        }

        public static void buildSSASGraph(Chart myChart)
        {
            myChart.Series.Add("Price");
            myChart.Series["Price"].ChartType = SeriesChartType.Line;
            for (int days = 1; days < 32; days++)
            {
                myChart.Series["Price"].Points.AddY(Convert.ToDouble(days), Convert.ToDouble(averageTicketPrice[days]));
            }

            myChart.Series["Price"].ChartArea = "ChartArea1";

        }

        #region Button Event Handers

        private void btn_SQLServerAnalyticalServices_Click(object sender, EventArgs e)
        {
            tc_graphArea.SelectedIndex = 0;
        }
        
        private void btn_AzureMachineLearning_Click(object sender, EventArgs e)
        {
            tc_graphArea.SelectedIndex = 01;
        }

        private void bnt_ownAlgorithm_Click(object sender, EventArgs e)
        {
            tc_graphArea.SelectedIndex = 2;
        }

        private void btn_exportTrends_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion 
        private static void InitialDataFetch()
        {
            Debug.WriteLine("Thread Started");
            averageTicketPrice = new Hashtable();
            totalTicketsPerDay = new Hashtable();

            using (SqlConnection trendbaseDb = new SqlConnection(con))
            {
                tickets = new List<TicketModel>();
                string query = "SELECT top 100000 ticketId, age, routeId, dateOfPurchase, railcardUsed, price, dateOfTravel FROM[dbo].[ticket] JOIN[dbo].[customer] ON [dbo].[ticket].[customerId] = [dbo].[customer].id WHERE dateOfPurchase > DATEADD(day, -30, GETDATE())";

                for (int i = 1; i < 32; i++)
                {
                    averageTicketPrice.Add(i,0.0m);
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
                            (Convert.ToDecimal(averageTicketPrice[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day]) +
                            Convert.ToDecimal(dataReader["price"]));
                        totalTicketsPerDay[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day] =
                            (Convert.ToInt32(totalTicketsPerDay[DateTime.Parse(dataReader["dateOfPurchase"].ToString()).Day]) + 1);
                    }
                }

                //dividing the total amount of ticket sales by theose of the day to give a daily ticket sales average.
                for (int i = 1 ; i < averageTicketPrice.Count + 1; i++)
                {
                    if (Convert.ToInt32(totalTicketsPerDay[i]) != 0)
                    {
                        averageTicketPrice[i] =
                                (Convert.ToDecimal(averageTicketPrice[i]) / Convert.ToInt32(totalTicketsPerDay[i]));
                        Debug.WriteLine(averageTicketPrice[i].ToString());

                    }
                }
               trendbaseDb.Close();
            }
        }
    }
}
