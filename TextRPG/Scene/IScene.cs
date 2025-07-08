using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal interface IScene
    {
        /// <summary>
        /// 씬의 출력과 입력을 담당하는 메소드.
        /// </summary>
        public void PrintScene();

        /// <summary>
        /// 콘솔의 텍스트 출력 색상을 변경하는 내부 클래스
        /// </summary>
        public static class AnsiColor
        {
            public const string Reset = "\u001b[0m";
            public const string Black = "\u001b[30m";
            public const string Red = "\u001b[31m";
            public const string Green = "\u001b[32m";
            public const string Yellow = "\u001b[33m";
            public const string Blue = "\u001b[34m";
            public const string Magenta = "\u001b[35m";
            public const string Cyan = "\u001b[36m";
            public const string White = "\u001b[37m";
        }
    }
}
