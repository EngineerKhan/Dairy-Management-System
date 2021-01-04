using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Entities;
using DMS.DataLayer;

namespace DMS.BusinessLayer
{
    public class MilkingHandler
    {
        MilkingDAL milkingDAL;

        public void AddMilkingEntry(MilkingEntry milkingEntry)
        {
            new MilkingDAL().Insert(milkingEntry);
        }

        public List<MilkingEntry> GetMilkingEntries()
        {
            return new MilkingDAL().GetMilkingEntries();
        }

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MilkingEntry> GetMilkingEntries(string col, string param)
        {
            return new MilkingDAL().GetMilkingEntries(col,param);
        }
    }
}
