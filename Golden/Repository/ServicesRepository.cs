using Golden.Entities;
using Golden.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Golden.Repository
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly ApplicationDbContext _db;
        public ServicesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Services> GetAll()
        {

            return _db.services.ToList();

        }
        public async Task<List<Services>> GetAllAsync()
        {

            return await _db.services.ToListAsync();

        }

        public Services Get(int id)
        {

            return _db.services.Include(x => x.Details).FirstOrDefault(x=>x.ServicesId==id);

        }
        public Services GetFirstOrDefault(int id)
        {
            return _db.services.FirstOrDefault(x => x.ServicesId == id);

        }
        //public int Create(Category entity)
        //{
        //    _db.Categories.Add(entity);
        //    return _db.SaveChanges();

        //}
        public async Task<int> CreateAsync(Services entity)
        {
            _db.services.Add(entity);
            return await _db.SaveChangesAsync();

        }
        public int Update(int id, Services model)
        {

            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            dbEntity.Servicetype = model.Servicetype;
            dbEntity.ServiceName = model.ServiceName;
            dbEntity.Description = model.Description;


            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            _db.services.Remove(dbEntity);
            return _db.SaveChanges();

        }
    }
}
