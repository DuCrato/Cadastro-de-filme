using System;
using System.Collections.Generic;
using jogoDigitalIo.src.Interface;

namespace jogoDigitalIo.src.Classes
{
    public class FilmRepository : RepositoryImp<Film>
    {
        private List<Film> listFilm = new List<Film>();
        
        public List<Film> ListOfFilm()
        {
            return listFilm;
        }

        public Film ReturnById(int id)
        {
            return listFilm[id];
        }

        public void Insert(Film film)
        {
            listFilm.Add(film);
        }

        public void Delete(int id)
        {
            listFilm[id].deleteFilm();
        }

        public void Update(int id, Film film)
        {
            listFilm[id] = film;
        }

        public int NextId()
        {
            return listFilm.Count;
        }
    }
}