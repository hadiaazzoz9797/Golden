using Golden.Entities;
using Golden.Model;
using Golden.Repository;
using Golden.Repository.IRepository;

namespace Golden.Service
{
    public class SuperVisorService : ISuperVisorService
    {

        private IConfiguration Configuration;
        private readonly ISuperVisorRepository _SperVisorRepository;

        public SuperVisorService(ISuperVisorRepository sperVisorRepository)
        {
            _SperVisorRepository = sperVisorRepository;
        }


        public async Task<List<SuperVisorDto>> GetAllAsync()
        {

            var SuperVisors = await _SperVisorRepository.GetAllAsync();
            if (SuperVisors == null)
                throw new Exception("No item Found");

            var superVisors = new List<SuperVisorDto>();

            foreach (var SuperVisor in SuperVisors)
            {
                var cat = new SuperVisorDto()
                {
                    SuperVisorId = SuperVisor.SuperVisorId,
                    Name = SuperVisor.Name,

                };

                superVisors.Add(cat);
            }

            return superVisors;


        }

        public async Task<SuperVisorDto> Get(int id)
        {
            var supervisor = _SperVisorRepository.Get(id); // Assuming _SperVisorRepository.Get returns a Task<SuperVisor> or similar
            var item = new SuperVisorDto()
            {
                Name = supervisor.Name,
                SuperVisorId = supervisor.SuperVisorId,
            };
            return item;
        }

        public async Task CreateAsync(SuperVisorModel model)
        {


            var cat = new Supervisor()
            {
                Name = model.Name,

            };

            var newId = await _SperVisorRepository.CreateAsync(cat);
            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Category");


        }
        public async Task Update(int id, SuperVisorUpdate model)
        {
            var supervisor = _SperVisorRepository.Get(id);
            if (supervisor == null)
                throw new Exception("Not Found");
            // التحقق من القيم المستلمة وتحديث الخصائص الصحيحة
            if (model.Name != null)
            {
                supervisor.Name = model.Name;
            }
            // التحقق من القيم المستلمة وتحديث الخصائص الصحيحة


            var Result = _SperVisorRepository.Update(id, supervisor);
            if (Result == -1) throw new Exception("Not Found");


        }
        public async Task Delete(int id)
        {

            var Result = _SperVisorRepository.Delete(id);
            if (Result == -1) throw new Exception("Not Found");

        }
    }
}
