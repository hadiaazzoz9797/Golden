using Golden.Entities;
using Golden.Model;

namespace Golden.Repository.IRepository
{
    public interface IResponsibleRepository
    {
        Task<int> CreateAsync(Responsible entity);
        int Delete(int id);
        Responsible Get(int id);
        List<Responsible> GetAll();
        Task<List<Responsible>> GetAllAsync();
        Responsible GetFirstOrDefault(int id);
        int Update(int id, Responsible model);
    }
}