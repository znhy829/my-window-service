using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Instar_Project
{

    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CreateFolder();
            WriteInfo("Service Begins");
            string current_date = DateTime.Now.ToString("AUyyMMdd"); ;
            WriteInfo(current_date);
            if (Check())
            {
                WriteInfo("File exist,starting the external process");
                int pos = RandIntGenerator();
                if (pos >= 1)
                {
                    WriteInfo("error");
                }
            }

            if (!KeywordSearch())
            {
                WriteInfo("Failure email sent");
            }
            else
            {
                WriteInfo("Success email sent");
            }
        }

        protected override void OnStop()
        {
            WriteInfo("Serivce Ends");
        }

        public void CreateFolder()
        {
            string current_year = DateTime.Now.ToString("yyyy");
            string folderPath1 = @"C:\Users\yzhu\Desktop\" + current_year; //2023 -> 202301
            if (!Directory.Exists(folderPath1))
            {
                Directory.CreateDirectory(folderPath1);
            }

            string current_year_date = DateTime.Now.ToString("yyyyMM");
            string folderPath2 = folderPath1 + @"\" + current_year_date;
            if (!Directory.Exists(folderPath2))
            {
                Directory.CreateDirectory(folderPath2);
            }

            string file_name = DateTime.Now.ToString("COyyMMdd");
            string logFilePath = folderPath2 + @"\" + file_name + ".LOG";
            if (!Directory.Exists(logFilePath))
            {
                using (File.Create(logFilePath));
            }
        }

        private void WriteInfo(string info)
        {

            string current_year = DateTime.Now.ToString("yyyy");
            string current_year_date = DateTime.Now.ToString("yyyyMM");
            string file_name = DateTime.Now.ToString("COyyMMdd");
            string path = ConfigurationManager.AppSettings.Get("WatchPath1");
            string logFilePath = path + current_year + @"\" + current_year_date + @"\" + file_name + ".LOG";
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now},{info}");
                writer.Close();
            }
        }

        private bool Check()
        {
            string current_date = DateTime.Now.ToString("AUyyMMdd");
            string file_path = @"C:\Users\yzhu\Desktop\" + current_date + ".txt";
            bool is_find = false;
            while (!is_find)
            {
                // check if the file with the name of current_date exists. 
                if (File.Exists(file_path))
                {
                    is_find = true;
                    Thread.Sleep(1000 * 5);
                    //start an external process
                }
                else
                {
                    Thread.Sleep(1000*5*60);
                }
            }
            return is_find;
        }

        public int RandIntGenerator()
        {
            Random rnd = new Random();
            int randint = rnd.Next(0, 100);
            return randint;
        }

        public bool KeywordSearch()
        {
            string current_year = DateTime.Now.ToString("yyyy");
            string current_year_date = DateTime.Now.ToString("yyyyMM");
            string file_name = DateTime.Now.ToString("COyyMMdd");
            string logFilePath = @"C:\Users\yzhu\Desktop\" + current_year + @"\" + current_year_date + @"\" + file_name + ".LOG";

            foreach (string line in File.ReadLines(logFilePath))
            {   
                if (line.Contains("error"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
