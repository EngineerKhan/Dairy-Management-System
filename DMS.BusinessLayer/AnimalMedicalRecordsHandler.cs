using DMS.DataLayer;
using System.Collections.Generic;
using DMS.Entities;

namespace DMS.LogicLayer
{
    public class AnimalMedicalRecordsHandler
    {
        /// <summary>
        /// Added 18 March
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<AnimalMedicalRecord> GetAnimalMedicalRecords(string col, string param)
        {
            return new AnimalMedicalRecordsDAL().GetAnimalMedicalRecords(col, param);
        }

        public List<AnimalMedicalRecord> GetAnimalMedicalRecords()
        {
            return new AnimalMedicalRecordsDAL().GetAnimalMedicalRecords();
        }

        public int Insert(AnimalMedicalRecord medRecord)
        {
            return new AnimalMedicalRecordsDAL().Insert(medRecord);
        }

        public int Update(AnimalMedicalRecord r)
        {
            return new AnimalMedicalRecordsDAL().Update(r);
        }
    }
}
