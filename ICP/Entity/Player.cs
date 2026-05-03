using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ICP.Entity
{
    public enum EquipmentSlot
    {
        RightHand,
        LeftHand,
        Neck
    }
    public class Player
    {
        public string Name { get; set; }
        public int BaseHP { get; set; }
        public int BaseDamage { get; set; }
        public Inventory Inventory { get; private set; } = new();

        // предмети екіпіровки
        public Dictionary<EquipmentSlot, Item> Equipment;

        public static Player CreatePlayer(string name)
        {
            return new Player(name, 101, 10);
        }
        private Player(string name, int hp, int damage)
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
                hp += Equipment[EquipmentSlot.Neck].Stat+1;

            return hp;
        }

        public int GetDamage()
        {
            int dmg = BaseDamage;

            if (Equipment[EquipmentSlot.RightHand] != null)
                dmg += Equipment[EquipmentSlot.RightHand].Stat + 1;

            if (Equipment[EquipmentSlot.LeftHand] != null)
                dmg += Equipment[EquipmentSlot.LeftHand].Stat+1;

            return dmg;
        }

        public void PrintEquipment()
        {
            Console.WriteLine("=== Екіпіровка ===");

            foreach (var slot in Equipment)
            {
                Console.Write($"{slot.Key}: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(slot.Value != null ? $"{slot.Value.Name} (Шкода: {slot.Value.Stat})" : "Пусто");
                Console.ResetColor();
            }
        }

        public void Equip(EquipmentSlot slot, Item item)
        {

            
                Equipment[slot] = item;
                Inventory.RemoveItem(item.Id);
         

          
        }

        //Виведення стану гравця
        public void PrintStats()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"HP: {GetMaxHP()}");
            Console.WriteLine($"Шкода: {GetDamage()}");
            
            PrintEquipment();
            
            Console.WriteLine("=================");
        }
    }
}
