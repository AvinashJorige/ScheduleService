using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Repositories
{
    public class StudentsRepository : Repository<Students>
    {
        private DbContext _context;
        public StudentsRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }


        public IList<Students> GetStudentss()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[uspGetStudentss]";

                return this.ToList(command).ToList();
            }
        }
    }
}