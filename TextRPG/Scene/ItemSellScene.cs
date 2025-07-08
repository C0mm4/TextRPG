using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;

namespace TextRPG.Scene
{
    internal class ItemSellScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}상점 - 아이템 판매{IScene.AnsiColor.Reset}");
            Console.WriteLine("보유한 아이템을 판매할 수 있는 상점입니다.\n");
            Console.WriteLine("한번 판매한 아이템은 재구매 할 수 없습니다..\n");
            Console.WriteLine($"[보유 골드]\n{IScene.AnsiColor.Magenta}{Game.player.Gold}G{IScene.AnsiColor.Reset}\n");

            Console.WriteLine($"[보유 아이템]");
            Game.player.DrawInventory(true);

            Console.WriteLine("0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            try
            {
                int select = int.Parse(Console.ReadLine()!);
                if (select == 0)
                {
                    Game.Instance.PopScene();
                    return;
                }
                Game.player.SellItem(select);
            }
            catch
            {

                Thread.Sleep(1000);
                PrintScene();
            }

            Thread.Sleep(1000);
        }
    }
}
