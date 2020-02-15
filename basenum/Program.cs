using System;
using System.Text;

namespace basenum
{
    class Program
    {
        static void Main()
        {
            진행 순서;
            순서 = new 진행();
            순서.준비();
            순서.게임();
        }
    }

    class 진행
    {
        const int 최대값 = 4;
        string 문제;
        StringBuilder 문제생성 = new StringBuilder();
        int 볼;
        int 스트라이크;
        bool 아웃;
        int 시도;

        public void 준비()
        {
            아웃 = false;
            볼 = 0;
            스트라이크 = 0;
            시도 = 0;
            문제생성.AppendFormat("");
            문제 = string.Empty;

            랜덤생성 값;
            값 = new 랜덤생성();
            for(var i = 0; i < 최대값; i++)
            {
                문제생성.Append(값.랜덤값().ToString());
            }
            문제 = 문제생성.ToString();
            Console.WriteLine();
            Console.WriteLine("[명령어 검색]");
            Console.WriteLine("[기권] 게임 종료");
            Console.WriteLine("[재시작] 다시시작");
        }

        public void 게임()
        {
            Console.WriteLine("---------------\r\n[숫자야구] 시작");
            while(!아웃)
            {
                Console.WriteLine("입력");
                string 입력 = Console.ReadLine();
                if(입력.Length != 최대값)
                {
                    switch(입력)
                    {
                        case "기권":
                        {
                            Console.WriteLine("게임종료");
                            아웃 = true;
                            break;
                        }
                        case "재시작":
                        {
                            준비();
                            Console.WriteLine("---------------\r\n[숫자야구] 재시작");
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
                            break;
                        }
                    }
                }
                else
                {
                    시도++;
                    //스트라이크
                    for(var 순서 = 0; 순서 < 최대값; 순서++)
                    {
                        if(문제.Substring(순서, 1) == 입력.Substring(순서, 1))
                        {
                            스트라이크++;
                        }
                    }
                    //볼
                    for(var 순서 = 0; 순서 < 최대값; 순서++)
                    {
                        for(var 숫자 = 0; 숫자 < 최대값; 숫자++)
                        {
                            if(순서 == 숫자) { continue; }
                            if(문제.Substring(순서, 1) == 입력.Substring(숫자, 1))
                            {
                                볼++;
                                break;
                            }
                        }
                    }
                    if(스트라이크 == 최대값)
                    {
                        아웃 = true;
                        Console.WriteLine($"TRY{시도} 아웃");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"TRY{시도} S{스트라이크} B{볼}");
                        스트라이크 = 0;
                        볼 = 0;
                    }
                }
            }
        }
    }

    class 랜덤생성
    {
        int 사이즈;
        int[] 랜덤박스 = new int[11];
        int 랜덤;
        int 값 = 0;

        public int 랜덤값()
        {
            값--;
            if (값 < 0)
            {
                for (int i = 0; i < 랜덤박스.Length; i++)
                {
                    랜덤박스[i] = i;
                }
                값 = 10;
            }
            Random 랜덤객체 = new Random();
            사이즈 = 랜덤객체.Next(0, 값);
            랜덤 = 랜덤박스[사이즈];
            for (; 사이즈 < 값; 사이즈++)
            {
                랜덤박스[사이즈] = 랜덤박스[사이즈 + 1];
            }
            //Console.Write(랜덤);
            return 랜덤;
        }
    }
}
