using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    enum EquipmentSlot
    {
        RightHand,
        LeftHand,
        Neck
    }
    class Player
    {
        public string Name { get; set; }
        public int BaseHP { get; set; }
        public int BaseDamage { get; set; }

        // экипированные предметы
        public Dictionary<EquipmentSlot, Item> Equipment;

        public Player(string name, int hp, int damage)
        {
            Name = name;
            BaseHP = hp;
            BaseDamage = damage;

            Equipment = new Dictionary<EquipmentSlot, Item>()
        {
            { EquipmentSlot.RightHand, null },
            { EquipmentSlot.LeftHand, null },
            { EquipmentSlot.Neck, null }
        };
        }

        public int GetMaxHP()
        {
            int hp = BaseHP;

            if (Equipment[EquipmentSlot.Neck] != null)
                hp += Equipment[EquipmentSlot.Neck].Stat;

            return hp;
        }

        public int GetDamage()
        {
            int dmg = BaseDamage;

            if (Equipment[EquipmentSlot.RightHand] != null)
                dmg += Equipment[EquipmentSlot.RightHand].Stat;

            if (Equipment[EquipmentSlot.LeftHand] != null)
                dmg += Equipment[EquipmentSlot.LeftHand].Stat;

            return dmg;
        }

        public void PrintEquipment()
        {
            Console.WriteLine("=== Екіпіровка ===");

            foreach (var slot in Equipment)
            {
                Console.Write($"{slot.Key}: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine(slot.Value != null ? $"{slot.Value.Name} (Стат: {slot.Value.Stat})" : "Пусто");
                Console.WriteLine(slot.Value != null ? $"{slot.Value.Name} (Шкода: {slot.Value.Stat})" : "Пусто");
                Console.ResetColor();
            }
        }

        public void Equip(EquipmentSlot slot, Item item, Inventory inventory)
        {
            //Equipment[slot] = item;
            //inventory.RemoveItem(item.Name);

            if (Equipment[slot] == null)
            {
                Equipment[slot] = item;
                inventory.RemoveItem(item.Name);
            }

            else
            {
                inventory.AddItem(Equipment[slot]);
                Equipment[slot] = item;
                inventory.RemoveItem(item.Name);
            }
        }

        //Вывод состояния игрока
        public void PrintStats()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"HP: {GetMaxHP()}");
            Console.WriteLine($"Шкода: {GetDamage()}");
            
            PrintEquipment();
            //Console.WriteLine($"Правая рука: {(EquipmentSlot.RightHand != null ? EquipmentSlot.RightHand : "Пуста")}");
            //Console.WriteLine($"Левая рука: {(EquipmentSlot.LeftHand != null ? EquipmentSlot.LeftHand : "Пуста")}");
            //Console.WriteLine($"Шея: {(EquipmentSlot.Neck != null ? EquipmentSlot.Neck : "Пуста")}");
            Console.WriteLine("=================");
        }
    }
}
