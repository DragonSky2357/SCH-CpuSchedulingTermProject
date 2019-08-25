using System.Collections.Generic;

namespace Scheduler
{
    class SJF : NonPreemptiveScheduler
    {
        List<Process> readyQueue;

        public SJF()
        {
            readyQueue = new List<Process>();
        }
        class ProcessComparer : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                return x.serviceTime.CompareTo(y.serviceTime);
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
					if(readyQueue.Count == 0)
                    {
                        AddGantData(time, processList[i].arrivalTime - time);
                        time = processList[i].arrivalTime;
                    }
                    else
                    {
                        if (readyQueue.Count > 1) readyQueue.Sort(new ProcessComparer());
                        AddGantData(readyQueue[0],time);
                        time += readyQueue[0].serviceTime;
                        readyQueue.RemoveAt(0);
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
