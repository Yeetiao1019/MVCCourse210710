using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourse210710.Models
{   
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
		public Department FindOne(int id)
        {
            return this.All().FirstOrDefault(d => d.DepartmentID == id);
        }
    }

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}