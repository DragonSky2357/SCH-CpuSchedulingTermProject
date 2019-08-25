//#define Debug //디버그 모드( 데이터를 콘솔로 출력)

using System;
using System.IO;

namespace Scheduler
{
    //스케줄러의 매인클래스
    class SchedulerMain
    {
        StreamReader inputFile;
        String outputFileName;

        AbstractScheduler scheduler; //수행할 스케줄러 저장
        //에러정보 콘솔출력 함수
        void ErrorConsoleOut(String errorMessage)
        {
            Console.WriteLine(errorMessage);
            inputFile.Close();
            Environment.Exit(1);
        }
        //에러정보 파일 출력 함수
        void ErrorFileOut(String errorMessage)
        {
            StreamWriter file = new StreamWriter(outputFileName);
            file.Write(errorMessage);
            inputFile.Close();
            file.Close();
            Environment.Exit(1);
        }
        /*스케줄러의 매인클래스의 생성자
         * inputFileName: 파일에서 수행할 스케줄링 알고리즘의 정보와 프로세스의 목록을 읽어온다.
         * outputFileName: input파일에서 받아온 데이터를 가지고 스케줄링한 후 결과를 출력한다.
         */
        public SchedulerMain(string inputFileName = "data.txt", string outputFileName = "data-r.txt")
        {
            if (!File.Exists(inputFileName)) //input파일이 없을 경우
            {
                ErrorFileOut("입력파일 없음 에러");
#if Debug
                ErrorConsoleOut("입력파일 없음 에러");
#endif
            }
            inputFile = new StreamReader(inputFileName);
            this.outputFileName = outputFileName;

            ExecuteScheduler(); //스케줄러 실행
        }
        /*스케줄러 실행 함수
         * 파일에 맨 첫번째 줄에 있는 수행할 스케줄링 알고리즘의 이름과
         * 필요한 정보(시간 할당량)을 받아와 알고리즘을 선택을 하여
         * 수행하고 스케줄링이 완료 후 생성된 데이터를 파일로 출력한다.
         */
        void ExecuteScheduler()
        {
            if (inputFile.EndOfStream)
            {
                ErrorFileOut("입력파일 공백 에러");
#if Debug
                ErrorConsoleOut("입력파일 공백 에러");
#endif
            }
            else
            {
                //파일에서 수행할 수케줄러의 정보를 받아와 수행할 스케줄링 알고리즘을 선택
                String[] parts = inputFile.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (parts[0])
                {
                    case "FCFS":
                    case "fcfs":
                        scheduler = new FCFS();
                        break;
                    case "SJF":
                    case "sjf":
                        scheduler = new SJF();
                        break;
                    case "SRT":
                    case "srt":
                        scheduler = new SRT();
                        break;
                    case "NonPreamptivePriority":
                    case "NPP":
                    case "npp":
                        scheduler = new NonPreemptivePriority();
                        break;
                    case "PreamptivePriority":
                    case "PP":
                    case "pp":
                        scheduler = new PreemptivePriority();
                        break;
                    case "RoundRobin":
                    case "RR":
                    case "rr":
                        try
                        {
                            scheduler = new RoundRobin(Int32.Parse(parts[1]));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            scheduler = new RoundRobin();
                        }
                        catch (FormatException)
                        {
                            ErrorFileOut("입력파일 형식 에러");
#if Debug
                            ErrorConsoleOut("입력파일 형식 에러");
#endif
                        }
                        break;
                    case "HRN":
                    case "hrn":
                        scheduler = new HRN();
                        break;
                    default:
                        ErrorFileOut("입력파일 형식 에러");
#if Debug
                        ErrorConsoleOut("입력파일 형식 에러");
#endif
                        break;
                }
                if (!scheduler.FileLoad(inputFile))
                {
                    ErrorFileOut("입력파일 데이터로드 에러");
#if Debug
                    ErrorConsoleOut("입력파일 데이터로드 에러");
#endif
                }
                if (scheduler.ProcessListIsEmpty())
                {
                    ErrorFileOut("프로세스목록 공백 에러");
#if Debug
                    ErrorConsoleOut("프로세스목록 공백 에러");
#endif
                }
                scheduler.Scheduling(); //스케줄링 알고리즘 수행
                scheduler.CalculateAvgData(); //평균 데이터 계산

                scheduler.FileWrite(outputFileName);
#if Debug
                scheduler.ConsoleWrite();
#endif
            }
        }
        ~SchedulerMain() { inputFile.Close(); }

        static void Main(string[] args)
        {
            new SchedulerMain();
        }
    }
}