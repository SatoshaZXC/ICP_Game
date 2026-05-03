using ICP.Entity;

namespace ICP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            scene.scene1.FirstScene();


       


            //Player player = new Player("Герой",100,10);
            //Inventory playerInventory = new Inventory();
            //EquipmentMenu equipmentMenu = new EquipmentMenu();



            //Dictionary<string, Item> Weapons = new Dictionary<string, Item>();
            //Dictionary<string, Item> MagicalWeapons = new Dictionary<string, Item>();
            //Dictionary<string, Item> Consumables = new Dictionary<string, Item>();
            //Dictionary<string, Item> Artifacts = new Dictionary<string, Item>();

            //Weapons["DarkSword"] = new Item("Темний меч", ItemType.Weapon, "Меч, покритий тьмою", 25);
            //Weapons["SilverDagger"] = new Item("Срібний кинджал", ItemType.Weapon, "Кинджал, ячсфівлщзфівздол", 15);
            //Consumables["HealthPotion"] = new Item("Зілля життя", ItemType.Consumable, "Відновлює здоров'я", 0, 1, 3);
            //Artifacts["AmuletOfShadows"] = new Item("Амулет Тіней", ItemType.Artifact, "Додає +5 до максимального здоров'я", 5);
            //MagicalWeapons["ShadowBow"] = new Item("Тіньовий лук", ItemType.MagicalWeapon, "Лук, що стріляє тінями", 30);

            //// Создаём сундук
            //Chest darkChest = new Chest("Сундук Темряви");

            //// Настраиваем шансы выпадения типа
            //darkChest.AddTypeChance(ItemType.Weapon, 40);         // 40%
            //darkChest.AddTypeChance(ItemType.MagicalWeapon, 20);  // 20%
            //darkChest.AddTypeChance(ItemType.Consumable, 30);     // 30%
            //darkChest.AddTypeChance(ItemType.Artifact, 10);       // 10%

            //// Добавляем предметы
            //darkChest.AddItems(ItemType.Weapon, Weapons);
            //darkChest.AddItems(ItemType.Consumable, Consumables);
            //darkChest.AddItems(ItemType.Artifact, Artifacts);
            //darkChest.AddItems(ItemType.MagicalWeapon, MagicalWeapons);

            //tempOpen tempOpen = new tempOpen();
            //tempOpen.openTemp(darkChest, playerInventory);
            //tempOpen.openTemp(darkChest, playerInventory);
            //tempOpen.openTemp(darkChest, playerInventory);
            //tempOpen.openTemp(darkChest, playerInventory);
            //tempOpen.openTemp(darkChest, playerInventory);

            //// Открываем сундук
            //Item loot = darkChest.Open();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine($"Випав предмет: {loot}");
            //Console.ResetColor();
            //Console.WriteLine("Забрати?");
            //Console.WriteLine("1. Так\n2. Ні");
            //bool tempChoice = true;
            //while (true)
            //{
            //    Console.Write("\rТвій вибір:");
            //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.D1:
            //            tempChoice = true;
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.Write("Так");
            //            Console.ResetColor();
            //            //Console.WriteLine(keyInfo.Key);
            //            break;
            //        case ConsoleKey.D2:
            //            tempChoice = false;
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.Write(" Ні");
            //            Console.ResetColor();
            //            //Console.WriteLine(keyInfo.Key);
            //            break;
            //        case ConsoleKey.Enter:

            //            break;


            //        default:

            //            continue;
            //    }

            //    if (keyInfo.Key == ConsoleKey.Enter)
            //        break;

            //}
            //if (tempChoice == true)
            //    playerInventory.AddItem(loot);
            //Console.WriteLine();

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //playerInventory.PrintInventory();
            //Console.ResetColor();

            //equipmentMenu.equipmentMenu(player,playerInventory);
            //player.PrintEquipment();
            //Console.WriteLine(player.GetMaxHP());
            //Console.WriteLine(player.GetDamage());
            //CoinFlip.FlipCoin();
        }
    }
}
