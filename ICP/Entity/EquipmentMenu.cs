using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    internal class EquipmentMenu
    {
        public void equipmentMenu(Player player, Inventory inventory)
        {
            while (true)
            {
                Console.WriteLine("\n=== Cпорядження ===");
                Console.WriteLine("1. Права рука");
                Console.WriteLine("2. Ліва рука");
                Console.WriteLine("3. Шия");
                Console.WriteLine("4. Завершити оцінення спорядження");
                player.PrintStats();
                EquipmentSlot? slot = null;
                 bool uotTriggered = false;
                while (true)
                {
                    Console.Write("\rТвій вибір: ");
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            slot = EquipmentSlot.RightHand;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Права рука                                        ");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D2:
                            slot = EquipmentSlot.LeftHand;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Ліва рука                                        ");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D3:
                            slot = EquipmentSlot.Neck;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Шия                                         ");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Завершення оцінення спорядження...");
                            Console.ResetColor();
                                uotTriggered = true;
                            break;
                        case ConsoleKey.Enter:
                            if (slot != null|| uotTriggered == true)
                                break;
                            else
                                continue;

                        default:
                            continue;
                    }

                    if (key.Key == ConsoleKey.Enter)
                        break;
                }
                if (uotTriggered)
                    return;
                // Отримуємо предмети, що підходять для слота
                List<Item> validItems = new List<Item>();

                foreach (var item in inventory.GetAllItems())
                {
                    if ((slot == EquipmentSlot.RightHand || slot == EquipmentSlot.LeftHand) &&
                        (item.Type == ItemType.Weapon || item.Type == ItemType.MagicalWeapon))
                    {
                        validItems.Add(item);
                    }

                    if (slot == EquipmentSlot.Neck && item.Type == ItemType.Artifact)
                    {
                        validItems.Add(item);
                    }
                }

                Console.WriteLine("\n=== Предметы для слота ===");

                if (validItems.Count == 0)
                {
                    Console.WriteLine("Немає предметів для цього слота.");
                    Console.ReadKey(true);
                    return;
                }

                // виведення списку
                for (int i = 0; i < validItems.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{i + 1}. {validItems[i].Name}");
                    Console.ResetColor();

                    Console.WriteLine($" (Шкода: {validItems[i].Stat})");
                }

                Console.Write("\nОбери предмет: ");

                Item? selectedItem = null;
                int selectedIndex = -1;

                while (true)
                {
                    Console.Write("\rОбери предмет: ");
                    var key = Console.ReadKey(true);

                    // вибір у цифрах
                    if (char.IsDigit(key.KeyChar))
                    {
                        int index = int.Parse(key.KeyChar.ToString());

                        if (index >= 1 && index <= validItems.Count)
                        {
                            selectedIndex = index - 1;
                            selectedItem = validItems[selectedIndex];

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{selectedIndex + 1}. {selectedItem.Name}");
                            Console.ResetColor();
                        }

                        continue;
                    }

                    // підтвердження
                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (selectedItem != null)
                            break;
                        else
                            continue;
                    }
                }
                if (selectedItem == null || slot == null)
                    return;

                player.Equip(slot.Value, selectedItem, inventory);
                //inventory.RemoveItem(selectedItem.Name);
                Console.WriteLine($"\nЕкіпіровано: {selectedItem.Name}");
                Console.Clear();
            }
           
        }
    }
}
