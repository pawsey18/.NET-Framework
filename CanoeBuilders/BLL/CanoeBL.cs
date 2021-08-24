using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            CanoeRepo repo = new CanoeRepo();
            if (repo.MaxFourCanoesOfSameTypeDuringWeek(_canoe.BuilderID, _canoe.CanoeType))
            {
                Errors.Add(new ValidationError("Only four canoes  of the same type per builder"));
                return false;
            }
            return true;
        }

        private bool NoMoreThan2BadReviews()
        {

            CanoeRepo repo = new CanoeRepo();
            if (repo.TwoNegativeReviews(_canoe.BuilderID))
            {
                Errors.Add(new ValidationError("Can't add canoe with 2 negative reviews"));
                return false;
            }
            return true;
        }

        private bool CedarStripValidation()
        {

            CanoeRepo repo = new CanoeRepo();
            if (repo.CederStripBuilderOnly(_canoe.BuilderID) && _canoe.CanoeType == 3)
            {
                Errors.Add(new ValidationError("Only ceder strip builders can add this type of canoe"));
                return false;
            }
            return true;
        }

        private void Validate()
        {
            BuilderHasMadeFourCanoeOfSameTypeDuringLastSevenDays();
            NoMoreThan2BadReviews();
            CedarStripValidation();
            IsValidEntity();

        }

        private bool IsValidEntity()
        {

            ValidationContext context = new ValidationContext(_canoe);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(_canoe, context, results, true);
            foreach (ValidationResult r in results)
            {
                Errors.Add(new ValidationError(r.ErrorMessage));
            }
            return isValid;
        }
    }
}
