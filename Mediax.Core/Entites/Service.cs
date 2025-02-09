using Mediax.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.Core.Entites
{
	public class Service:BaseEntity
	{
		public string Name { get; set; }  
		public string ShortDescription { get; set; }  
		public string FullDescription { get; set; }  
		
		public Guid DepartmentId { get; set; } 
		public Department Department { get; set; }
		public string ImageUrl { get; set; } 
		public string IconUrl { get; set; } 
		public List<string> Treatments { get; set; }  
		public List<string> Benefits { get; set; }  
		public List<string> FaqQuestions { get; set; }
	}
}
