using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class StatusScene : IScene
    {

        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine(IScene.AnsiColor.Yellow + "상태 보기" + IScene.AnsiColor.Reset); 
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Game.player.Print();
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 0:
                        Game.Instance.PopScene();
                        break;
                    default:
                        PrintScene();
                        break;
                }
            }
            catch
            {
                PrintScene();
            }
        }
    }
}
