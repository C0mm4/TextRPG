using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TextRPG.Item;

namespace TextRPG
{
    internal class GameSaveSystem
    {
        private static GameSaveSystem? _instance;
        public static GameSaveSystem Instance {  
            get {
                if(_instance == null)
                {
                    _instance = new GameSaveSystem();
                }
                return _instance; 
            }
        }

        internal class GameData
        {
            public StatusData playerData { get; set; } = new();

            public List<int> equipIds { get; set; } = new();
            public List<int> inventoryIds { get; set; } = new();
            public List<bool> buyItemLogs { get; set; } = new();
        }

        public GameData data = new();

        public GameSaveSystem() { }

        private string path = "saveData.json";

        public void InitizliaeGameData()
        {
            data.playerData = Game.player.GetStatus(); 
            data.equipIds = Game.player.equips.Select(item => item.Id).ToList();
            data.inventoryIds = Game.player.inventory.Select(item => item.Id).ToList();

            data.buyItemLogs = ItemManager.Instance.isBuy.ToList();
        }

        public void SetData()
        {
            Game.player.SetStatus(data.playerData);
            for(int i = 0; i <  data.equipIds.Count; i++)
            {
                Item.Item? item = ItemManager.Instance.GetItemByID(data.equipIds[i]);
                if (item != null)
                {
                    Game.player.equips.Add(item);
                }
            }
            for (int i = 0; i < data.inventoryIds.Count; i++)
            {
                Item.Item? item = ItemManager.Instance.GetItemByID(data.inventoryIds[i]);
                if (item != null)
                {
                    Game.player.inventory.Add(item);
                }
            }
            for(int i = 0; i < data.buyItemLogs.Count; i++)
            {
                ItemManager.Instance.isBuy[i] = data.buyItemLogs[i];
            }
        }

        public void SaveGame()
        {
            InitizliaeGameData();
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public bool LoadGame()
        {
            if (!File.Exists(path))
            {
                data = new GameData();
                return false;
            }


            string json = File.ReadAllText(path);
            data =  JsonSerializer.Deserialize<GameData>(json);
            SetData();
            return true;
        }
    }
}
