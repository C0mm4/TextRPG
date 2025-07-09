using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class TitleScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}스파르타Text RPG{IScene.AnsiColor.Reset}\n");

            Console.WriteLine("1. 시작하기");
            if (File.Exists("saveData.json"))
            {
                Console.WriteLine("2. 계속하기");
            }
            Console.WriteLine("\n0. 종료하기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int select = int.Parse(Console.ReadLine()!);

                switch (select)
                {
                    case 1:
                        Game.Instance.StartGame();
                        Game.Instance.SceneChange(Game.SceneState.Intro);
                        break;
                    case 2:
                        if (File.Exists("saveData.json"))
                        {
                            Game.Instance.StartGame();
                            GameSaveSystem.Instance.LoadGame();
                            Game.Instance.SceneChange(Game.SceneState.Lobby);
                        }
                        else
                        {
                            throw new Exception();
                        }
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
