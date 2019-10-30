using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;
using Repository.Repositories;

namespace Core
{
    public  class SampleService
    {
        private IConnectionFactory _iconn;

        public object getData()
        {
            _iconn = ConnectionHelper.GetConnection();

            var context = new DbContext(_iconn);

            var userRep = new StudentsRepository(context);

            return userRep.GetStudentss();
        }
    }
}
