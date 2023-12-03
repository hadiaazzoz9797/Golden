using Golden.Entities;
using Golden.Model;
using Golden.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Golden.Service
{
    public class ClientService : IClientService
    {

        private IConfiguration Configuration;
        private readonly IClientRepository1 _clientRepository;

        public ClientService(IClientRepository1 clientRepository, IConfiguration _Configuration)
        {
            _clientRepository = clientRepository;
            Configuration = _Configuration;

        }
        public async Task<List<ClientDto>> GetAllAsync()
        {
            var SiteUrl = Configuration["SiteUrl"];
            var Clients = await _clientRepository.GetClientAsync();
            if (Clients == null)
                throw new Exception("No item Found");

            var clients = new List<ClientDto>();

            foreach (var client in Clients)
            {
                var obj = new ClientDto()
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName,
                    Email = client.Email,
                    Password = client.Password,
                    PhoneNumber = client.PhoneNumber,

                    //Logo = SiteUrl + "Images/" + category.Logo,
                };

                clients.Add(obj);
            }

            return clients;


        }
        public async  Task<ClientDto> GetClient(int id) 
        {
         var client = await _clientRepository.GetClient(id);
            var obj = new ClientDto()
            { ClientId = client.ClientId,
              ClientName=client.ClientName,
              Email=client.Email,
              Password=client.Password,
              PhoneNumber=client.PhoneNumber,
            
            };
            return obj;
        }
        //public async Task<IActionResult> SerchClient(string Email)
        //{
        //    var obj = _clientRepository.SearchUser(Email);
        //    if (obj == null)
        //    {
        //        return Unauthorized();
        //    }

        //    // إذا وجد العميل، يمكنك تنفيذ الإجراءات الإضافية هنا
        //    // يمكنك إعادة استخدام IActionResult أو تغييرها إلى نوع ActionResult الذي يناسب احتياجاتك
        //    return Ok(obj); // أو أي نوع آخر يعكس نجاح العملية
        //}

        public async Task CreateAsync(ClientModel model)
        {
            //var fileName = _mediaHelper.SaveFile(model.Logo);

            var obj = new Client()
            {
                ClientName = model.ClientName,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,

            };

            var newId = await _clientRepository.CreateClient(obj);
            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Client");


        }

        public async Task Update(int id, EditClientModel model)
        {
            var client = _clientRepository.Get(id);
            if (client == null)
            {
                throw new Exception("Not Found");
            }

            // التحقق من القيم المستلمة وتحديث الخصائص الصحيحة
            if (model.ClientName != null)
            {
                client.ClientName = model.ClientName;
            }

            if (model.Email != null)
            {
                client.Email = model.Email;
            }

            if (model.PhoneNumber != null)
            {
                client.PhoneNumber = model.PhoneNumber;
            }

            if (model.Password != null)
            {

                client.Password = model.Password;
            }

            // قم بتحديث العميل باستخدام الإصدار المحدث
            var result = _clientRepository.Edit(client, id);

            if (await result == -1)
            {
                throw new Exception("Not Found");
            }


        }

        public async Task Delete(int id)
        {

            var Result = _clientRepository.Delete(id);
            if (await Result == -1) throw new Exception("Not Found");

        }
    }
}
