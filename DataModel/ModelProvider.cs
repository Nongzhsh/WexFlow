using System;
using System.Linq;

namespace DataModel
{
    public class ModelProvider
    {
        static string connectionString = @"Persist Security Info=False;User ID=sa;Password=1;Initial Catalog=WorkFlow;Server=ARASH-PC\ARASHSQLSERVER";
        public string GetEmployStatus(int id)
        {
            using (var context = new WorkFlowEntities(connectionString))
            {
                return context.Emploes
                    .Where(x => x.Id == id)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault().Status;
            }
        }

        public class ResultModel
        {
            public bool Success { get; set; }
            public int Id { get; set; }
        }

        public ResultModel AddEmployee(Emplo model)
        {
            try
            {
                //using (var context = new WorkFlowEntities(@"metadata=res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ARASH-PC\ARASHSQLSERVER;initial catalog=WorkFlow;persist security info=True;user id=sa;password=1;MultipleActiveResultSets=True;App=EntityFramework&quot;"))
                using (var context = new WorkFlowEntities(connectionString))
                {
                    context.Emploes.Add(model);
                    context.SaveChanges();
                    return new ResultModel
                    {
                        Id = model.Id,
                        Success = true
                    };
                }
            }
            catch
            {
                return new ResultModel
                {
                    Success = false
                };
            }
        }
    }
}
