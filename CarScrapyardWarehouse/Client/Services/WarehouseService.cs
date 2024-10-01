using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarScrapyardWarehouse.Client.Interfaces;
using CarScrapyardWarehouse.Shared.Models;

namespace CarScrapyardWarehouse.Client.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IHttpService _httpService;
        private const string BaseUrl = "api/Warehouse/";

        public WarehouseService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Area>> GetAreas()
        {
            return await _httpService.Get<List<Area>>(BaseUrl + "areas");
        }
        public async Task<Area> GetAreaById(int id)
        {
            return await _httpService.Get<Area>(BaseUrl + $"area/{id}");
        }

        public async Task<List<Position>> GetPositions()
        {
            return await _httpService.Get<List<Position>>(BaseUrl + "locations");
        }
        public async Task<Position> GetPositionsById(int id)
        {
            return await _httpService.Get<Position>(BaseUrl + $"location/{id}");
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await _httpService.Get<List<Warehouse>>(BaseUrl + "warehouses11");
        }
        public async Task<Warehouse> GetWarehouseById(int id)
        {
            return await _httpService.Get<Warehouse>(BaseUrl + $"warehouse11/{id}");
        }

        public async Task<string> AddArea(Area area)
        {
            var response = await _httpService.Post(BaseUrl + "addArea", area);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddPosition(Position location)
        {
            var response = await _httpService.Post(BaseUrl + "addLocation", location);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> AddPositions(List<Position> locations)
        {
            var response = await _httpService.Post(BaseUrl + "addLocations", locations);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddWarehouse(Warehouse warehouse)
        {
            var response = await _httpService.Post(BaseUrl + "addWarehouse", warehouse);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateWarehouse(Warehouse warehouse)
        {
            var response = await _httpService.Post(BaseUrl + "updateWarehouse", warehouse);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdatePosition(Position position)
        {
            var response = await _httpService.Post(BaseUrl + "updatePosition", position);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateArea(Area area)
        {
            var response = await _httpService.Post(BaseUrl + "updateArea", area);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RemoveArea(int areaId)
        {
            var response = await _httpService.Delete(BaseUrl + $"removeArea/{areaId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RemovePosition(int locationId)
        {
            var response = await _httpService.Delete(BaseUrl + $"removeLocation/{locationId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RemoveWarehouse(int warehouseId)
        {
            var response = await _httpService.Delete(BaseUrl + $"removeWarehouse/{warehouseId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<Position>> GetLocationsInWarehouse(int warehouseId)
        {
            return await _httpService.Get<List<Position>>(BaseUrl + $"locationsInWarehouse/{warehouseId}");
        }
    }
}
