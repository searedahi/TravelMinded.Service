using System;
using System.Collections.Generic;
using System.Text;

namespace TravelMinded.Service.DAL.DbModel
{
    public class BaseDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
