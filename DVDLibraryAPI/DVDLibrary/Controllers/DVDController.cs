using DVDLibrary.Models;
using DVDLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        private static IDVDRepository repo = DVDManagerFactory.GetRepository();

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD _dvd)
        {
            repo.Create(_dvd);
            return Created($"dvd/{_dvd.DVDId}", _dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            DVD found = repo.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            List<DVD> found = repo.GetByDirector(director);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            List<DVD> found = repo.GetByRating(rating);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int releaseYear)
        {
            List<DVD> found = repo.GetByReleaseYear(releaseYear);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<DVD> found = repo.GetByTitle(title);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(DVD _dvd)
        {
            repo.Update(_dvd);
        }
    }
}
