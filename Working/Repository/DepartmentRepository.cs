using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Context;
using Working.Models.APIModel;
using Working.Models.DBModels;

namespace Working.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Department> GetAllDepartment()
        {
            return _appDbContext.Departments.ToList();
     
        }

        public List<FullDepartment> GetAllPDepartment()
        {
            var query = from d in _appDbContext.Departments
                        join pd in _appDbContext.Departments
                        on d.ParentID equals pd.ID
                        select new FullDepartment
                        {
                            ID=d.ID,
                            DepartName=d.DepartName,
                            PDepartmentName=pd.DepartName

                        };

            List<FullDepartment> list = query.ToList();
            return list;
        }
    }
}
