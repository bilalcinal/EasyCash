
using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete.Context;

namespace EasyCash.DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    public void Delete(T t)
    {
       using var _context = new EasyCashDbContext();
       _context.Set<T>().Remove(t);
       _context.SaveChanges();

    }

    public T GetById(int id)
    {
        using var _context = new EasyCashDbContext();
        return _context.Set<T>().Find(id);
    }

    public List<T> GetList()
    {
        using var _context = new EasyCashDbContext();
        return _context.Set<T>().ToList();
    }

    public void Insert(T t)
    {
        using var _context = new EasyCashDbContext();
        _context.Set<T>().Add(t);
        _context.SaveChanges();
        
    }

    public void Update(T t)
    {
        using var _context = new EasyCashDbContext();
        _context.Set<T>().Update(t);
        _context.SaveChanges();
    }
}
