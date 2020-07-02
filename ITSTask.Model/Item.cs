
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITSTask.Model
{
    [Table("Item")]
    public class Item
    {
        public int id { get; set; }

        [MaxLength(50)]
        public string tittle { get; set; }

        [MaxLength(255)]
        public string description { get; set; }


    }
}
