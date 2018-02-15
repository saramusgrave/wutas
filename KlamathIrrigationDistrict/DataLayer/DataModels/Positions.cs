using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    public class Positions
    {
        public int PositionID { get; set; }
        public string Position { get; set; }
        public List<Positions> positions { get; set; }
    }
}