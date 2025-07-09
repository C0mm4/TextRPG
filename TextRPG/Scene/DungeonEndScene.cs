using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class DungeonEndScene : IScene
    {
        bool isSet = false;

        int getGold = 0;
        int useHealth = 0;

        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Yellow}던전결과{IScene.AnsiColor.Reset}");
            if (Game.Instance.currentDungeon.isClear)
            {
                if (!isSet)
                {
                    useHealth = Game.Instance.random.Next(20, 36) - (int)(Game.player.GetDef() - Game.Instance.currentDungeon.requireDef);
                    getGold = (int)(Game.Instance.currentDungeon.gold * (1 + (Game.Instance.random.Next((int)Game.player.GetAtk(), (int)Game.player.GetAtk()*2))*0.01f));
                    isSet = true;

                    Game.player.GetExp();
                }
                Console.WriteLine($"{IScene.AnsiColor.Yellow}축하합니다!{IScene.AnsiColor.Reset}");
                Console.WriteLine($"{IScene.AnsiColor.Cyan}{Game.Instance.currentDungeon.name}{IScene.AnsiColor.Reset}을 클리어하였습니다!");
                
            }
            else
            {
                if (Game.Instance.currentDungeon.isHealth)
                {
                    Console.WriteLine($"체력이 부족하여 던전을 돌지 못했습니다\n여관에서 체력을 회복하세요");
                    useHealth = 0;
                    getGold = 0;
                }
                else
                {
                    if (!isSet)
                    {
                        useHealth = (Game.Instance.random.Next(20, 36) - (int)(Game.player.GetDef() - Game.Instance.currentDungeon.requireDef)) / 2;
                        getGold = 0;
                        isSet = true;
                    }
                    Console.WriteLine($"{IScene.AnsiColor.Cyan}{Game.Instance.currentDungeon.name}{IScene.AnsiColor.Reset}을 클리어하지 못했습니다...");

                }
            }

            Console.WriteLine($"\n[탐험결과]");
            Console.WriteLine($"체력 {IScene.AnsiColor.Magenta}{Game.player.GetCurrHP()}{IScene.AnsiColor.Reset} -> {IScene.AnsiColor.Magenta}{Game.player.GetCurrHP() - useHealth}{IScene.AnsiColor.Reset}");
            Console.WriteLine($"체력 {IScene.AnsiColor.Magenta}{Game.player.Gold}{IScene.AnsiColor.Reset} G -> {IScene.AnsiColor.Magenta}{Game.player.Gold + getGold}{IScene.AnsiColor.Reset} G");

            Console.WriteLine("\n0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            try
            {
                int select = int.Parse(Console.ReadLine()!);
                switch (select)
                {
                    case 0:
                        Game.player.IncreaseGold(getGold);
                        Game.player.DecreaseHP(useHealth);
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
