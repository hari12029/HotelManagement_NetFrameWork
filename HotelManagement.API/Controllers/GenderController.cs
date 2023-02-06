using BusinessLayer.Services;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace HotelManagement.API.Controllers
{
    public class GenderController : ApiController
    {
        GenderService gs = new GenderService();

        [HttpGet]
        public IHttpActionResult GetGenders()
        {
           List<Gender> genList = gs.GetGenders();
           return Ok(genList);
        }

        [HttpPost]
        public IHttpActionResult CreateGender(Gender gender)
        {
            if (!IsDuplicate(gender))
            {
                int rowsEffected = gs.CreateGender(gender);

                if (rowsEffected == 1)
                {
                    return Created<Gender>("", gender);
                }
            }

            return Created<Gender>("", null);
        }

        private bool IsDuplicate(Gender gender)
        {
            bool isDuplicate = gs.IsDuplicate(gender);
            return isDuplicate;
        }


    }
}
