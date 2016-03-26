using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataManager
{

    public partial class DataManager : ServiceBase
    {
        public int counter = 0;
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public DataManager()
        {
            InitializeComponent();

            //initialise a timer to run the etl
            System.Timers.Timer timer = new System.Timers.Timer {Interval = 10000};
            // 10 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            using (StreamWriter streamWriter = File.AppendText(path + @"\test.txt"))
                streamWriter.WriteLine("Number: {0}", counter);
        }

        protected override void OnStart(string[] args)
        {
            //creates a file if one doesnt exist
            if (!File.Exists(path + @"\test.txt"))
            {
                // Create a file to write to.
                using (StreamWriter streamWriter = File.CreateText(path + @"\test.txt"))
                {
                    streamWriter.WriteLine("test");
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
