using BusinessObjects.Models;
using DataAccessLayer.DataAccess;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class GenderService
    {

        GenderDataAccess gda = new GenderDataAccess();
        public List<Gender> GetGenders()
        {
           return gda.GetGenders();
        }

        public int CreateGender(Gender gender)
        {
           int rowsEffected = gda.CreateGender(gender);
           return rowsEffected;
        }

        public bool IsDuplicate(Gender gender)
        {
            bool isDuplicate = gda.IsDuplicate(gender);
            return isDuplicate;
        }

    }
}
