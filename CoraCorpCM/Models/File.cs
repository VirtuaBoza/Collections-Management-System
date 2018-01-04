using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class File
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
