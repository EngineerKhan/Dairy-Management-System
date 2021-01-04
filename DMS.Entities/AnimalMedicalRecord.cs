using System;

namespace DMS.Entities
{
    public class AnimalMedicalRecord
    {
        /// <summary>
        /// For DB ID of the Table. Added 12-Mar
        /// </summary>
        int id;

        DateTime entryDate;
        Cattle illAnimal;
        string diagnosis, treatment, prognosis;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime EntryDate
        {
            get
            {
                return entryDate;
            }

            set
            {
                entryDate = value;
            }
        }

        public Cattle IllAnimal
        {
            get
            {
                return illAnimal;
            }

            set
            {
                illAnimal = value;
            }
        }

        public string Diagnosis
        {
            get
            {
                return diagnosis;
            }

            set
            {
                diagnosis = value;
            }
        }

        public string Treatment
        {
            get
            {
                return treatment;
            }

            set
            {
                treatment = value;
            }
        }

        public string Prognosis
        {
            get
            {
                return prognosis;
            }

            set
            {
                prognosis = value;
            }
        }
    }
}
