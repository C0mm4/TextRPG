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
        private  static ItemManager? _instance;
        public static ItemManager Instance 
        { 
            get 
            { 
                if(_instance == null)
                {
                    _instance = new ItemManager();
                }
                return _instance;
            } 
        }

        Item[] items;
        public bool[] isBuy;

        public ItemManager()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            string basePath = AppContext.BaseDirectory;

            // 경로 조합 (items.json이 실행 파일 옆에 있다고 가정)
            string filePath = Path.Combine(basePath, "itemData.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("itemData.json 파일을 찾을 수 없습니다.");
                return;
            }
            try
            {
                string json = File.ReadAllText(filePath); 
                ItemWrapper? wrapper = JsonSerializer.Deserialize<ItemWrapper>(json);
                if(wrapper != null)
                    items = wrapper.Items.ToArray();

                if(items != null)
                {
                    isBuy = new bool[items.Length];
                    Array.Fill(isBuy, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON 파일 파싱 중 오류 발생: " + ex.Message);
            }
        }

        public void Print(bool isBuyScene)
        {
            Console.WriteLine("[아이템 목록");
            for(int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"- {(isBuyScene ? (i+1).ToString() : "")} {items[i].Name} \t|{items[i].Description} \t|{items[i].FlavorText} \t|{(isBuy[i] ? "구매 완료" : items[i].Gold.ToString())}");

            }
            Console.WriteLine();
        }

        public void BuyItem(int index)
        {
            index--;
            if (index >= 0 && index < items.Length)
            {
                if(Game.player.Gold >= items[index].Gold)
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
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public Item? GetItemByID(int id)
        {
            return Array.Find<Item>(items, item => item.Id == id);
        }
    }
}
