using ServerSideApplication.Domain;
using ServerSideApplication.V1;

namespace ServerSideApplication.Controllers.V1
{
    public class PetControllerImplementation : IPetController
    {
        private readonly PetService _petService;

        public PetControllerImplementation(PetService petService)
        {
            _petService = petService;
        }

        public async Task<ICollection<Pet>> FindByStatusAsync(Status status)
        {
            return _petService.FindByStatusAsync(status);
        }

        public Task<ICollection<Pet>> FindByTagsAsync(IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task PetDeleteAsync(string api_key, long petId)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> PetGetAsync(long petId)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> PetPostAsync(Pet body)
        {
            throw new NotImplementedException();
        }

        public Task PetPostAsync(long petId, string name, string status)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> PetPutAsync(Pet body)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UploadImageAsync(long petId, string additionalMetadata, IFormFile body)
        {
            throw new NotImplementedException();
        }
    }
}
