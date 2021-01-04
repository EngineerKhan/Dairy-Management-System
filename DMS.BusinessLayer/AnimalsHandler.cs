using DMS.DataLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DMS.BusinessLayer
{
    public class AnimalsHandler
    {
        public List<Cattle> GetCattles()
        {

            return new AnimalsDAL().GetCattles();
        }

        public List<Cattle> GetCattlesMale()
        {

            return new AnimalsDAL().GetCattlesMale();
        }

        public List<Cattle> GetCattlesFemale()
        {

            return new AnimalsDAL().GetCattlesFemale();
        }

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Calf> GetCalfs(string col, string param)
        {

            return new AnimalsDAL().GetCalfs(col,param);
        }

        public List<Calf> GetCalfs()
        {

            return new AnimalsDAL().GetCalfs();
        }

        public List<Cattle> GetCattles_GivingMilk()
        {

            return new AnimalsDAL().GetCattles_GivingMilk();
        }
        public List<Cattle> GetCattles(int fromRank, int toRank)
        {
            return new AnimalsDAL().GetCattles(fromRank, toRank);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        public List<Cattle> GetCattles(string column, string queryParameter)
        {
            return new AnimalsDAL().GetCattles(column, queryParameter);
        }

        public Animal GetAnimal(string id)
        {
            return new AnimalsDAL().GetAnimal(id);
        }

        public int AddAnimal(Animal Animal)
        {
            //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
            int cmd_success;
            cmd_success = new AnimalsDAL().Insert(Animal);
            return cmd_success;
        }

        /// <summary>
        /// Made 14 march
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int Update(Cattle c)
        {
            int cmd_success;
            cmd_success = new AnimalsDAL().Update(c);
            return cmd_success;
        }

        //Added 2-Jan, 2015
        public List<MasterTables> GetAnimalTypes()
        {
            return new AnimalsDAL().GetAnimalTypes();
        }

        public IEnumerable GetGenders()
        {
            return new AnimalsDAL().GetGenders();
        }

        public List<MasterTables> GetAnimalBreeds()
        {
            return new AnimalsDAL().GetAnimalBreeds();
        }

        public List<MasterTables> GetAnimalSources()
        {
            return new AnimalsDAL().GetCattlesources();
        }

        public List<AnimalStatusNew> GetAnimalStatuses()
        {
            return new AnimalsDAL().GetAnimalStatuses();
        }

        public List<AnimalStatus> GetAnimalStatuses(string p)
        {
            return new AnimalsDAL().GetCattlestatuses(p);
        }

        public List<AnimalWithStatus> GetAnimals_All_WithStatuses()
        {
            return new AnimalsDAL().GetAnimals_All_WithStatuses();
        }

        public void DeleteAnimal(Animal Animal)
        {
            new AnimalsDAL().Delete(Animal);
        }

        public int Add(Cattle currCattle)
        {
            int cmd_success;
            cmd_success = new AnimalsDAL().Insert(currCattle);
            return cmd_success;
        }

        public int Add(Calf currCalf)
        {
            int cmd_success;
            cmd_success = new AnimalsDAL().Insert(currCalf);
            return cmd_success;
        }

        public void Add(Calf currCalf, int parentID, char isMother)
        {
            new AnimalsDAL().Insert(currCalf, parentID, isMother);
        }

        public void Add(Calf currCalf, int fatherID, int motherID)
        {
            new AnimalsDAL().Insert(currCalf, fatherID, motherID);
        }

        public void UpdateStatus(Cattle selectedAnimal, int updatedStatus)
        {
            new AnimalsDAL().UpdateStatus(selectedAnimal, updatedStatus);
        }

        public int GetAnimalStatusID(AnimalStatusNew ast)
        {
            return new AnimalsDAL().GetAnimalStatusID(ast);
        }
    }
}
