using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourse210710.Models
{   
	public  class PersonRepository : EFRepository<Person>, IPersonRepository
	{
		public IQueryable GetPersonSelect()
        {
			IQueryable select = All().Select(p => new
			{
				p.ID,
				Name = p.FirstName + " " + p.LastName
			});
			return select;
		}
	}

	public  interface IPersonRepository : IRepository<Person>
	{

	}
}