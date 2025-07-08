using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class RestScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}휴식{IScene.AnsiColor.Reset}");
            Console.WriteLine("골드를 소모하여 체력을 회복할 수 있습니다.");
            Console.WriteLine($"[보유 골드 : {Game.player.Gold}");
            Console.WriteLine($"HP : {Game.player.GetCurrHP()} / {Game.player.GetMaxHP()}");

            Console.WriteLine("1. 회복한다 (500G)\n");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int select = int.Parse(Console.ReadLine()!);

                switch (select)
                {
                    case 1:
                        if(Game.player.Gold >= 500)
                        {
                            Game.player.TakeRest();
                            Console.WriteLine("휴식을 마쳤습니다");
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다");
                        }
                        Thread.Sleep(1000);
                        break;
                    case 0:
                        Game.Instance.PopScene();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        PrintScene();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                PrintScene();
            }

        }
    }
}
