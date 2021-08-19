using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CanoeBL
    {
        private Canoe _canoe;
        public List<ValidationError> Errors = new List<ValidationError>();

        public bool AddCanoe(Canoe canoe)
        {
          
            return false;
        }
        // actually 3
        private bool BuilderHasFourCanoeTypes()
        {
            return true;
        }

        private bool NoMoreThan2BadReviews()
        {
           
            return true;
        }

        private bool CedarStripValidation()
        {
          
            return true;
        }

        private void Validate()
        {
           
        }

        private bool IsValidEntity()
        {
           
            return false;
        }
    }
}
