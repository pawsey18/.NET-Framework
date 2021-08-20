using Model;
using Repository;
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
            _canoe = canoe;
            CanoeRepo repository = new CanoeRepo();
            Validate();
            if (Errors.Count == 0)
            {
                return repository.Insert(canoe);
            }
            return false;
        }
 
        private bool BuilderHasMadeFourCanoeOfSameTypeDuringLastSevenDays()
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
