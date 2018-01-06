using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //MapTaxLot Table
    public class MapTaxLots
    {
        [Required]
        public string MapTaxLot { get; set; }
        [Required]
        public string DivisionID { get; set; }
        public int TrackingID { get; set; }
        public string Structure { get; set; }
        public string LongName { get; set; }
        public int Ride { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal Acers { get; set; }
        public decimal Rate { get; set; }
        public decimal Allotment { get; set; }
        public string Name { get; set; }
        public List<MapTaxLots> maptaxlots { get; set; }
    }
    
    public enum SelectDevision
    {
        KID,
        KBID,
        WarrenAct,
        GroupE
    }

    public enum SelectStatusID1
    {
        KID,
        KBID,
        WarrenAct,
        GroupE,
        Suspended,
        NotUsed,
        EnterpriseSuburban,
        Marlin,
        PineGrove,
        ShastaView,
        VanBrimer,
        EnterpriseFarm
    }
    
    public enum SelectStatusID2
    {
        Suspended,
        NotUsed,
        EnterpriseSuburban,
        Marlin,
        PineGrove,
        ShastaView,
        VanBrimer,
        EnterpriseFarm
    }
}