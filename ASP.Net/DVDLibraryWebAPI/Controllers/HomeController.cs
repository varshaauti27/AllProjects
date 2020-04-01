using DVDLibraryWebAPI.Data;
using DVDLibraryWebAPI.Models;
using DVDLibraryWebAPI.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        readonly IDvdRepository repository = DVDFactory.Create();

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        { 
            return Ok(repository.GetAllDvds());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvd(int id)
        {
            //DVD dvd = repository.GetDvd(id);
            //if (dvd == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(dvd);
            //}
            return Ok(repository.GetDvd(id));
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string title)
        {
            return Ok(repository.GetDvdByTitle(title.ToLower()));
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByYear(int releaseYear)
        {
            return Ok(repository.GetDvdByYear(releaseYear));
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirectorName(string directorName)
        {
            return Ok(repository.GetDvdByDirectorName(directorName.ToLower()));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            return Ok(repository.GetDvdByRating(rating));
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddUpdateDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DVD dvd = new DVD()
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
                Director = request.Director,
                Rating = request.Rating,
                Notes = request.Notes
            };

            repository.Add(dvd);
            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(AddUpdateDvdRequest request, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DVD dvd = repository.GetDvd(id);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Director = request.Director;
            dvd.Rating = request.Rating;
            dvd.Notes = request.Notes;

            repository.Edit(dvd);
            return Ok();
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            DVD dvd = repository.GetDvd(id);

            if (dvd == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            return Ok();
        }
    }
}
