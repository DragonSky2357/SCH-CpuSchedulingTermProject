using System.Collections.Generic;

namespace Scheduler
{
    class PreemptivePriority : PreemptiveScheduler
    {
        List<Process> readyQueue;

        public PreemptivePriority()
        {
            readyQueue = new List<Process>();
        }
        class ProcessComparer : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                return x.priority.CompareTo(y.priority);
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
                        if (readyQueue.Count > 1) readyQueue.Sort(new ProcessComparer());
                        if (time + readyQueue[0].serviceTime <= processList[i].arrivalTime)
                        {
                            AddGantData(readyQueue[0], time);
                            time += readyQueue[0].serviceTime;
                            readyQueue.RemoveAt(0);
                        }
                        else
                        {
                            AddGantData(readyQueue[0], time, processList[i].arrivalTime - time);
                            Process p = readyQueue[0];
                            p.serviceTime -= processList[i].arrivalTime - time;
                            readyQueue[0] = p;
                            time = processList[i].arrivalTime;
                        }

                    }
                    i--;
                }
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
