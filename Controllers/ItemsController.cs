using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Interfaces;
using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository repository;

        public ItemsController(IInMemItemsRepository repository){
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems() {
            var items = repository.GetItems().Select( item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
         public ActionResult<ItemDto> GetItems(Guid id) {
            var item = repository.GetItem(id);
            if(item is null) {
                return NotFound();
            }
            return item.AsDto();
        }

        // POST /item
        [HttpPost]
        public ActionResult<ItemDto> PostItem(CreateItemDto createItem) {

            Item item = new Item() {
                Id = Guid.NewGuid(),
                name = createItem.name,
                price = createItem.price,
                createdDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItems), new {id = item.Id}, item.AsDto());
        }

        // Post /item/{id}
        [HttpPut("{id}")]
        public ActionResult PutItem(Guid id, UpdateItemDto item) {
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                name = existingItem.name,
                price = existingItem.price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        // Delete /item/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id) {
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}