using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;

namespace TextRPG.Scene
{
    internal class ShopScene : IScene
    {
        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}상점{IScene.AnsiColor.Reset}");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드]\n{IScene.AnsiColor.Magenta}{Game.player.Gold}G{IScene.AnsiColor.Reset}\n");
            
            ItemManager.Instance.Print(false);


            Console.WriteLine("1. 아이템 구매\n");
            Console.WriteLine("0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            try
            {
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Game.Instance.SceneChange(Game.SceneState.ItemBuy);
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
