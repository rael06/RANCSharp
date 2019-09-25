using Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
	class RancsharpContext : DbContext
	{
		public DbSet<Domain> Domains { get; set; }
	}
}
