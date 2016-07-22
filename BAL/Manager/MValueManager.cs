using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concret;
using DAL.Interface;
using Domain;
using Domain.CustomModels;


namespace BAL.Manager
{
  public  class MValueManager
    {

      IMasterValueDAL dal;
      public MValueManager()
      {
          dal = new MasterValueDAL();
      }

      public IList<Domain.MasterValue> GetMasterValuesByMasterId(int masterTypeId)
      {
          try
          {
              return dal.GetMasterValuesByMasterId(masterTypeId);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public IList<Domain.MasterValue> GetAllMasterValues()
      {
          try
          {
              return dal.GetAllMasterValues();
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
          
    }
}
