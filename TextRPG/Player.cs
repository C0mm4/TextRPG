using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;

namespace TextRPG
{
    internal class Player : IComponent
    {
        StatusData status;
        public List<Item.Item> equips;
        public List<Item.Item> inventory;

        public int Gold { get { return status.gold; } }

        public Player()
        {
            status.level = 1;
            status.classType = "전사";
            status.atk = 10;
            status.def = 5;
            status.currHP = status.maxHP = 100;
            status.gold = 900000;

            inventory = new();
            equips = new();
        }

        public void SetName(string name)
        {
            status.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Lv. {status.level}");
            Console.WriteLine($"{status.name} / {status.classType}");
            Console.Write($"ATK : {status.atk + status.itemAtk} ");
            if(status.itemAtk > 0)
            {
                Console.WriteLine($"(+{status.itemAtk})");
            }
            else
            {
                Console.WriteLine();
            }
            Console.Write($"DEF : {status.def + status.itemDef}");
            if (status.itemDef > 0)
            {
                Console.WriteLine($"(+{status.itemDef})");
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine($"HP : {status.currHP} / {status.maxHP}");
            Console.WriteLine($"Gold : {status.gold}");
        }

        public void DrawInventory(bool isEquipScene)
        {
            int i = 0;
            for(; i < equips.Count; i++)
            {
                if (isEquipScene)
                {
                    equips[i].PrintEquipinEquipScene(i + 1);
                }
                else
                {
                    equips[i].PrintEquip();
                }
            }

            for(; i < inventory.Count + equips.Count; i++)
            {
                if (isEquipScene)
                {
                    inventory[i-equips.Count].PrintinEquipScene(i + 1);
                }
                else
                {
                    inventory[i-equips.Count].Print();
                }
            }

            if (i == 0)
            {
                Console.WriteLine("보유중인 아이템이 없습니다.");
            }
        }

        public void EquipItem(int itemIndex)
        {
            itemIndex--;

            if(itemIndex >= 0 && itemIndex < equips.Count)
            {
                status.itemAtk -= equips[itemIndex].atk;
                status.itemDef -= equips[itemIndex].def;
                inventory.Add(equips[itemIndex]);
                equips.RemoveAt(itemIndex);
            }
            else if(itemIndex >= equips.Count && itemIndex < inventory.Count + equips.Count)
            {
                itemIndex -= equips.Count;
                status.itemAtk += inventory[itemIndex].atk;
                status.itemDef += inventory[itemIndex].def;
                equips.Add(inventory[itemIndex]);
                inventory.RemoveAt(itemIndex);
            }
        }


        public void BuyItem(Item.Item item)
        {
            status.gold -= item.gold;
            inventory.Add(item);
        }
    }
}
