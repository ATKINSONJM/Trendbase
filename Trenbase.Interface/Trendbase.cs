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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private static Chart SSASChart;
        private static Chart AMLChart;
        private static Chart TBChart;
        public form_trendbase()
        {
            InitializeComponent();

            //create timer for updating graphs
            System.Timers.Timer updateDataTimer = new System.Timers.Timer();
            updateDataTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            updateDataTimer.Interval = 60000;
            updateDataTimer.Enabled = true;
            

            //start thread for retreiving initial data
            Thread thread = new Thread(DataFetch);
            thread.Start();
            while(thread.IsAlive)
            {
                lbl_status.Text = ("Retrieving Graph Data.");
                lbl_status.Text = ("Retrieving Graph Data..");
                lbl_status.Text = ("Retrieving Graph Data...");
            }
            
            lbl_status.Text = ("Data Retrieved.");
            GenerateAllCharts();
            updateDataTimer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            UpdateAllGraphs(this);
        }

        #region ManageCharts
        private void GenerateAllCharts()
        {
            CreateChartsInitial("SSIS");
            CreateChartsInitial("AML");
            CreateChartsInitial("TB");
        }

        private void CreateChartsInitial(string trendMethod)
        {
            switch (trendMethod)
            {
                case "SSIS":

                    //Chart Settings
                    SSASChart = new Chart();
                    ChartArea myChartArea = new ChartArea("ChartArea1");
                    SSASChart.ChartAreas.Add(myChartArea);

                    // Set title.
                    SSASChart.Titles.Add("SQL Server Analytical Services");

                    // Add series.
                    Series seriesPrice = SSASChart.Series.Add("Price");
                    seriesPrice.ChartArea = "ChartArea1";
                    seriesPrice.Enabled = true;
                    seriesPrice.ChartType = SeriesChartType.Line;
                    seriesPrice.Color = Color.Blue;

                    //add Predicted Series
                    Series seriesPredicted = SSASChart.Series.Add("Predicted");
                    seriesPredicted.ChartArea = "ChartArea1";
                    seriesPredicted.Enabled = true;
                    seriesPredicted.ChartType = SeriesChartType.Line;
                    seriesPredicted.Color = Color.Green;

                    for (int i = 1; i < averageTicketPrice.Count-7; i++)
                    {
                        // Add point.
                        seriesPrice.Points.AddXY(i,Convert.ToInt32(averageTicketPrice[i]));
                    }
                    for (int i = (averageTicketPrice.Count -8); i < averageTicketPrice.Count; i++)
                    {
                        // Add point.
                        seriesPredicted.Points.AddXY(i, Convert.ToInt32(averageTicketPrice[i]));
                    }
                    tp_SSAS.Controls.Add(SSASChart);
                    SSASChart.Width = SSASChart.Parent.Width;
                    SSASChart.Width = SSASChart.Parent.Height;
                    tp_SSAS.Update();

                    break;
                case "AML":
                    //DO LOGIC FOR AML GRAPH
                    Debug.WriteLine("AML");
                    break;
                case "TB":
                    //DO LOGIC FOR AWS GRAPH
                    Debug.WriteLine("TB");
                    break;
            }
        }


        public static void UpdateAllGraphs(form_trendbase thisForm)
        {
            Thread dataFetchThread = new Thread(DataFetch);
            dataFetchThread.Start();
            while (dataFetchThread.IsAlive)
            {
                
            }
            thisForm.Invoke((MethodInvoker)delegate {
                  UpdateSSASGraph(thisForm); // runs on UI thread
            });
        }

        public static void UpdateSSASGraph(form_trendbase thisForm)
        {
            
            SSASChart.Series.Clear();
            Series seriesPrice = SSASChart.Series.Add("Price");
            seriesPrice.ChartArea = "ChartArea1";
            seriesPrice.Enabled = true;
            seriesPrice.ChartType = SeriesChartType.Line;
            seriesPrice.Color = Color.Blue;

            //add Predicted Series
            Series seriesPredicted = SSASChart.Series.Add("Predicted");
            seriesPredicted.ChartArea = "ChartArea1";
            seriesPredicted.Enabled = true;
            seriesPredicted.ChartType = SeriesChartType.Line;
            seriesPredicted.Color = Color.Green;

            for (int i = 1; i < averageTicketPrice.Count - 7; i++)
            {
                // Add point.
                seriesPrice.Points.AddXY(i, Convert.ToInt32(averageTicketPrice[i]));
            }
            for (int i = (averageTicketPrice.Count - 8); i < averageTicketPrice.Count; i++)
            {
                // Add point.
                seriesPredicted.Points.AddXY(i, Convert.ToInt32(averageTicketPrice[i]));
            }

            SSASChart.Invalidate();
            SSASChart.Update();
            SSASChart.Refresh();

        }
        #endregion 

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
        private static void DataFetch()
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
