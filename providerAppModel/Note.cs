using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvester.Model
{
    public class Note
    {
        public DateTime DateCreated { get; set; }
        public string UserID { get; set; }
        public string NoteType { get; set; }
        public string Content { get; set; }
    }
}
