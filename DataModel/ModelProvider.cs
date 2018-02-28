using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class ModelProvider
    {
        public  bool AddEmployee(Emplo model)
        {
            try
            {
                using (var context = new WorkFlowEntities())
                {
                    context.Emploes.Add(model);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
