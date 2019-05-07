using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAroundMobile.Models
{
    public class LocalLogModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public bool IsFirstLogin { get; set; }

        public LocalLogModel()
        {

        }

        public LocalLogModel(bool IsFirst)
        {
            IsFirstLogin = IsFirst;
        }
    }
}
