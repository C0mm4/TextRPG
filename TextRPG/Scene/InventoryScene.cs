using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class InventoryScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}인벤토리{IScene.AnsiColor.Reset}");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"{IScene.AnsiColor.Blue}[아이템 목록]{IScene.AnsiColor.Reset}");

 
            Game.player.DrawInventory(false);

            Console.WriteLine("1. 장착 관리\n");
            Console.WriteLine("0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            try
            {
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Game.Instance.SceneChange(Game.SceneState.EquipControl);
                        break;
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
