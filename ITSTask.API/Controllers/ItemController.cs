using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTask.Model;
using ITSTask.Repository.Contracts;
using ITSTask.Repository.Contracts.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITSTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
       
        iItemRep _iItemRep;
        public ItemController(iItemRep itemRep) 
        {
            
            _iItemRep = itemRep;
        }

        [HttpGet("getAllItems")]
        public IActionResult getAllItems()
        {
            return Ok(_iItemRep.GetAll().ToList());
        }

        [HttpPost("AddOrUpdate")]
        public IActionResult AddOrUpdate(Item item)
        {
            try
            {
                _iItemRep.AddOrUpdate(item,item.id);
               
                return Ok(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _iItemRep.Remove(id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
