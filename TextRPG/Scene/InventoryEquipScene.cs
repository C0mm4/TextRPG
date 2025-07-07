using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;

namespace TextRPG.Scene
{
    internal class InventoryEquipScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}인벤토리 - 장착 관리{IScene.AnsiColor.Reset}");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine($"[아이템 목록]\n{IScene.AnsiColor.Magenta}{Game.player.Gold}G{IScene.AnsiColor.Reset}\n");

            
            Game.player.DrawInventory(true);

            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int select = int.Parse(Console.ReadLine());
                if (select == 0)
                {
                    Game.Instance.PopScene();
                    return;
                }
                Game.player.EquipItem(select);
            }
            catch
            {
                PrintScene();
            }
        }
    }
}
