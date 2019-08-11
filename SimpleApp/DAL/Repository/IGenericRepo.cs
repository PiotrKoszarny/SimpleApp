using System.Threading.Tasks;

namespace SimpleApp.DAL.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> Add(T t);
        Task<T> GetItem(int id);
        Task<T> Update(T t);
    }
}