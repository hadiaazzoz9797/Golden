using Golden.Entities;
using Golden.Model;
using Golden.Repository.IRepository;

namespace Golden.Service
{
    public class SevicesService : ISevicesService
    {
        private IConfiguration Configuration;
        private readonly IServicesRepository _serviceRepository;




        public SevicesService(IServicesRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        

        public async Task<List<ServicesDto>> GetAllAsync()
        {
            var hh = 0;

            var Services = await _serviceRepository.GetAllAsync();
            if (Services == null)
                throw new Exception("No item Found");

            var services = new List<ServicesDto>();
            

            foreach (var item in Services)
            {
                var details = new List<DetaisDto>();
                var cat = new ServicesDto()
                {
                    Description = item.Description,
                    ServiceName = item.ServiceName,
                    ServicesId = item.ServicesId,
                    Servicetype = item.Servicetype,


                };
                foreach ( var obj in item.Details)
                {
                    var det = new DetaisDto() 
                    {
                     DetailName = obj.DetailName,
                      DetailsId = obj.DetailsId,
                      
                    };
                    details.Add(det);
                }
                cat.Details = details;
                services.Add(cat);
            }

            return services;


        }

        public async Task<ServicesDto> Get(int id)
        {
            var service = _serviceRepository.Get(id); // Assuming _SperVisorRepository.Get returns a Task<SuperVisor> or similar
            var item = new ServicesDto()
            {
                Servicetype = service.Servicetype,
                ServicesId = service.ServicesId,
                ServiceName = service.ServiceName,
                Description = service.Description,
            };
            
          var details = service.Details.Where(i => i.ServicesId == service.ServicesId);
            var Details = new List<DetaisDto>();
            foreach (var obj in details) 
            { 
                var item2 = new DetaisDto()
                {
                 DetailName=obj.DetailName,
                 DetailsId=obj.DetailsId,


                };
                Details.Add(item2);
            }
            item.Details = Details;
          
            return item;
        }

        public async Task CreateAsync(ServicesModel model)
        {


            var cat = new Services()
            {
                Description = model.Description,
                ServiceName = model.ServiceName,
                Servicetype = model.Servicetype,
                

            };
            


            //_serviceRepository.CreateAsync(cat);
            //var id = cat.ServicesId;
            //foreach (var item in model.details)
            //{

            //    var det = new Details()
            //    {
            //        DetailName = item.DetailName,


            //    };
            //    det.ServicesId = id;
            //    cat.Details.Add(det);
            //}

            var newId = await _serviceRepository.CreateAsync(cat);

            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Service");


        }
        public async Task Update(int id, ServicesUpdate model)
        {
            var service = _serviceRepository.Get(id);
            if (service == null)
                throw new Exception("Not Found");
            // التحقق من القيم المستلمة وتحديث الخصائص الصحيحة
            if (model.Servicetype != null)
            {
                service.Servicetype = model.Servicetype;
            }
            if (model.ServiceName != null)
            {
                service.ServiceName = model.ServiceName;
            }
            if (model.Description != null)
            {
                service.Description = model.Description;
            }

            // التحقق من القيم المستلمة وتحديث الخصائص الصحيحة


            var Result = _serviceRepository.Update(id, service);
            if (Result == -1) throw new Exception("Not Found");


        }
        public async Task Delete(int id)
        {

            var Result = _serviceRepository.Delete(id);
            if (Result == -1) throw new Exception("Not Found");

        }
    }
}
