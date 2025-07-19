using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Comment : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
