using System.IO;
using System.ServiceProcess;

namespace PracticeService
{
    public partial class TestService : ServiceBase
    {
        System.Timers.Timer timeDelay;
        int count;
        public TestService()
        {
            CanPauseAndContinue = true;
            InitializeComponent();
            timeDelay = new System.Timers.Timer();
            timeDelay.Elapsed += new System.Timers.ElapsedEventHandler(WorkProcess);
        }


        public void WorkProcess(object sender, System.Timers.ElapsedEventArgs e)
        {
            ServiceController service = new ServiceController("PracticeService");
            string process = "Timer Tick " + count;
            LogService(process);
            if (count == 25)
            {
                service.Pause();                
            }
            count++;
        }

        protected override void OnStart(string[] args)
        {
            LogService("Service is Started");
            timeDelay.Enabled = true;
        }
        protected override void OnStop()
        {
            LogService("Service Stoped");
            timeDelay.Enabled = false;
        }

        protected override void OnPause()
        {
            LogService("Service Paused");
            System.Console.WriteLine("Service Paused");
            timeDelay.Enabled = false;
            
        }

        private void LogService(string content)
        {
            FileStream fs = new FileStream(@"C:\Temp\TestServiceLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }
    }
}