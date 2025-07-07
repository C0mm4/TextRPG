using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG.Scene
{
    internal class StartScene : IScene
    {

        public void PrintScene()
        {
            Console.Clear();
            Console.WriteLine($"{IScene.AnsiColor.Magenta}스파르타 마을{IScene.AnsiColor.Reset}에 오신 여러분 환영합니다.");
            


            string answer = "";
            string name;
            do
            {
                Console.WriteLine("원하시는 이름을 설정해주세요.\n\n");
                name = Console.ReadLine();
                Console.WriteLine($"\n당신의 이름이 {IScene.AnsiColor.Cyan}{name}{IScene.AnsiColor.Reset}이 맞습니까? 이름은 이후 변경할 수 없습니다. (Y/N)\n\n");
                answer = Console.ReadLine();
            } while (answer != "y" && answer != "Y");

            Console.WriteLine($"\n스파르타 마을에 오신 것을 환영합니다. {name} 님\n");
            Game.player.SetName(name);
            Game.Instance.SceneChange(Game.SceneState.Lobby);
        }
    }
}
