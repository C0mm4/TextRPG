using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class DungeonEntryScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}던전입장{IScene.AnsiColor.Reset}");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            for (int i = 0; i < 3; i++) 
            {
                Dungeon dungeon = Game.Instance.dungeons[i];
                Console.WriteLine($"{IScene.AnsiColor.Magenta}{i+1}. {IScene.AnsiColor.Reset}{dungeon.name} \t | 방어력 {IScene.AnsiColor.Magenta}{dungeon.requireDef}{IScene.AnsiColor.Reset} 이상 권장");
            }

            Console.WriteLine($"{IScene.AnsiColor.Magenta}0. {IScene.AnsiColor.Reset}나가기\n");

            Console.Write("원하시는 행동을 입력해주세요\n>>");

            try
            {
                int select = int.Parse(Console.ReadLine()!);
                switch (select)
                {
                    case 1:
                    case 2:
                    case 3:
                        Game.Instance.DungeonPlay(select);
                        Game.Instance.SceneChange(Game.SceneState.DungeonEnd);
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
