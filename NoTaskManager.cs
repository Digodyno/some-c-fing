using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ButtonEmulator
{
    public class NoTaskManager
    {
        public NoTaskManager()
        {
            Name = "ButtonEmulator";
        }
        public NoTaskManager(string name)
        {
            Name = name;
        }
        protected List<Process> processes = new List<Process>();
        private string Name { get; set; }
        private int processCount; 
        private void GetProcesses()
        {
            processes.Clear();
            processes = Process.GetProcesses().ToList<Process>();
        }
        public void CheckProcess()
        {
            GetProcesses();
            processCount = 0;
            foreach(Process process in processes)
            {
                if (process.ProcessName == Name)
                {
                    processCount++;
                }
            }
            if (processCount < 2)
            {
                Process.Start(Name);
                CheckProcess();
            }
            //else if (processCount > 2)
            //{
            //    processes.Find(proc => proc.ProcessName == Name).Kill();
            //    CheckProcess();
            //}
        }
        public async void CheckProcessAsync()
        {
            await Task.Run(() => CheckProcess());
        }
    }
}
