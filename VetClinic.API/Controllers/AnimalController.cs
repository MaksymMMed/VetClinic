using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.BLL.Services.Interfaces;
using VetClinic.DAL.EntitySearchConditions;
using VetClinic.DAL.Exeptions;

namespace VetClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService Service;
        public AnimalController(IAnimalService _Service)
        {
            Service = _Service;
        }

        [HttpGet]
        [Authorize(Policy = "LowLevel")]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AnimalResponse>> GetAnimalByIdAsync(string id)
        {
            try
            {
                var item = await Service.GetEntityByIdAsync(id);
                return Ok(item);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message});
            }
        }

        [HttpGet]
        [Authorize(Policy = "HighLevel")]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnimalResponse>>> GetAllAnimals()
        {
            try
            {
                var item = await Service.GetAllEntitiesAsync();
                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet]
        [Authorize(Policy = "HighLevel")]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnimalResponse>>> GetAnimalsByCondition([FromQuery] AnimalCondition condition)
        {
            try
            {
                var item = await Service.GetEntitiesByConditionAsync(condition);
                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "LowLevel")]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAnimal ([FromBody] AnimalRequest request)
        {
            try
            {
                await Service.UpdateEntity(request);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddAnimal([FromBody] AnimalRequest request)
        {
            try
            {
                await Service.AddEntityAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAnimalById(string id)
        {
            try
            {
                await Service.DeleteEntityAsync(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
