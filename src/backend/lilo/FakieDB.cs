using lilo.Models;

namespace lilo
{
    public class FakieDB
    {
        public static List<Videogame> videogames = new List<Videogame>()
        {
            new Videogame() { Id = 1, Name = "Age of Mythology" },
            new Videogame() { Id = 2, Name = "Super Mario Bros" }
        };

        public static List<Store> stores = new List<Store>()
        {
            new Store()
            { 
                Id= 1, 
                Name = "GamersOn", 
                Description = "Best place for gamers", 
                Address = "Avenida siempre viva"
            }
        };
    }
}
