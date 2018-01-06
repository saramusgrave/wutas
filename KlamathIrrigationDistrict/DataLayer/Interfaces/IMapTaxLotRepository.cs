using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IMapTaxLotRepository
    {
        MapTaxLots Get(string MapTaxLot);
        List<MapTaxLots> ViewTaxLot();
        void Save(MapTaxLots maptaxlots);
    }
}