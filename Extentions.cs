using Catalog.Dtos;
using Catalog.Models;
using System;

namespace Catalog
{
    public static class Extentions
    {
        public static ItemDto AsDto(this Item item) {
            return new ItemDto{
                Id = item.Id,
                name = item.name,
                price = item.price,
                createdDate = item.createdDate
            };
        }
    }
}