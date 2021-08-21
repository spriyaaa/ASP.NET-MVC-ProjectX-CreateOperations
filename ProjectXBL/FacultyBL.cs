using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class FacultyBL
    {
        FacultyDAL objFaculty;

        public FacultyBL()
        {
            objFaculty = new FacultyDAL();

        }
        public List<FacultyDTO> GetAllFaculties()
        {
            try
            {
                var lstFaculty = objFaculty.GetAllFaculties();
                return lstFaculty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AddNewFaculty(FacultyDTO facDTOObj)
        {
            try
            {
                int returnvalue = objFaculty.AddNewFaculty(facDTOObj);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
/*        public int UpdateFaculty(FacultyDTO newFacDetails)
        {
            try
            {
                int returnvalue = objFaculty.UpdateFaculty(newFacDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteFaculty(FacultyDTO FacID)
        {
            try
            {
                int returnvalue = objFaculty.DeleteFaculty(FacID);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
    }
}