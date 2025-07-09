using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class LobbyScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. 던전 입장");
            Console.WriteLine("2. 상태 보기");
            Console.WriteLine("3. 인벤토리");
            Console.WriteLine("4. 상점");
            Console.WriteLine("5. 여관");

            Console.WriteLine("\n0. 종료");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int select = int.Parse(Console.ReadLine()!);
                switch (select)
                {
                    case 1:
                        Game.Instance.SceneChange(Game.SceneState.DungeonEntry);
                        break;
                    case 2:
                        Game.Instance.SceneChange(Game.SceneState.Status);
                        break;
                    case 3:
                        Game.Instance.SceneChange(Game.SceneState.Inventory);
                        break;
                    case 4:
                        Game.Instance.SceneChange(Game.SceneState.Shop);
                        break;
                    case 5:
                        Game.Instance.SceneChange(Game.SceneState.Rest);
                        break;
                    case 0:
                        GameSaveSystem.Instance.SaveGame();
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
