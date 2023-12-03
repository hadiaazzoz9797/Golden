using Golden.Entities;
using Golden.Model;

namespace Golden.Repository.IRepository
{
    public interface ISuperVisorRepository
    {
        Task<int> CreateAsync(Supervisor entity);
        int Delete(int id);
        Supervisor Get(int id);
        List<Supervisor> GetAll();
        Task<List<Supervisor>> GetAllAsync();
        Supervisor GetFirstOrDefault(int id);
        int Update(int id, Supervisor model);
    }
}