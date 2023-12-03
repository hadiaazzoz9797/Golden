using Golden.Entities;
using Golden.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Golden.Repository
{
    public class ClientRepository : IClientRepository1
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Client>> GetClientAsync()
        {

            return _db.clients.ToList();
        }

        public async Task<int> CreateClient(Client entity)
        {
            _db.clients.Add(entity);
            return await _db.SaveChangesAsync();

        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        public async Task<int> Edit(Client model, int id)
        {
            var client = _db.clients.FirstOrDefault(c => c.ClientId == id);

            client.PhoneNumber = model.PhoneNumber;
            client.Email = model.Email;
            client.Password = model.Password;
            client.ClientName = model.ClientName;

            //user.Password = model.Password;
            //user.PhoneNumber = model.PhoneNumber;
            //user.VertificationToken = CreateRandomToken();
            return _db.SaveChanges();


        }
        public async Task<Client> SearchUser(string Email)
        {
            return await _db.clients.FirstOrDefaultAsync(u => u.Email == Email);


        }
        public async Task<Client> GetClient(int id)
        {
            return _db.clients.FirstOrDefault(x => x.ClientId == id);

        }
        public Client Get(int id)
        {
            return _db.clients.FirstOrDefault(x => x.ClientId == id);

        }
        public async Task<int> Delete(int id)
        {
            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            _db.clients.Remove(dbEntity);
            return _db.SaveChanges();

        }
    }
}
