namespace SuperHeroAPIDotNet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
       Task<List<SuperHero>> GetAllHeroes();
       Task<SuperHero?> GetSingleHeroes(int id);
       Task<bool> AddHero(SuperHero hero);
       Task<SuperHero>? UpdateHero(int id, SuperHero request);
       Task<bool> DeleteHero(int id);
    }
}
