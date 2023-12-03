using Golden.Model;

namespace Golden.Service
{
    public interface IClientService
    {
        Task CreateAsync(ClientModel model);
        Task Delete(int id);
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> GetClient(int id);
        Task Update(int id, EditClientModel model);
    }
}