namespace SuperHeroAPIDotNet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
                }
            };
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddHero(SuperHero hero)
        {

            _context.SuperHeroes.Add(hero); // Addition hero to the List of superHeroes
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHero(int id)// 
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return false;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHeroes(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();  

            return hero;
        }
    }
}
