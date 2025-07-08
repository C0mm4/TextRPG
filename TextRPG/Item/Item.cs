using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Item
{
    internal class Item : IComponent
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string FlavorText { get; set; }
        public int Gold { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int HP { get; set; }

        public int Type {  get; set; }

        public void Print()
        {
            Console.WriteLine($"- {Name} \t\t| {Description}\t\t| {FlavorText}");
        }

        public void PrintinEquipScene(int index)
        {
            Console.WriteLine($"- {index} {Name} \t\t| {Description}\t\t| {FlavorText}");
        }

        public void PrintEquip()
        {
            Console.WriteLine($"- [E] {Name} \t\t| {Description}\t\t| {FlavorText}");
        }

        public void PrintEquipinEquipScene(int index)
        {
            Console.WriteLine($"- {index} [E] {Name} \t\t| {Description}\t\t| {FlavorText}");
        }
    }

    internal class ItemWrapper() 
    {
        public required List<Item> Items { get; set; }
    }

}
