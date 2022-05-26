using System.Collections.Generic;

namespace jogoDigitalIo.src.Interface
{
    public interface RepositoryImp<T>
    {
     List<T> ListOfFilm();
     T       ReturnById(int id);
     void    Insert(T entity);
     void    Delete(int id);
     void    Update(int id, T entity);
     int     NextId();
    }
}