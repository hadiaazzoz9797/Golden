using Golden.Entities;
using Golden.Model;
using Golden.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Golden.Repository
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly ApplicationDbContext _db;
        public ResponsibleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Responsible> GetAll()
        {

            return _db.Responsible.ToList();

        }
        public async Task<List<Responsible>> GetAllAsync()
        {

            return await _db.Responsible.ToListAsync();

        }

        public Responsible Get(int id)
        {
            return _db.Responsible.Find(id);

        }
        public List<Responsible> GetType(int type)
        {
            return _db.Responsible.Where(x=>x.Type== type).ToList();

        }
        public Responsible GetFirstOrDefault(int id)
        {
            return _db.Responsible.FirstOrDefault(x => x.ResponsibleId == id);

        }
        //public int Create(Category entity)
        //{
        //    _db.Categories.Add(entity);
        //    return _db.SaveChanges();

        //}
        public async Task<int> CreateAsync(Responsible entity)
        {
            _db.Responsible.Add(entity);
            return await _db.SaveChangesAsync();

        }
        public int Update(int id, Responsible model)
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
            _db.Responsible.Remove(dbEntity);
            return _db.SaveChanges();

        }

    }
}
