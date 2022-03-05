using System.Collections.Generic;
using Catalog.Models;
using System;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new() 
        {
            new Item {Id = Guid.NewGuid(), name = "Potion", price = 9, createdDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), name = "Iron swrod", price = 20, createdDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), name = "Bronze shield", price = 18, createdDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems() 
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        
    }
}