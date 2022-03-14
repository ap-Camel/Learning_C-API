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
    }
}