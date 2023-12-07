using Golden.Model;

namespace Golden.Service
{
    public interface IResponsibleService
    {
        Task CreateAsync(ResponsibleModel model);
        Task Delete(int id);
        Task<List<ResponsibleDto>> GetAllAsync();
        Task<List<SuperVisorDto>> GetSupervisor(int type);
        Task<List<ContractorDto>> GetContractor(int type);
        Task<ResponsibleDto> Get(int id);
        Task Update(int id, ResponsibleUpdate model);
    }
}