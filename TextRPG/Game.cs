using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Item;
using TextRPG.Scene;

namespace TextRPG
{
    internal class Game
    {
        private static Game? instance;
        public static Game? Instance { get { return instance; } }

        private Stack<IScene> sceneStack;
        IScene? currentScene;
        public enum SceneState { Title, Lobby, Status, Inventory, EquipControl, Shop, ItemBuy, Rest,}
        SceneState state;

        public static Player player = new Player();

        public Game()
        {
            if(instance == null)
            {
                instance = this;
            }
            new ItemManager();


            sceneStack = new Stack<IScene>();
            state = SceneState.Title;
            SceneChange(SceneState.Title);

            while (currentScene != null)
            {
                currentScene.PrintScene();
            }
        }

        public void SceneChange(SceneState state)
        {
            IScene? newScene = null;
            switch (state)
            {
                case SceneState.Title:
                    newScene = new StartScene();
                    break;

                case SceneState.Lobby:
                    newScene = new LobbyScene();
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
            }

            if (newScene != null)
            {
                if (currentScene != null)
                {
                    sceneStack.Push(currentScene);
                }
                currentScene = newScene;
            }
        }

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
            if(currentScene != null)
                if(currentScene.GetType().Name == "StartScene")
                {
                    currentScene = null;
                }
        }
    }
}
