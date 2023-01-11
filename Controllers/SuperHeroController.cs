using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotNet7.Services.SuperHeroService;

namespace SuperHeroAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        
        /// <summary>
        /// Olzhas 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet] //[HttpGet("{id}")] another way without [Route("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)// added parameter id
        {
            var hero = await _superHeroService.GetSingleHeroes(id);
            if (hero is null)
                return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)// added parameter hero as an object
        {
            var result = await _superHeroService.AddHero(hero);

            return Ok(result);
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)// 
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            return Ok(result);
        }
    }
}
