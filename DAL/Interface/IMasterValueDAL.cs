using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interface
{
    public interface IMasterValueDAL
    {
        /// created by:mayank
        /// created date:3/7/2016
        /// <summary>
        /// This method is used to get master values by master type id
        /// </summary>
        /// <param name="MasterTypeId"></param>
        /// <returns></returns>
        IList<Domain.MasterValue> GetMasterValuesByMasterId(int masterTypeId);

        /// created by:mayank
        /// created date:3/7/2016
        /// <summary>
        /// This method is used to get all master values
        /// </summary>
        /// <returns></returns>
        IList<Domain.MasterValue> GetAllMasterValues();
    }
}
