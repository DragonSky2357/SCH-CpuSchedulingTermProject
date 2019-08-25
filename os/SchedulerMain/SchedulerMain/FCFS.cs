using System.Collections.Generic;

namespace Scheduler
{
    class FCFS : NonPreemptiveScheduler
    {
        Queue<Process> readyQueue;

        public FCFS()
        {
            readyQueue = new Queue<Process>();
        }
        public override void Scheduling()
        {
            foreach (Process p in processList)
            {
                readyQueue.Enqueue(p);
            }
            int time = 0;
            while (readyQueue.Count != 0)
            {
                Process p = readyQueue.Dequeue();
                if (time >= p.arrivalTime)
                {
                    AddGantData(p, time);
                    time += p.serviceTime;
                }
                else
                {
                    AddGantData(time, p.arrivalTime - time);
                    time = p.arrivalTime;
                    AddGantData(p, time);
                    time += p.serviceTime;
                }
            }
        }
    }
}
