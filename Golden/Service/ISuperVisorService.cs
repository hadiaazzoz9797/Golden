using Golden.Model;

namespace Golden.Service
{
    public interface ISuperVisorService
    {
        Task CreateAsync(SuperVisorModel model);
        Task Delete(int id);
        Task<List<SuperVisorDto>> GetAllAsync();
        Task<SuperVisorDto> Get(int id);
        Task Update(int id, SuperVisorUpdate model);
    }
}