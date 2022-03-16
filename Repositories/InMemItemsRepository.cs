using System.Collections.Generic;
using Catalog.Models;
using System;
using System.Linq;
using Catalog.Interfaces;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), name = "Potion", price = 9, createdDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), name = "Iron swrod", price = 20, createdDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), name = "Bronze shield", price = 18, createdDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            int index = items.FindIndex(itemIndex => item.Id == itemIndex.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            int index = items.FindIndex(itemIndex => id == itemIndex.Id);
            items.RemoveAt(index);
        }
    }
}