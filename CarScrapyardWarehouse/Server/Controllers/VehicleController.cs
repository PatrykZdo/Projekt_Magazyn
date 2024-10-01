using CarScrapyardWarehouse.Server.Services;
using CarScrapyardWarehouse.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    // Vehicles
    [HttpGet("vehicles")]
    public IEnumerable<Vehicle> GetVehicles()
    {
        return _vehicleService.GetVehicles();
    }

    [HttpGet("archivedVehicles")]
    public IEnumerable<Vehicle> GetArchivedVehicles()
    {
        return _vehicleService.GetArchivedVehicles();
    }

    [HttpGet("vehicles/{id}")]
    public ActionResult<Vehicle> GetVehicleById(int id)
    {
        var vehicle = _vehicleService.GetVehicleById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpPost("vehicles")]
    public ActionResult<Vehicle> InsertVehicle(Vehicle vehicle)
    {
        return _vehicleService.InsertVehicle(vehicle);
    }

    [HttpDelete("vehicles/{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        _vehicleService.DeleteVehicle(id);
        return Ok();
    }

    // Vehicle Types
    [HttpGet("vehicletypes")]
    public IEnumerable<VehiclesType> GetVehiclesTypes()
    {
        return _vehicleService.GetVehiclesTypes();
    }

    [HttpGet("vehicletypes/{id}")]
    public ActionResult<VehiclesType> GetVehiclesTypeById(int id)
    {
        var vehicleType = _vehicleService.GetVehiclesTypeById(id);
        if (vehicleType == null)
        {
            return NotFound();
        }
        return vehicleType;
    }

    [HttpPost("vehicletypes")]
    public IActionResult InsertVehiclesType(VehiclesType vehiclesType)
    {
        _vehicleService.InsertVehiclesType(vehiclesType);
        return Ok();
    }

    [HttpDelete("vehicletypes/{id}")]
    public IActionResult DeleteVehiclesType(int id)
    {
        _vehicleService.DeleteVehiclesType(id);
        return Ok();
    }

    // Images
    [HttpPost("vehicles/{vehicleId}/images")]
    public IActionResult AddImageToVehicle(int vehicleId, [FromBody] byte[] imageData)
    {
        try
        {
            _vehicleService.AddImageToVehicle(vehicleId, imageData);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPost("parts/{partId}/images")]
    public IActionResult AddImageToPart(int partId, [FromBody] byte[] imageData)
    {
        try
        {
            _vehicleService.AddImageToPart(partId, imageData);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    } 
    // Parts
    [HttpGet("parts")]
    public IEnumerable<Part> GetParts() => _vehicleService.GetParts();

    [HttpGet("archivedParts")]
    public IEnumerable<Part> GetArchivedParts() => _vehicleService.GetArchivedParts();

    [HttpGet("parts/{id}")]
    public Part GetPartById(int id) => _vehicleService.GetPartById(id);

    [HttpPost("parts")]
    public async Task<ActionResult<Part>> InsertPart(Part part)
    {
        return await _vehicleService.InsertPart(part);
    }

    [HttpPut("parts")]
    public IActionResult UpdatePart(Part part)
    {
        _vehicleService.UpdatePart(part);
        return Ok();
    }
    [HttpGet("partImages/{id}")]
    public List<PartImage> GetPartImagesByPartId(int id) => _vehicleService.GetPartImagesByPartId(id);
    [HttpGet("vehicleImages/{id}")]
    public List<VehicleImage> GetVehicleImagesByPartId(int id) => _vehicleService.GetVehicleImagesByPartId(id);

    [HttpDelete("parts/{id}")]
    public IActionResult DeletePart(int id)
    {
        _vehicleService.DeletePart(id);
        return Ok();
    }

    // Attributes
    [HttpGet("attributes")]
    public IEnumerable<Attribute> GetAttributes() => _vehicleService.GetAttributes();

    [HttpGet("attributes/{id}")]
    public Attribute GetAttributeById(int id) => _vehicleService.GetAttributeById(id);

    [HttpPost("attributes")]
    public async Task<Attribute> InsertAttribute(Attribute attribute)
    {
        return await _vehicleService.InsertAttribute(attribute);
    }

    [HttpPut("attributes")]
    public IActionResult UpdateAttribute(Attribute attribute)
    {
        _vehicleService.UpdateAttribute(attribute);
        return Ok();
    }

    [HttpDelete("attributes/{id}")]
    public IActionResult DeleteAttribute(int id)
    {
        _vehicleService.DeleteAttribute(id);
        return Ok();
    }

    // Vehicle Attribute Values
    [HttpGet("vehicleattributevalues")]
    public IEnumerable<VehicleAttributeValue> GetVehicleAttributeValues() => _vehicleService.GetVehicleAttributeValues();

    [HttpGet("vehicleattributevalues/{id}")]
    public VehicleAttributeValue GetVehicleAttributeValueById(int id) => _vehicleService.GetVehicleAttributeValueById(id);

    [HttpPost("vehicleattributevalues")]
    public IActionResult InsertVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
    {
        _vehicleService.InsertVehicleAttributeValue(vehicleAttributeValue);
        return Ok();
    }

    [HttpPut("vehicleattributevalues")]
    public IActionResult UpdateVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
    {
        _vehicleService.UpdateVehicleAttributeValue(vehicleAttributeValue);
        return Ok();
    }

    [HttpDelete("vehicleattributevalues/{id}")]
    public IActionResult DeleteVehicleAttributeValue(int id)
    {
        _vehicleService.DeleteVehicleAttributeValue(id);
        return Ok();
    }

    // Vehicle Type Attributes
    [HttpGet("vehicletypeattributes")]
    public IEnumerable<VehicleTypeAttribute> GetVehicleTypeAttributes() => _vehicleService.GetVehicleTypeAttributes();

    [HttpGet("vehicletypeattributes/{id}")]
    public VehicleTypeAttribute GetVehicleTypeAttributeById(int id) => _vehicleService.GetVehicleTypeAttributeById(id);

    [HttpGet("vehicletypeattributesfortype/{idType}")]
    public async Task<IEnumerable<VehicleTypeAttribute>> GetVehicleTypeAttributeForType(int idType) => await _vehicleService.GetVehicleTypeAttributeForType(idType);

    [HttpPost("vehicletypeattributes")]
    public IActionResult InsertVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
    {
        _vehicleService.InsertVehicleTypeAttribute(vehicleTypeAttribute);
        return Ok();
    }

    [HttpPut("vehicletypeattributes")]
    public IActionResult UpdateVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
    {
        _vehicleService.UpdateVehicleTypeAttribute(vehicleTypeAttribute);
        return Ok();
    }
    [HttpPut("vehicle")]
    public IActionResult UpdateVehicle(Vehicle vehicle)
    {
        _vehicleService.UpdateVehicle(vehicle);
        return Ok();
    }
    [HttpPut("partsCategory")]
    public IActionResult PartsCategory(PartsCategory partsCatergory)
    {
        _vehicleService.UpdatePartsCatergory(partsCatergory);
        return Ok();
    }

    [HttpDelete("vehicletypeattributes/{id}")]
    public IActionResult DeleteVehicleTypeAttribute(int id)
    {
        _vehicleService.DeleteVehicleTypeAttribute(id);
        return Ok();
    }
    [HttpDelete("daletepartscategory/{id}")]
    public IActionResult DeletePartsCatergory(int id)
    {
        _vehicleService.DeletePartsCatergory(id);
        return Ok();
	}
	[HttpGet("partscategories")]
	public IEnumerable<PartsCategory> GetPartsCategories()
	{
		return _vehicleService.GetPartsCategories();
	}

	[HttpPost("partscategory")]
	public ActionResult<PartsCategory> InsertPartsCatergory(PartsCategory partsCatergory)
	{
		return _vehicleService.InsertPartsCatergory(partsCatergory);
	}
}

