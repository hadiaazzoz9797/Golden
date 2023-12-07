using Golden.Model;

namespace Golden.Service
{
    public interface ISevicesService
    {
        Task CreateAsync(ServicesModel model);
        Task Delete(int id);
        Task<ServicesDto> Get(int id);
        Task<List<ServicesDto>> GetAllAsync();
        Task Update(int id, ServicesUpdate model);
    }
}