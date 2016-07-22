using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concret
{
   public class MasterValueDAL:Interface.IMasterValueDAL
    {
       SABenefitsEntities1 dbContext;
       public MasterValueDAL() {
           dbContext = new SABenefitsEntities1();
       }

        public IList<Domain.MasterValue> GetMasterValuesByMasterId(int masterTypeId)
        {
            try
            {
                var items = dbContext.sp_selectMasterValues(masterTypeId);
                IList<Domain.MasterValue> mValues=new List<Domain.MasterValue>();
                if (items.Count() > 0)
                {
                    foreach (var item in items)
                    {
                        Domain.MasterValue mvalue = new Domain.MasterValue();
                        mvalue.MasterTypeId = item.MasterTypeId;
                        mvalue.MasterValueId = item.MasterValueId;
                        mvalue.Value = item.Value;
                        mValues.Add(mvalue);
                    }

                }
                return mValues;
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
                var items = dbContext.sp_selectMasterValues(0).ToList();
                IList<Domain.MasterValue> mValues = new List<Domain.MasterValue>();
                if (items.Count() > 0)
                {
                    foreach (var item in items)
                    {
                        Domain.MasterValue mvalue = new Domain.MasterValue();
                        mvalue.MasterTypeId = item.MasterTypeId;
                        mvalue.MasterValueId = item.MasterValueId;
                        mvalue.Value = item.Value;
                        mValues.Add(mvalue);
                    }

                }
                return mValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
