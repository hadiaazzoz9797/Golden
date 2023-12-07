using Golden.Entities;

namespace Golden.Repository.IRepository
{
    public interface IServicesRepository
    {
        Task<int> CreateAsync(Services entity);
        int Delete(int id);
        Services Get(int id);
        List<Services> GetAll();
        Task<List<Services>> GetAllAsync();
        Services GetFirstOrDefault(int id);
        int Update(int id, Services model);
    }
}