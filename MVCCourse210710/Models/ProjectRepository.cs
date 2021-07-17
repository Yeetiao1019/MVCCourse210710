using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourse210710.Models
{   
	public  class ProjectRepository : EFRepository<Project>, IProjectRepository
	{

	}

	public  interface IProjectRepository : IRepository<Project>
	{

	}
}