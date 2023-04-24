using ServerSideApplication.V1;

namespace ServerSideApplication.Domain
{
    public class PetService
    {
        private readonly ICollection<Pet> data = new List<Pet>()
        {
            new Pet
                {
                    Id = 1,
                    Name = "Jack",
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Dog"
                    },
                    PhotoUrls = new List<string>
                    {
                        "/photo1.png",
                        "/photo2.png"
                    },
                    Status = PetStatus.Available,
                    Tags = new List<Tag>()
                },
            new Pet
                {
                    Id = 2,
                    Name = "Bella",
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Dog"
                    },
                    PhotoUrls = new List<string>
                    {
                        "/photo1.png",
                        "/photo2.png"
                    },
                    Status = PetStatus.Available,
                    Tags = new List<Tag>()
                },
            new Pet
                {
                    Id = 3,
                    Name = "Max",
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Dog"
                    },
                    PhotoUrls = new List<string>
                    {
                        "/photo1.png",
                        "/photo2.png"
                    },
                    Status = PetStatus.Pending,
                    Tags = new List<Tag>()
                },
            new Pet
                {
                    Id = 4,
                    Name = "Charlie",
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Dog"
                    },
                    PhotoUrls = new List<string>
                    {
                        "/photo1.png",
                        "/photo2.png"
                    },
                    Status = PetStatus.Sold,
                    Tags = new List<Tag>()
                }
        };

        public ICollection<Pet> FindByStatusAsync(Status status)
        {
            return data.Where(d => d.Status == (PetStatus)status).ToList();
        }
    }
}
