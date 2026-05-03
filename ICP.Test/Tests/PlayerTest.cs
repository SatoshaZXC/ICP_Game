using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICP.Entity;
using NUnit.Framework;

namespace ICP.Tests.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void CreatePlayer_ShouldReturnDefaultStats()
        {
            string playerName = "TestPlayer";
            int expectedHP = 100;
            int expectedDamage = 10;
            Player player = Player.CreatePlayer(playerName);
            TestContext.WriteLine($"Створено гравця з ім'ям: {player.Name}, HP: {player.BaseHP}, Damage: {player.BaseDamage}");
            Assert.Multiple(() =>
            {
                Assert.That(player.Name, Is.EqualTo(playerName), $"Очікував Name = {playerName}, але отримав {player.Name}");
                Assert.That(player.BaseHP, Is.EqualTo(expectedHP), $"Очікував HP = {expectedHP}, але отримав {player.BaseHP}");
                Assert.That(player.BaseDamage, Is.EqualTo(expectedDamage), $"Очікував Damage = {expectedDamage}, але отримав {player.BaseDamage}");
            });
        }
        [Test]
        public void EquipmentBonuses_ShouldIncreaseStats()
        {
            Player player = Player.CreatePlayer("TestPlayer");
            Item amulet = new Item("Amulet of Health", ItemType.Artifact, "Increases max HP", 20);
            Item sword = new Item("Sword of Strength", ItemType.Weapon, "Increases damage", 15);
            player.Equipment[EquipmentSlot.Neck] = amulet;
            player.Equipment[EquipmentSlot.RightHand] = sword;
            int expectedHP = player.BaseHP + amulet.Stat; // 100 + 20
            int expectedDamage = player.BaseDamage + sword.Stat; // 10 + 15
          
            Assert.Multiple(() =>
            {
                Assert.That(player.GetMaxHP(), Is.EqualTo(expectedHP), $"Очікував MaxHP = {expectedHP}, але отримав {player.GetMaxHP()}");
                Assert.That(player.GetDamage(), Is.EqualTo(expectedDamage), $"Очікував Damage = {expectedDamage}, але отримав {player.GetDamage()}");
            });
            TestContext.WriteLine($"Гравець одягнув амулет та меч. Очікуваний MaxHP: {expectedHP}, Очікуваний Damage: {expectedDamage}");
            TestContext.WriteLine($"Поточні MaxHP: {player.GetMaxHP()}, Поточний Damage: {player.GetDamage()}");
        }
        [Test]
        public void EquipItem_ShouldReplaceExistingItem()
        {
            Item sword1 = new Item("Sword of Strength", ItemType.Weapon, "Increases damage", 15);
            Item sword2 = new Item("Sword of Power", ItemType.Weapon, "Increases damage more", 25);

            Player player = Player.CreatePlayer("TestPlayer");

            player.Inventory.AddItem(sword1);
            player.Inventory.AddItem(sword2);

            player.Equip(EquipmentSlot.RightHand, sword1);
            TestContext.WriteLine($"Гравець одягнув {sword1.Name} id: {sword1.Id} в праву руку.");
            player.Equip(EquipmentSlot.RightHand, sword2);
            TestContext.WriteLine($"Гравець замінив {sword1.Name} id: {sword1.Id} на {sword2.Name} id: {sword2.Id} в правій руці.");
            Assert.Multiple(() =>
            {
                // 1. В екіпіровці має бути sword2
                Assert.That(player.Equipment[EquipmentSlot.RightHand].Id,
                    Is.EqualTo(sword2.Id),
                    "В слоті має бути sword2");
                TestContext.WriteLine($"У слоті RightHand знаходиться: {player.Equipment[EquipmentSlot.RightHand].Name} id: {player.Equipment[EquipmentSlot.RightHand].Id}");
                // 2. sword1 має повернутися до інвентарю
                Assert.That(
                    player.Inventory.GetAllItems().Any(i => i.Id == sword1.Id),
                    Is.True,
                    "sword1 має повернутись в інвентар");
                // 3. sword2 не повинен бути в інвентарі
                Assert.That(
                    player.Inventory.GetAllItems().Any(i => i.Id == sword2.Id),
                    Is.False,
                    "sword2 не має бути в інвентарі");
            });
        }
    }
}
