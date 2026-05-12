using ICP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.XUnit.Test.Tests
{
    public class PlayerTest
    {
        private readonly Player _player;
        private readonly Item _sword;

        public PlayerTest()
        {
            _player = Player.CreatePlayer("TestHero");
            _sword =
                new Item(
                    "Dark Sword",
                    ItemType.Weapon,
                    "Shadow blade",
                    15);
        }

        [Fact]
        public void Inventory_ShouldStartEmpty()
        {
            Assert.Empty(
                _player.Inventory.GetAllItems());
        }

        [Fact]
        public void AddItem_ShouldIncreaseCount()
        {
            _player.Inventory.AddItem(_sword);

            Assert.Single(
                _player.Inventory.GetAllItems());
        }
        [Fact]
        public void GetItem_ShouldThrowException_WhenItemNotFound()
        {
            Guid nonExistentId = Guid.NewGuid();
            Assert.Throws<Exception>(
                () => _player.Inventory.GetItem(nonExistentId));
        }
        [Fact]
        public void Wrong_HP_Test()
        {
            Player player = Player.CreatePlayer("Hero");

            Assert.Equal(999, player.BaseHP);
        }
    }
}
