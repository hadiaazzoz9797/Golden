using Golden.Entities;
using Golden.Model;
using Golden.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Golden.Repository
{
    public class SuperVisorRepository : ISuperVisorRepository
    {
        private readonly ApplicationDbContext _db;
        public SuperVisorRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Supervisor> GetAll()
        {

            return _db.supervisors.ToList();

        }
        public async Task<List<Supervisor>> GetAllAsync()
        {

            return await _db.supervisors.ToListAsync();

        }

        public Supervisor Get(int id)
        {
            return _db.supervisors.Find(id);

        }
        public Supervisor GetFirstOrDefault(int id)
        {
            return _db.supervisors.FirstOrDefault(x => x.SuperVisorId == id);

        }
        //public int Create(Category entity)
        //{
        //    _db.Categories.Add(entity);
        //    return _db.SaveChanges();

        //}
        public async Task<int> CreateAsync(Supervisor entity)
        {
            _db.supervisors.Add(entity);
            return await _db.SaveChangesAsync();

        }
        public int Update(int id, Supervisor model)
        {

            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            dbEntity.Name = model.Name;

            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            _db.supervisors.Remove(dbEntity);
            return _db.SaveChanges();

        }

    }
}
