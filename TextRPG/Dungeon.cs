using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon
    {
        public string name;
        public int requireDef;
        public int gold;
        public bool isClear;
        public bool isHealth;
        int useHealth;

        public Dungeon(string name, int reqDef, int g) 
        {
            this.name = name;
            requireDef = reqDef;
            gold = g;
            isClear = false;
            isHealth = false;
        }
        public void RunDungeon()
        {
            isClear = false;
            isHealth = false;
            if(Game.player.GetDef() >= requireDef)
            {
                DungeonClear();
            }
            else
            {
                if(Game.Instance.random.Next(0,10) < 4)
                {
                    DungeonFail();
                }
                else
                {
                    DungeonClear();
                }
            }
        }

        private void DungeonClear()
        {
            useHealth = Game.Instance.random.Next(20, 36) - (int)(Game.player.GetDef() - requireDef);

            if (Game.player.GetCurrHP() >= useHealth)
            {
                isClear = true;
            }
            else
            {
                Console.WriteLine("체력이 부족하여 던전을 클리어하지 못했습니다");
                isClear = false;
                isHealth = true;
                DungeonFail();
            }

        }

        private void DungeonFail()
        {
            if(Game.player.GetCurrHP() < useHealth)
            {
                isHealth = true;
            }
            else
            {
                isHealth = false;
            }
            isClear = false;
        }
    }
}
