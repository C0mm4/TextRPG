using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;
using TextRPG.Scene;

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
            status.currHP -= 50;
            status.itemMaxHP = 0;
            status.itemAtk = 0;
            status.gold = 900000;

            inventory = new();
            equips = new();
        }

        public void SetName(string? name)
        {
            if (name == null)
                return;
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

            // 장비 해제
            if (itemIndex >= 0 && itemIndex < equips.Count)
            {
                UnequipItem(equips[itemIndex]);
                equips.RemoveAt(itemIndex);
            }
            // 장비 장착
            else if (itemIndex >= equips.Count && itemIndex < inventory.Count + equips.Count)
            {
                itemIndex -= equips.Count;
                Item.Item newItem = inventory[itemIndex];

                // 같은 타입 장비가 이미 있다면 해제
                int existingIndex = equips.FindIndex(e => e.Type == newItem.Type);
                if (existingIndex != -1)
                {
                    UnequipItem(equips[existingIndex]);
                    equips.RemoveAt(existingIndex);

                    // 인벤토리 인덱스 보정
                    if (existingIndex < itemIndex)
                        itemIndex--;
                }

                EquipNewItem(newItem);
                inventory.Remove(newItem);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        private void UnequipItem(Item.Item item)
        {
            Console.WriteLine($"{item.Name} 장비를 해제하였습니다.");
            status.itemAtk -= item.Atk;
            status.itemDef -= item.Def;
            inventory.Add(item);
        }

        private void EquipNewItem(Item.Item item)
        {
            Console.WriteLine($"{item.Name} 장비를 장착하였습니다.");
            status.itemAtk += item.Atk;
            status.itemDef += item.Def;
            equips.Add(item);
        }

        // 아이템 구매시 골드 소모 및 인벤토리 추가 이 때 골드 검사는 Scene에서 진행하도록 함
        public void BuyItem(Item.Item item)
        {
            status.gold -= item.Gold;
            inventory.Add(item);
        }

        public void SellItem(int itemIndex)
        {
            itemIndex--;
            // 인덱스가 장비 영역일 경우 장착 해제 후 판매
            if (itemIndex >= 0 && itemIndex < equips.Count)
            {
                Item.Item sellItem = equips[itemIndex];
                UnequipItem(sellItem);
                Console.WriteLine($"{equips[itemIndex].Name} 장비를 판매하였습니다. {IScene.AnsiColor.Yellow}{(int)(equips[itemIndex].Gold * 0.85f)}G{IScene.AnsiColor.Reset}를 획득합니다.");
                status.gold += (int)(equips[itemIndex].Gold * 0.85f);
                equips.RemoveAt(itemIndex);
                inventory.Remove(sellItem);
            }
            // 인덱스가 인벤토리 영역일 경우 그냥 판매
            else if (itemIndex >= equips.Count && itemIndex < inventory.Count + equips.Count)
            {
                itemIndex -= equips.Count;
                Console.WriteLine($"{inventory[itemIndex].Name} 장비를 판매하였습니다. {IScene.AnsiColor.Yellow}{(int)(inventory[itemIndex].Gold * 0.85f)}G{IScene.AnsiColor.Reset}를 획득합니다.");
                status.itemAtk += inventory[itemIndex].Atk;
                status.itemDef += inventory[itemIndex].Def;
                status.gold += (int)(inventory[itemIndex].Gold * 0.85f);
                inventory.RemoveAt(itemIndex);
            }
            // 인덱스가 아이템 범위를 벗어낫을 경우
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public void TakeRest()
        {
            status.gold -= 500;
            status.currHP += 30;
            status.currHP = Math.Min(status.currHP, status.maxHP);
        }

        public int GetCurrHP() { return status.currHP; }
        public int GetMaxHP() { return status.maxHP; }
        public int GetDef() {  return status.def; }


        public void IncreaseGold(int value) { status.gold += value; }
        public void DecreaseGold(int value) { status.gold -= value; }
        public void IncreaseHP(int value) { status.currHP += value; }
        public void DecreaseHP(int value) { status.currHP -= value; }
    }
}
