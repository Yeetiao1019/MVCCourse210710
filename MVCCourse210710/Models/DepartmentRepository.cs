using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourse210710.Models
{   
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
        public override IQueryable<Department> All()
        {
            return base.All();
        }
    }

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}