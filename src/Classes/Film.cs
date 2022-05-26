using System;
using jogoDigitalIo.src.Enum;
using jogoDigitalIo.src.Classes;

namespace jogoDigitalIo.src.Classes
{
    public class Film : BaseEntity
    {
        private Gender GenderFilm  { get; set; }
        private string Title       { get; set; }
        private string Description { get; set; }
        private int    ReleaseYear { get; set; }
        private bool   Excluded    { get; set; }

        public Film(int id, Gender genderFilm, string title, string description, int releaseYear)
        {
            this.Id          = id;
            this.GenderFilm  = genderFilm;
            this.Title       = title;
            this.Description = description;
            this.ReleaseYear = releaseYear;
            this.Excluded    = false;
        }

        public override string ToString()
        {
            string textOfFilm = "";

            textOfFilm += "Gênero: "            + this.GenderFilm  + Environment.NewLine;
            textOfFilm += "Título: "            + this.Title       + Environment.NewLine;
            textOfFilm += "Descrição: "         + this.Description + Environment.NewLine;
            textOfFilm += "Ano de Lançamento: " + this.ReleaseYear + Environment.NewLine;
            textOfFilm += "Excluido: "          + this.Excluded    + Environment.NewLine;

            return textOfFilm;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnExcluded()
        {
            return this.Excluded;
        }

        public void deleteFilm()
        {
            this.Excluded = true;
        }
    }
}
