using Golden.Entities;

namespace Golden.Repository.IRepository
{
    public interface IClientRepository1
    {
        Task<int> CreateClient(Client entity);
        Task<int> Delete(int id);
        Task<int> Edit(Client model, int id);
        Client Get(int id);
        Task<Client> GetClient(int id);
        Task<List<Client>> GetClientAsync();
        Task<Client> SearchUser(string Email);
    }
}