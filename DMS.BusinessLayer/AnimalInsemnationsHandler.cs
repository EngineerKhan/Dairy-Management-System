using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Entities;
using DMS.DataLayer;

namespace DMS.BusinessLayer
{
    public class AnimalInsemnationsHandler
    {
        public void Add(AnimalInsemnation currAnimalInsemnation)
        {
            new AnimalInseminationsDAL().Add(currAnimalInsemnation);
        }

        public List<AnimalInsemnation> GetAnimalInsemnations(string col, string param)
        {
            return new AnimalInseminationsDAL().GetAnimalInsemnations(col, param);
        }

        public List<AnimalInsemnation> GetAnimalInsemnations()
        {
            return new AnimalInseminationsDAL().GetAnimalInsemnations();
        }
    }
}
