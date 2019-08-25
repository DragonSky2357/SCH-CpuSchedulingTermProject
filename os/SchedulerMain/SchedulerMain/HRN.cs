using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class HRN : NonPreemptiveScheduler
    {
        List<Process> readyQueue;

        public HRN()
        {
            readyQueue = new List<Process>();
        }
        class ProcessComparer : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                return y.priority.CompareTo(x.priority);
            }
        }
        public override void Scheduling()
        {
            int time = 0;
            for (int i = 0; i < processList.Count; i++)
            {
                if (time >= processList[i].arrivalTime) readyQueue.Add(processList[i]);
                else
                {
                    if (readyQueue.Count == 0)
                    {
                        AddGantData(time, processList[i].arrivalTime - time);
                        time = processList[i].arrivalTime;
                    }
                    else
                    {
                        for (int j = 0; j < readyQueue.Count; j++)
                        {
                            Process p = readyQueue[j];
                            p.priority = (double)(p.serviceTime + time - p.arrivalTime) / (double)p.serviceTime;
                            readyQueue[j] = p;
                        }
                        if (readyQueue.Count > 1) readyQueue.Sort(new ProcessComparer());
                        AddGantData(readyQueue[0], time);
                        time += readyQueue[0].serviceTime;
                        readyQueue.RemoveAt(0);
                    }
                    i--;
                }
            }
            for (int i = 0; i < readyQueue.Count; i++)
            {
                Process p = readyQueue[i];
                p.priority = (double)(p.serviceTime + time - p.arrivalTime) / (double)p.serviceTime;
                readyQueue[i] = p;
            }
            if (readyQueue.Count > 1) readyQueue.Sort(new ProcessComparer());
            while (readyQueue.Count > 0)
            {
                AddGantData(readyQueue[0], time);
                time += readyQueue[0].serviceTime;
                readyQueue.RemoveAt(0);
            }
        }
    }
}
