using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Fiware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiwareController: ControllerBase
    {


        // string id = "Superman";
        // string name = "Clark Kent";
        // mydata = new Data();
        // mydata Set();
        // mydata.name = nameof;

        private static List<Entity> FiwareEntities = new List<Entity>{
            // new Entity {
            //     new List<Data> {
            //         new Data {id="Superman"}
            //     }
            // }
        };



        [HttpGet]
        public ActionResult<List<Entity>> Get()
        {
            return Ok(FiwareEntities);
        }

        // [HttpGet]
        // [Route("{Id}")]
        // public ActionResult<Entity> Get(Values data)
        // {
        //     var fiwareEntity = Entity.Find(x => x.data == data);
        //     return fiwareEntity == null ? NotFound() : Ok(fiwareEntity);
        // }

        [HttpPost]
        public ActionResult Post(Entity fiwareEntity)
        {
            // var existingSuperheroItem = Entity.Find(x => x.Id == superheroItem.Id);
            // if (existingSuperheroItem != null)
            // {
            //     return Conflict("Cannot create the Id because it already exists.");
            // }
            // else
            // {
            FiwareEntities.Add(fiwareEntity);
            // var resourceUrl = Request.Path.ToString() + '/' + fiwareEntity.data;
            // return Created(resourceUrl, fiwareEntity);
            // }
            return Created("hugo",fiwareEntity);
        }
    }
}