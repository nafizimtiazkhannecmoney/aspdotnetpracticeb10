using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class BlogPost : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
       
        

        public BlogPost() 
        {

        }
    }
}
