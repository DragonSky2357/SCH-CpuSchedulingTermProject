using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class RoundRobin : PreemptiveScheduler
    {
        Queue<Process> readyQueue;
        int quantumTime;

        public RoundRobin(int quantumTime = 5)
        {
            readyQueue = new Queue<Process>();
            this.quantumTime = quantumTime;
        }
        public override void Scheduling()
        {
            int time = 0;
            for (int i = 0; i < processList.Count; i++)
            {
                if (time >= processList[i].arrivalTime) readyQueue.Enqueue(processList[i]);
                else
                {
                    if (readyQueue.Count == 0)
                    {
                        AddGantData(time, processList[i].arrivalTime - time);
                        time = processList[i].arrivalTime;
                    }
                    else 
                    {
                        Process p = readyQueue.Dequeue();
                        if (p.serviceTime <= quantumTime)
                        {
                            AddGantData(p, time);
                            time += p.serviceTime;
                        }
                        else
                        {
                            AddGantData(p, time, quantumTime);
                            p.serviceTime -= quantumTime;
                            time += quantumTime;
                            readyQueue.Enqueue(p);
                        }
                    }
                    i--;
                }
            }
            while (readyQueue.Count > 0)
            {
                Process p = readyQueue.Dequeue();
                if (p.serviceTime <= quantumTime)
                {
                    AddGantData(p, time);
                    time += p.serviceTime;
                }
                else
                {
                    AddGantData(p, time, quantumTime);
                    p.serviceTime -= quantumTime;
                    time += quantumTime;
                    readyQueue.Enqueue(p);
                }
            }
        }
    }
}
