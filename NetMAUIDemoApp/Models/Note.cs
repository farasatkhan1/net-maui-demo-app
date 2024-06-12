using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetMAUIDemoApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
