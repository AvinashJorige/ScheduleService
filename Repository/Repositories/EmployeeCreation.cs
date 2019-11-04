using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utility;

namespace Repository.Repositories
{
    public class EmployeeCreation : Repository<Request>
    {
        private DbContext _context;
        public EmployeeCreation(DbContext context)
            : base(context)
        {
            _context = context;
        }

        public DataTable UpdateCCUpd_T(string CCXML)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_CCUpd_T]";
                command.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));  
                command.Parameters["@CCTable"] = CCXML.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }
    }
}
