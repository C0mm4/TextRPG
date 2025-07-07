using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Item
{
    internal class Item : IComponents
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? flavorText { get; set; }
        public int gold { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int hp { get; set; }

        public void Print()
        {
            Console.WriteLine($"- {name} \t\t| {description}\t\t| {flavorText}");
        }

        public void PrintinEquipScene(int index)
        {
            Console.WriteLine($"- {index} {name} \t\t| {description}\t\t| {flavorText}");
        }

        public void PrintEquip()
        {
            Console.WriteLine($"- [E] {name} \t\t| {description}\t\t| {flavorText}");
        }

        public void PrintEquipinEquipScene(int index)
        {
            Console.WriteLine($"- {index} [E] {name} \t\t| {description}\t\t| {flavorText}");
        }
    }

    internal class ItemList
    {
        public Item[] items;
    }
}
