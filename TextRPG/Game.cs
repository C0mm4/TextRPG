using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;
using TextRPG.Scene;

namespace TextRPG
{
    internal class Game
    {
        private static Game? _instance;
        public static Game Instance 
        { 
            get 
            { 
                if(_instance == null)
                    _instance = new Game();
                return _instance; 
            }
        }

        private Stack<IScene> sceneStack;
        IScene? currentScene;
        public enum SceneState { Title, Intro, Lobby, DungeonEntry, DungeonEnd, 
            Status, Inventory, EquipControl, Shop, ItemBuy, ItemSell, Rest,}

        private SceneState state;

        public static Player player = new Player();

        public Random random = new Random();

        public List<Dungeon> dungeons = new();
        public Dungeon currentDungeon;
        public bool isClear;

        public Game()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            new ItemManager();
            DungeonCreate();

            sceneStack = new Stack<IScene>();
            state = SceneState.Title;
            SceneChange(SceneState.Title);

            while (currentScene != null)
            {
                currentScene.PrintScene();
            }
        }

        /// <summary>
        /// 게임의 Scene을 변경하는 메소드. 변경되는 Scene에 따라 currentScene을 변경
        /// </summary>
        /// <param name="state">New Scene State</param>
        public void SceneChange(SceneState state)
        {
            IScene? newScene = null;
            switch (state)
            {
                case SceneState.Title:
                    newScene = new TitleScene();
                    break;

                case SceneState.Intro:
                    newScene = new IntroScene();
                    break;

                case SceneState.Lobby:
                    newScene = new LobbyScene();
                    break;

                case SceneState.DungeonEntry:
                    newScene = new DungeonEntryScene();
                    break;

                case SceneState.DungeonEnd:
                    newScene = new DungeonEndScene();
                    break;

                case SceneState.Status:
                    newScene = new StatusScene();
                    break;

                case SceneState.Inventory:
                    newScene = new InventoryScene();
                    break;

                case SceneState.EquipControl:
                    newScene = new InventoryEquipScene();
                    break;

                case SceneState.Shop:
                    newScene = new ShopScene();
                    break;

                case SceneState.ItemBuy:
                    newScene = new ItemBuyScene();
                    break;

                case SceneState.ItemSell:
                    newScene = new ItemSellScene();
                    break;

                case SceneState.Rest:
                    newScene = new RestScene();
                    break;
            }

            if (newScene != null)
            {
                if (currentScene != null && currentScene.GetType().Name != "IntroScene")
                {
                    sceneStack.Push(currentScene);
                }
                currentScene = newScene;
            }
        }

        /// <summary>
        /// 현재 씬을 종료하고 이전 씬으로 돌아가는 메소드
        /// </summary>
        public void PopScene()
        {
            if (sceneStack.Count > 0)
            {
                currentScene = sceneStack.Pop();
            }
            else
            {
                currentScene = null;
            }
        }

        public void DungeonPlay(int level)
        {
            currentDungeon = dungeons[--level];
            currentDungeon.RunDungeon();
        }

        public void DungeonCreate()
        {
            Dungeon easy = new("쉬운 던전", 5, 1000);
            dungeons.Add(easy);
            Dungeon normal = new("일반 던전", 11, 1700);
            dungeons.Add(normal);
            Dungeon hard = new("어려운 던전", 17, 2500);
            dungeons.Add(hard);
        }

        public void StartGame()
        {
            player = new Player();
        }
    }
}
