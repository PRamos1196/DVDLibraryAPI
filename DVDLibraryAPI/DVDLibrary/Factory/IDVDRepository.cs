using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace DVDLibrary.Factory
{
    public interface IDVDRepository
    {
        List<DVD> GetAll();
        DVD GetById(int id);
        void Create(DVD dvd);
        void Update(DVD dvd);
        void Delete(int id);
        List<DVD> GetByTitle(string title);
        List<DVD> GetByReleaseYear(int year);
        List<DVD> GetByRating(string rating);
        List<DVD> GetByDirector(string director);

    }
}