using Server.Models;
using Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories
{
	class DomainRepository
	{
		private static RancsharpContext _context = new RancsharpContext();

		public static List<Domain> GetAll => _context.Domains.ToList();

		public static void add(Domain d)
		{
			_context.Domains.Add(d);
			_context.SaveChanges();
		}
	}
}
