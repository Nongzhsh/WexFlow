using System;

namespace DataModel
{
    public class ModelProvider
    {
        public  bool AddEmployee(Emplo model)
        {
            try
            {
                //using (var context = new WorkFlowEntities(@"metadata=res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ARASH-PC\ARASHSQLSERVER;initial catalog=WorkFlow;persist security info=True;user id=sa;password=1;MultipleActiveResultSets=True;App=EntityFramework&quot;"))
                using (var context = new WorkFlowEntities(@"Persist Security Info=False;User ID=sa;Password=1;Initial Catalog=WorkFlow;Server=ARASH-PC\ARASHSQLSERVER"))
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
