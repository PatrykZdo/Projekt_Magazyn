using CarScrapyardWarehouse.Server.Models;
using CarScrapyardWarehouse.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarScrapyardWarehouse.Server.Services
{
    public interface IWarehouseService
    {
        Task<List<Area>> GetAreas();
        Task<Area> GetAreaById(int id);
        Task<List<Position>> GetLocations();
        Task<Position> GetPositionsById(int id);
        Task<List<Warehouse>> GetWarehouses();
        Task<Warehouse> GetWarehouseById(int id);

        Task AddArea(Area area);
        Task AddLocation(Position location);
        Task AddLocations(List<Position> locations);
        Task AddWarehouse(Warehouse warehouse);

        Task RemoveArea(int areaId);
        Task RemoveLocation(int locationId);
        Task RemoveWarehouse(int warehouseId);


        Task<Position> UpdateLocation(Position location);
        Task<Warehouse> UpdateWarehouse(Warehouse warehouse);
        Task<Area> UpdateArea(Area area);


		Task<List<Position>> GetLocationsInWarehouse(int warehouseId);
    }
}
