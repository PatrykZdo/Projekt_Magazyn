using System.Collections.Generic;
using System.Threading.Tasks;
using CarScrapyardWarehouse.Shared.Models;

namespace CarScrapyardWarehouse.Client.Interfaces
{
    public interface IWarehouseService
    {
        Task<List<Area>> GetAreas();
        Task<List<Position>> GetPositions();
        Task<List<Warehouse>> GetWarehouses();
        Task<Area> GetAreaById(int id);
        Task<Position> GetPositionsById(int id);
        Task<Warehouse> GetWarehouseById(int id);

        Task<string> AddArea(Area area);
        Task<string> AddPosition(Position location);
        Task<string> AddPositions(List<Position> locations);
        Task<string> AddWarehouse(Warehouse warehouse);

        Task<string> RemoveArea(int areaId);
        Task<string> RemovePosition(int locationId);
        Task<string> RemoveWarehouse(int warehouseId);


        Task<string> UpdateWarehouse(Warehouse warehouse);
        Task<string> UpdatePosition(Position position);
        Task<string> UpdateArea(Area area);


		Task<List<Position>> GetLocationsInWarehouse(int warehouseId);
    }
}
