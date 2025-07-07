using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRPG.Item
{
    internal class ItemManager
    {
        private static ItemManager instance;
        public static ItemManager Instance { get { return instance; } }

        Item[] items;
        bool[] isBuy;

        public ItemManager()
        {
            if(instance == null)
            {
                instance = this;
            }

            string json = @"[
            { ""name"": ""수련자 갑옷"", ""description"": ""방어력 +5"" , ""flavorText"" : ""수련에 도움을 주는 갑옷입니다"", 
                ""gold"" : 1000, ""atk"" : 0, ""def"" : 5, ""hp"" : 0},
                { ""name"": ""무쇠 갑옷"", ""description"": ""방어력 +9"" , ""flavorText"" : ""무쇠로 만들어져 튼튼한 갑옷입니다."", 
                ""gold"" : 2500, ""atk"" : 0, ""def"" : 9, ""hp"" : 0},
                { ""name"": ""스파르타의 갑옷"", ""description"": ""방어력 +15"" , ""flavorText"" : ""스파르타의 전사들이 사용했다는 전설의 갑옷입니다."", 
                ""gold"" : 3500, ""atk"" : 0, ""def"" : 15, ""hp"" : 0},
                { ""name"": ""낡은 검"", ""description"": ""공격력 +2"" , ""flavorText"" : ""쉽게 볼 수 있는 낡은 검입니다."", 
                ""gold"" : 600, ""atk"" : 2, ""def"" : 0, ""hp"" : 0},
                { ""name"": ""청동 도끼"", ""description"": ""공격력 +5"" , ""flavorText"" : ""어디선가 사용됐던거 같은 도끼입니다."", 
                ""gold"" : 1500, ""atk"" : 5, ""def"" : 0, ""hp"" : 0},
                { ""name"": ""스파르타의 창"", ""description"": ""공격력 +7"" , ""flavorText"" : ""스파르타의 전사들이 사용했다는 전설의 창입니다."", 
                ""gold"" : 5000, ""atk"" : 7, ""def"" : 0, ""hp"" : 0}
        ]";
            items = JsonSerializer.Deserialize<List<Item>>(json).ToArray();

            isBuy = new bool[items.Length];
            Array.Fill(isBuy, false);


        }

        public void Print(bool isBuyScene)
        {
            Console.WriteLine("[아이템 목록");
            for(int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"- {(isBuyScene ? (i+1).ToString() : "")} {items[i].name} \t|{items[i].description} \t|{items[i].flavorText} \t|{(isBuy[i] ? "구매 완료" : items[i].gold.ToString())}");

            }
            Console.WriteLine();
        }

        public void buyItem(int index)
        {
            index--;
            if (index >= 0 && index < items.Length)
            {
                if(Game.player.Gold >= items[index].gold)
                {
                    if (isBuy[index])
                    {
                        Console.WriteLine($"품절된 아이템입니다.");
                    }
                    else
                    {
                        isBuy[index] = true;
                        Game.player.BuyItem(items[index]);

                        Console.WriteLine($"아이템을 구매하였습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다");
                }

            }
            Thread.Sleep(1000);
        }
    }
}
