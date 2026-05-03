using ICP.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.AssertTests.AssertTests
{
    public static class InventoryAssertTests
    {
        public static void RunAll()
        {
            Test_AddItem_ShouldStoreItem();
            Test_RemoveItem_ShouldDeleteItem();
            Test_GetItem_ShouldReturnCorrectItem();
        }
        // 1. Додавання предмета
        private static void Test_AddItem_ShouldStoreItem()
        {
            var inventory = new Inventory();
            var item = new Item("Sword", ItemType.Weapon, "Test sword", 10);

            inventory.AddItem(item);

            Debug.Assert(
                inventory.GetAllItems().Count == 1,
                "Item повинен додаватися до інвентарю"
            );

            Console.WriteLine("Test 1 passed: AddItem works");
        }

        // 2. Видалення предмета
        private static void Test_RemoveItem_ShouldDeleteItem()
        {
            var inventory = new Inventory();
            var item = new Item("Shield", ItemType.Weapon, "Test shield", 5);

            inventory.AddItem(item);
            inventory.RemoveItem(item.Id);

            Debug.Assert(
                inventory.GetAllItems().Count == 0,
                "Item повинен бути видалений з інвентарю"
            );

            Console.WriteLine("Test 2 passed: RemoveItem works");
        }

        // 3. Отримання предмета за ID
        private static void Test_GetItem_ShouldReturnCorrectItem()
        {
            var inventory = new Inventory();
            var item = new Item("Potion", ItemType.Consumable, "Heal", 0);

            inventory.AddItem(item);

            var result = inventory.GetItem(item.Id);

            Debug.Assert(
                result != null && result.Id == item.Id,
                "GetItem має повертати правильний предмет"
            );

            Console.WriteLine("Test 3 passed: GetItem works");
        }

    }
}
