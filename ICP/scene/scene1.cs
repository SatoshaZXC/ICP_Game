using ICP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ICP.CoinFlip;
using static ICP.PrintWithDelay;
namespace ICP.scene
{
    internal class scene1
    {
        public static void FirstScene()
        {
            Console.Clear();
            /*#######################################################################################################################################################*/
           
            tempOpen tempOpen = new tempOpen();
            printWithDelay("\nНазви себе, мандрівнику... або залишишся безіменним серед тіней.", 35);
            Console.Write("\n> ");
            Player player = Player.CreatePlayer(Console.ReadLine());
            Console.Clear();
            EquipmentMenu equipmentMenu = new EquipmentMenu();

            Dictionary<string, Item> Weapons = new Dictionary<string, Item>();
            Dictionary<string, Item> MagicalWeapons = new Dictionary<string, Item>();
            Dictionary<string, Item> Consumables = new Dictionary<string, Item>();
            Dictionary<string, Item> Artifacts = new Dictionary<string, Item>();

            bool statusOpen_1 = false;
            bool statusOpen_2 = false;
            bool statusOpen_3 = false;
            bool statusOpen_4 = false;
            bool statusOpen_5 = false;

            

            Weapons["DarkSword"] = new Item("Темний меч", ItemType.Weapon, "Меч, покритий тьмою", 25);
            Weapons["SilverDagger"] = new Item("Срібний кинджал", ItemType.Weapon, "Кинджал, ячсфівлщзфівздол", 15);
            Consumables["HealthPotion"] = new Item("Зілля життя", ItemType.Consumable, "Відновлює здоров'я", 0, 1, 3);
            Artifacts["AmuletOfShadows"] = new Item("Амулет Тіней", ItemType.Artifact, "Додає +5 до максимального здоров'я", 5);
            MagicalWeapons["ShadowBow"] = new Item("Тіньовий лук", ItemType.MagicalWeapon, "Лук, що стріляє тінями", 30);

            player.Inventory.AddItem(Weapons["DarkSword"]);
            player.Inventory.AddItem(Weapons["SilverDagger"]);

            Chest oldChest = new Chest("Старий Сундук");

            // Шанси
            oldChest.AddTypeChance(ItemType.Weapon, 30);
            oldChest.AddTypeChance(ItemType.MagicalWeapon, 15);
            oldChest.AddTypeChance(ItemType.Consumable, 40);
            oldChest.AddTypeChance(ItemType.Artifact, 15);

            // Предмети
            oldChest.AddItems(ItemType.Weapon, Weapons);
            oldChest.AddItems(ItemType.MagicalWeapon, MagicalWeapons);
            oldChest.AddItems(ItemType.Consumable, Consumables);
            oldChest.AddItems(ItemType.Artifact, Artifacts);

            Chest potionShelf = new Chest("Полиця Алхіміка");

            // Шанси
            potionShelf.AddTypeChance(ItemType.Consumable, 80);
            potionShelf.AddTypeChance(ItemType.Artifact, 10);
            potionShelf.AddTypeChance(ItemType.MagicalWeapon, 10);

            // Предмети
            potionShelf.AddItems(ItemType.Consumable, Consumables);
            potionShelf.AddItems(ItemType.Artifact, Artifacts);
            potionShelf.AddItems(ItemType.MagicalWeapon, MagicalWeapons);

            Chest weaponStand = new Chest("Стенд Зброї");

            // Шанси
            weaponStand.AddTypeChance(ItemType.Weapon, 65);
            weaponStand.AddTypeChance(ItemType.MagicalWeapon, 25);
            weaponStand.AddTypeChance(ItemType.Artifact, 10);

            // Предмети
            weaponStand.AddItems(ItemType.Weapon, Weapons);
            weaponStand.AddItems(ItemType.MagicalWeapon, MagicalWeapons);
            weaponStand.AddItems(ItemType.Artifact, Artifacts);

            Chest darkAltar = new Chest("Темний Вівтар");

            // Шанси
            darkAltar.AddTypeChance(ItemType.Artifact, 60);
            darkAltar.AddTypeChance(ItemType.MagicalWeapon, 30);
            darkAltar.AddTypeChance(ItemType.Consumable, 10);

            // Предмети
            darkAltar.AddItems(ItemType.Artifact, Artifacts);
            darkAltar.AddItems(ItemType.MagicalWeapon, MagicalWeapons);
            darkAltar.AddItems(ItemType.Consumable, Consumables);

            Chest junkPile = new Chest("Купа Старих Речей");

            // Шанси
            junkPile.AddTypeChance(ItemType.Consumable, 50);
            junkPile.AddTypeChance(ItemType.Weapon, 25);
            junkPile.AddTypeChance(ItemType.Artifact, 15);
            junkPile.AddTypeChance(ItemType.MagicalWeapon, 10);

            // Предмети
            junkPile.AddItems(ItemType.Consumable, Consumables);
            junkPile.AddItems(ItemType.Weapon, Weapons);
            junkPile.AddItems(ItemType.Artifact, Artifacts);
            junkPile.AddItems(ItemType.MagicalWeapon, MagicalWeapons);

            /*#######################################################################################################################################################*/

            printWithDelay("Ти повільно відкриваєш очі...", 35);
            printWithDelay("Холодний камінь під спиною змушує тіло здригнутися.", 35);
            printWithDelay("Повітря важке, затхле... наче цей зал не бачив живих вже сотні років.", 35);
            printWithDelay("", 20);

            printWithDelay("Навколо тебе — величезна кам'яна зала.", 35);
            printWithDelay("Стовпи губляться у темряві під склепінням.", 35);
            printWithDelay("Ледь помітне зеленувате світло просочується крізь тріщини у старих плитах.", 35);

            printWithDelay("Тиша настільки глибока, що ти чуєш власне серцебиття.", 35);
            printWithDelay("І раптом усвідомлюєш...", 40);
            printWithDelay("ти тут абсолютно один.", 45);

            printWithDelay("", 10);

            printWithDelay("Озирнувшись, ти помічаєш кілька предметів у залі.", 35);
            printWithDelay("Схоже, хтось... або щось... залишило їх тут.", 35);

            Console.ReadKey();
            Console.Clear();

            bool? tempChoice = null;

            //bool? tempChoice = null;
            ConsoleKey? selectedKey = null;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Що ти зробиш?");
                Console.WriteLine();

                string stringStatusOpen_1 = statusOpen_1 ? "(Вже відкрито)" : "";
                string stringStatusOpen_2 = statusOpen_2 ? "(Вже обшукана)" : "";
                string stringStatusOpen_3 = statusOpen_3 ? "(Вже перевірено)" : "";
                string stringStatusOpen_4 = statusOpen_4 ? "(Вже oглянутo)" : "";
                string stringStatusOpen_5 = statusOpen_5 ? "(Вже обшукано)" : "";



                Console.WriteLine("1. Заглянути у старий сундук" + stringStatusOpen_1);
                Console.WriteLine("2. Оглянути полицю з зіллями" + stringStatusOpen_2);
                Console.WriteLine("3. Підійти до стенду зі зброєю" + stringStatusOpen_3);
                Console.WriteLine("4. Оглянути кам'яний вівтар" + stringStatusOpen_4);
                Console.WriteLine("5. Обшукати купу старих речей у кутку" + stringStatusOpen_5);
                Console.WriteLine("6. Оцінити своє спорядження");
                Console.WriteLine("7. Оглянути свої пожитки серед цієї мертвої тиші");
                while (true)
                {

                    Console.Write("\rТвій вибір: ");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            selectedKey = ConsoleKey.D1;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Сундук");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D2:
                            selectedKey = ConsoleKey.D2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Полиця");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D3:
                            selectedKey = ConsoleKey.D3;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Зброя");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D4:
                            selectedKey = ConsoleKey.D4;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Вівтар");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D5:
                            selectedKey = ConsoleKey.D5;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Купа речей");
                            Console.ResetColor();
                            break;
                            
                        case ConsoleKey.D6:
                            selectedKey = ConsoleKey.D6;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Подивитися на екіпірування");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.D7:
                            selectedKey = ConsoleKey.D7;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Оглянути інвентар");
                            Console.ResetColor();
                            break;

                        case ConsoleKey.Enter:
                            if (tempChoice != null) // якщо вибір уже зроблено
                                break;
                            else
                                continue;

                        default:
                            continue;
                    }

                    // якщо натиснули Enter — виходимо
                    if (keyInfo.Key == ConsoleKey.Enter)
                        break;

                    tempChoice = true; // просто прапор, що вибір зроблено


                }
                switch (selectedKey)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        printWithDelay("Ти підходиш до старого сундука. Його кришка скрипить...", 35);

                        if (!statusOpen_1 && CoinFlip.FlipCoin())
                        {
                            printWithDelay("Всередині щось блиснуло у темряві.", 35);
                            tempOpen.openTemp(oldChest, player.Inventory);
                        }
                        else
                        {
                            printWithDelay("Сундук порожній, але ти відчуваєш легкий вітерець.", 35);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        statusOpen_1 = true;

                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        printWithDelay("Полиця вкрита пилом.", 35);

                        if (!statusOpen_2 && CoinFlip.FlipCoin())
                        {
                            printWithDelay("Кілька пляшечок ще зберегли дивну світлу рідину.", 35);
                            tempOpen.openTemp(potionShelf, player.Inventory);
                        }
                        else
                        {
                            printWithDelay("Нічого корисного не залишилось.", 35);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        statusOpen_2 = true;

                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        printWithDelay("На стенді висять кілька видів зброї.", 35);

                        if (!statusOpen_3 && CoinFlip.FlipCoin())
                        {
                            printWithDelay("Одна з них притягує твій погляд.", 35);
                            tempOpen.openTemp(weaponStand, player.Inventory);
                        }
                        else
                        {
                            printWithDelay("Ти не знайшов нічого корисного.", 35);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        statusOpen_3 = true;

                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        printWithDelay("Кам'яний вівтар вкритий символами.", 35);

                        if (!statusOpen_4 && CoinFlip.FlipCoin())
                        {
                            printWithDelay("На ньому лежить дивний артефакт.", 35);
                            tempOpen.openTemp(darkAltar, player.Inventory);
                        }
                        else
                        {
                            printWithDelay("Але нічого корисного не було.", 35);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        statusOpen_4 = true;

                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        printWithDelay("Купа старих речей ледве тримається разом.", 35);

                        if (!statusOpen_5 && CoinFlip.FlipCoin())
                        {
                            printWithDelay("Ти знаходиш щось у глибині.", 35);
                            tempOpen.openTemp(junkPile, player.Inventory);
                        }
                        else
                        {
                            printWithDelay("Нічого цікавого...", 35);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        statusOpen_5 = true;

                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        printWithDelay("Ти оглядаєш своє спорядження.", 35);
                        equipmentMenu.equipmentMenu(player);
                        Console.Clear();
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        printWithDelay("Ти оглядаєш свої пожитки.", 35);
                        player.Inventory.PrintInventory();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
                Console.Clear();
            }
        }
    }
}
