using Golden.Entities;
using Golden.Model;
using Golden.Repository;
using Golden.Repository.IRepository;

namespace Golden.Service
{
    public class ResponsibleService : IResponsibleService
    {

        private IConfiguration Configuration;
        private readonly IResponsibleRepository _SperVisorRepository;
        

        public ResponsibleService(IResponsibleRepository sperVisorRepository)
        {
            _SperVisorRepository = sperVisorRepository;
        }


        public async Task<List<ResponsibleDto>> GetAllAsync()
        {

            var SuperVisors = await _SperVisorRepository.GetAllAsync();
            if (SuperVisors == null)
                throw new Exception("No item Found");

            var superVisors = new List<ResponsibleDto>();

            foreach (var SuperVisor in SuperVisors)
            {
                var cat = new ResponsibleDto()
                {
                    ResponsibleId = SuperVisor.ResponsibleId,
                    Name = SuperVisor.Name,
                    Type = SuperVisor.Type,


                };

                superVisors.Add(cat);
            }

            return superVisors;


        }

        public async Task<ResponsibleDto> Get(int id)
        {
            var supervisor = _SperVisorRepository.Get(id); // Assuming _SperVisorRepository.Get returns a Task<SuperVisor> or similar
            var item = new ResponsibleDto()
            {
                Name = supervisor.Name,
                ResponsibleId = supervisor.ResponsibleId,
                Type = supervisor.Type,
            };
            return item;
        }

        public async Task CreateAsync(ResponsibleModel model)
        {
            

            var cat = new Responsible()
            {
                Name = model.Name,
                Type =(int)model.Type
,
            };

            var newId = await _SperVisorRepository.CreateAsync(cat);
            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Category");


        }
        public async Task Update(int id, ResponsibleUpdate model)
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
