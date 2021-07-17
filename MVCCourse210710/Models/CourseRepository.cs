using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourse210710.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{

	}

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}