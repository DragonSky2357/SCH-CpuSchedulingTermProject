using System;
using System.IO;
using System.Collections.Generic;

namespace Scheduler
{
    //프로세스 정보 구조체
    struct Process
    {
        public String PID;
        public int arrivalTime;
        public int serviceTime;
        public double priority;
        public Process(String PID, int arrivalTime, int serviceTime, int priority = 0)
        {
            this.PID = PID;
            this.arrivalTime = arrivalTime;
            this.serviceTime = serviceTime;
            this.priority = priority;
        }
    }
    //간트 차트 데이터 구조체
    struct GantData
    {
        public String PID;
        public int arrivalTime;
        public int startTime;
        public int runTime;
        public GantData(String PID, int arrivalTime, int startTime, int runTime)
        {
            this.PID = PID;
            this.arrivalTime = arrivalTime;
            this.startTime = startTime;
            this.runTime = runTime;
        }
    }
    //간트 차트 구조체
    class GantChart
    {
        //아무 프로세스도 수행하지 않는 상태를 나타냄
        protected const string ProcesserLatency = "Sleep";

        protected List<GantData> gant;

        public GantChart()
        {
            gant = new List<GantData>();
        }
        //간트차트 데이터 추가 함수(process.serviceTime == runTime)
        public void AddGantData(Process process, int startTime)
        {
            if(gant.Count != 0 && gant[gant.Count-1].PID == process.PID)
            {
                GantData g = gant[gant.Count - 1];
                g.runTime += process.serviceTime;
                gant[gant.Count - 1] = g;
            }
            else
                gant.Add(new GantData(process.PID, process.arrivalTime, startTime, process.serviceTime));
        }
        //간트차트 데이터 추가 함수
        public void AddGantData(Process process, int startTime, int runnigTime)
        {
            if (gant.Count != 0 && gant[gant.Count - 1].PID == process.PID)
            {
                GantData g = gant[gant.Count - 1];
                g.runTime += runnigTime;
                gant[gant.Count - 1] = g;
            }
            else
                gant.Add(new GantData(process.PID, process.arrivalTime, startTime, runnigTime));
        }
        //간트차트 데이터 추가 함수(Sleep상태 추가)
        public void AddGantData(int startTime, int runTime)
        {
            gant.Add(new GantData(ProcesserLatency, 0, startTime, runTime));
        }
        //간트 차트 정보 파일 출력 함수(PID, 수행시간)
        public virtual void SimpleFileWrite(String fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            foreach (GantData d in gant)
            {
                file.WriteLine(d.PID + " " + d.runTime);
            }
            file.Close();
        }
        //간트 차트 정보 파일 출력 함수(PID, 수행시작시간, 수행시간)
        public virtual void FileWrite(String fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            foreach (GantData d in gant)
            {
                file.WriteLine(d.PID + " " + d.startTime + " " + d.runTime);
            }
            file.Close();
        }
        //간트차트 정보 콘솔 출력 함수
        public virtual void ConsoleWrite()
        {
            foreach (GantData d in gant)
            {
                Console.WriteLine(d.PID + " " + d.startTime + " " + d.runTime);
            }
        }
    }
    //스케줄링 알고리즘의 추상 클래스
    abstract class AbstractScheduler : GantChart
    {
        protected List<Process> processList;

        protected double avgWaitingTime;
        protected double avgReturnTime;
        protected double avgResponseTime;

        public AbstractScheduler()
        {
            processList = new List<Process>();
            avgWaitingTime = 0;
            avgReturnTime = 0;
            avgResponseTime = 0;
        }
        //프로세스 추가 함수
        public void AddProcess(Process process)
        {
            processList.Add(process);
        }
        //프로세스 리스트 졍렬을 위한 클래스
        class ProcessComparer : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                return x.arrivalTime.CompareTo(y.arrivalTime);
            }
        }
        /*파일에서 프로세스목록 읽기 함수
         * 반환값
         * false: 프로세스 목록 읽기 실패
         * true: 프로세스목록 읽기 성공
         */
        public bool FileLoad(StreamReader file)
        {
            Process process;

            try
            {
                while (!file.EndOfStream)
                {
                    String[] parts = file.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //우선순위 정보가 있을 경우
                    if (parts.Length == 4)
                    {

                        process.PID = parts[0];
                        process.arrivalTime = Int32.Parse(parts[1]);
                        process.serviceTime = Int32.Parse(parts[2]);
                        process.priority = Int32.Parse(parts[3]);
                        processList.Add(process);
                    }
                    //우선순위 정보가 없을 경우
                    else if (parts.Length == 3)
                    {
                        process.PID = parts[0];
                        process.arrivalTime = Int32.Parse(parts[1]);
                        process.serviceTime = Int32.Parse(parts[2]);
                        process.priority = 0;
                        processList.Add(process);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            processList.Sort(new ProcessComparer()); //프로세스 리스트를 도착시간 순서로 정렬
            return true;
        }
        public bool ProcessListIsEmpty()
        {
            return (processList.Count == 0);
        }
        public abstract void Scheduling(); //스케줄링(간트차트 생성)을 수행하는 함수
        public abstract void CalculateAvgData(); //간트차트를 이용하여 평균 데이터를 계산 함수

        //오버라이드된 간트차트(PID, 수행시간)의 파일 출력 함수를 호출하고 평균데이터 파일 출력 함수
        public override void SimpleFileWrite(String fileName)
        {
            base.FileWrite(fileName);
            StreamWriter file = new StreamWriter(fileName, true);
            file.WriteLine(avgWaitingTime.ToString("0.##") + " " + avgReturnTime.ToString("0.##") + " " + avgResponseTime.ToString("0.##"));
            file.Close();
        }
        //간트차트(PID, 수행시작시간, 수행시간)의 파일 출력 함수를 호출하고 평균데이터 파일 출력 함수
        public override void FileWrite(String fileName)
        {
            base.FileWrite(fileName);
            StreamWriter file = new StreamWriter(fileName, true);
            file.WriteLine(avgWaitingTime.ToString("0.##") + " " + avgReturnTime.ToString("0.##") + " " + avgResponseTime.ToString("0.##"));
            file.Close();
        }
        //간트차트 콘솔 출력 함수를 호출하고 평균테이터 콘솔 출력 함수
        public override void ConsoleWrite()
        {
            base.ConsoleWrite();
            Console.WriteLine("평균 대기시간: " + avgWaitingTime.ToString("0.##"));
            Console.WriteLine("평균 반환시간: " + avgReturnTime.ToString("0.##"));
            Console.WriteLine("평균 응답시간: " + avgResponseTime.ToString("0.##"));
        }
    }
    //비선점 스케줄링 알고리즘의 평균 데이터 계산 함수를 구현한 클래스
    abstract class NonPreemptiveScheduler : AbstractScheduler
    {
        public override void CalculateAvgData()
        {
            for (int i = 0; i < gant.Count; i++)
            {
                if (gant[i].PID == GantChart.ProcesserLatency) continue;
                avgWaitingTime += (gant[i].startTime - gant[i].arrivalTime);
                avgReturnTime += (gant[i].startTime + gant[i].runTime - gant[i].arrivalTime);
            }
            avgReturnTime /= processList.Count;
            avgWaitingTime /= processList.Count;
            avgResponseTime = avgWaitingTime;
        }
    }
    //선점 스케줄링 알고리즘의 평균 데이터 계산 함수를 구현한 클래스
    abstract class PreemptiveScheduler : AbstractScheduler
    {
        public override void CalculateAvgData()
        {
            int sum = 0;
            for(int i= 0; i < processList.Count; i++)
            {
                for(int j = 0; j < gant.Count; j++)
                {
                    if(processList[i].PID == gant[j].PID)
                    {
                        avgResponseTime += gant[j].startTime - gant[j].arrivalTime;
                        break;
                    }
                }
                for(int j = gant.Count - 1; j >= 0; j--)
                {
                    if (processList[i].PID == gant[j].PID)
                    {
                        avgReturnTime += gant[j].startTime + gant[j].runTime - gant[j].arrivalTime;
                        break;
                    }
                }
                sum += processList[i].serviceTime;
            }
            avgWaitingTime = avgReturnTime - sum;

            avgReturnTime /= processList.Count;
            avgWaitingTime /= processList.Count;
            avgResponseTime /= processList.Count;
        }
    }
}
