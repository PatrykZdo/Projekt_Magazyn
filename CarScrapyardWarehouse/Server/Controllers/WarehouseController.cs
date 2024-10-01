using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarScrapyardWarehouse.Server.Models;
using CarScrapyardWarehouse.Shared.Models;
using CarScrapyardWarehouse.Server.Services;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet("areas")]
    public async Task<IActionResult> GetAreas()
    {
        try
        {
            var areas = await _warehouseService.GetAreas();
            return Ok(areas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("area/{id}")]
    public async Task<IActionResult> GetAreaById(int id)
    {
        try
        {
            var areas = await _warehouseService.GetAreaById(id);
            return Ok(areas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("locations")]
    public async Task<IActionResult> GetLocations()
    {
        try
        {
            var locations = await _warehouseService.GetLocations();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("location/{id}")]
    public async Task<IActionResult> GetPositionsById(int id)
    {
        try
        {
            var locations = await _warehouseService.GetPositionsById(id);
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("warehouses11")]
    public async Task<IActionResult> GetWarehouses()
    {
        try
        {
            var warehouses = await _warehouseService.GetWarehouses();
            return Ok(warehouses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("warehouse11/{id}")]
    public async Task<IActionResult> GetWarehouseById(int id)
    {
        try
        {
            var warehouses = await _warehouseService.GetWarehouseById(id);
            return Ok(warehouses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addArea")]
    public async Task<IActionResult> AddArea([FromBody] Area area)
    {
        try
        {
            await _warehouseService.AddArea(area);
            return Ok("Area added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addLocation")]
    public async Task<IActionResult> AddLocation([FromBody] Position position)
    {
        try
        {
            await _warehouseService.AddLocation(position);
            return Ok("Location added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPost("addLocations")]
    public async Task<IActionResult> AddLocations([FromBody] List<Position> positions)
    {
        try
        {
            await _warehouseService.AddLocations(positions);
            return Ok("Location added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("addWarehouse")]
    public async Task<IActionResult> AddWarehouse([FromBody] Warehouse warehouse)
    {
        try
        {
            await _warehouseService.AddWarehouse(warehouse);
            return Ok("Warehouse added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPost("updateWarehouse")]
    public async Task<IActionResult> UpdateWarehouse([FromBody] Warehouse warehouse)
    {
        try
        {
            await _warehouseService.UpdateWarehouse(warehouse);
            return Ok("Warehouse updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPost("updatePosition")]
    public async Task<IActionResult> UpdatePosition([FromBody] Position position)
    {
        try
        {
            await _warehouseService.UpdateLocation(position);
            return Ok("Position updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPost("updateArea")]
    public async Task<IActionResult> UpdateArea([FromBody] Area area)
    {
        try
        {
            await _warehouseService.UpdateArea(area);
            return Ok("Area updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("removeArea/{areaId}")]
    public async Task<IActionResult> RemoveArea(int areaId)
    {
        try
        {
            await _warehouseService.RemoveArea(areaId);
            return Ok("Area removed successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("removeLocation/{locationId}")]
    public async Task<IActionResult> RemoveLocation(int locationId)
    {
        try
        {
            await _warehouseService.RemoveLocation(locationId);
            return Ok("Location removed successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("removeWarehouse/{warehouseId}")]
    public async Task<IActionResult> RemoveWarehouse(int warehouseId)
    {
        try
        {
            await _warehouseService.RemoveWarehouse(warehouseId);
            return Ok("Warehouse removed successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("locationsInWarehouse/{warehouseId}")]
    public async Task<IActionResult> GetLocationsInWarehouse(int warehouseId)
    {
        try
        {
            var locationsInWarehouse = await _warehouseService.GetLocationsInWarehouse(warehouseId);
            return Ok(locationsInWarehouse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
