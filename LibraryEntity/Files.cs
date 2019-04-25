using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntity
{
    public class Files
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public TypeEnum Type { get; set; }
        public DateTime DateTime { get; set; }
        
    }
}
