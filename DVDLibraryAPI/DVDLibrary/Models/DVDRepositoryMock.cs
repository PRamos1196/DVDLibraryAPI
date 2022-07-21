using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Factory;

namespace DVDLibrary.Models
{
    public class DVDRepositoryMock : IDVDRepository
    {
        private static List<DVD> _dvd = new List<DVD>
        {
              new DVD {  DVDId=1, Title="Despicable Me", ReleaseYear=2010, Rating="PG", Director="Chris Renaud and Pierre Coffin", Notes= "Theyre Funny Minions"},
              new DVD {  DVDId=2, Title="Inception", ReleaseYear=2010, Rating="PG-13", Director="Chris Renaud and Pierre Coffin", Notes= "" }
        };
        public void Create(DVD dvd)
        {
            if (_dvd.Any())
            {
                dvd.DVDId = _dvd.Max(c => c.DVDId) + 1;
            }
            _dvd.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvd.RemoveAll(c => c.DVDId == id);
        }

        public List<DVD> GetAll()
        {
            return _dvd;
        }

        public List<DVD> GetByDirector(string director)
        {
            var trav = _dvd.Where(d => d.Director == director).ToList();
            return trav;
        }

        public DVD GetById(int id)
        {
            return _dvd.FirstOrDefault(c => c.DVDId == id);
        }

        public List<DVD> GetByRating(string rating)
        {
            var trav = _dvd.Where(d => d.Rating == rating).ToList();
            return trav;
        }

        public List<DVD> GetByReleaseYear(int year)
        {
            var trav = _dvd.Where(d => d.ReleaseYear == year).ToList();
            return trav;
        }

        public List<DVD> GetByTitle(string title)
        {
            var trav = _dvd.Where(d => d.Title == title).ToList();
            return trav;
        }

        public void Update(DVD dvd)
        {
            var fod = _dvd.FirstOrDefault(d => d.DVDId == dvd.DVDId);
            if (fod != null)
            {
                fod.Title = dvd.Title;
                fod.ReleaseYear = dvd.ReleaseYear;
                fod.Director = dvd.Director;
                fod.Rating = dvd.Rating;
                fod.Notes = dvd.Notes;
            }
        }
        //    public void Update(DVD updatedDvd)
        //    {
        //        _dvd.RemoveAll(c => c.DVDId == updatedDvd.DVDId);
        //        _dvd.Add(updatedDvd);
        //    }

        //    public void Delete(int dvdId)
        //    {
        //        _dvd.RemoveAll(c => c.DVDId == dvdId);
        //    }
        //}
    }
}