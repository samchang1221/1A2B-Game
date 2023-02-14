using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 猜數字
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string again = "y";
            do
            {
                bool IsWin = false;
                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");
                //電腦輸入
                int[] answer = new int[4];
                Random rnd = new Random();  //產生亂數初始值
                for (int i = 0; i < 4; i++)
                {
                    answer[i] = rnd.Next(1, 10);   //亂數產生，亂數產生的範圍是1~9
                    for (int j = 0; j < i; j++)
                    {
                        while (answer[j] == answer[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                        {
                            j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                            answer[i] = rnd.Next(1, 10);   //重新產生，存回陣列，亂數產生的範圍是1~9
                        }
                    }
                }
                //答案測試用
                Console.WriteLine($"answer {answer[0]} {answer[1]} {answer[2]} {answer[3]}");
                do
                {
                    int A = 0;
                    int B = 0;
                    //玩家輸入
                    Console.Write("------\n請輸入 4 個數字：");
                    string guess_line = Console.ReadLine();
                    int[] guess = new int[4];
                    int count = 0;
                    foreach (char c in guess_line)
                    {
                        guess[count++] = Convert.ToInt32(c - '0');
                    }
                    //計分
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (guess[i] == answer[j])
                            {
                                if (i == j)
                                {
                                    A++;
                                }
                                else
                                {
                                    B++;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"判定結果是{A}A{B}B");
                    if (A == 4)
                    {
                        IsWin = true;
                        Console.WriteLine("恭喜你！猜對了！！");
                    }
                } while (!IsWin);
                Console.WriteLine("------\n你要繼續玩嗎？(y/n):");
                again = Console.ReadLine();
            } while (again == "y" || again == "Y");
        }
    }
}
