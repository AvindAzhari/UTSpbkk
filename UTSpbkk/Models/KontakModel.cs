using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSpbkk.Models
{
    public class KontakModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdKontak { get; set; }
        public string Nama { get; set; }
        public string Perusahaan { get; set; }
        public string Email { get; set; }
        public string Telpkantor { get; set; }
        public string Telpprib { get; set; }

    }
}
