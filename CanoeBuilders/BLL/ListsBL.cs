using Model.Lookups;
using Repository;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ListsBL
    {
        public List<BuilderLookup> GetTheBuilders()
        {
            ListsRepo repo = new ListsRepo();
            return repo.RetrieveBuilderList();
        }
    }
}
