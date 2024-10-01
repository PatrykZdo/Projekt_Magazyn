using CarScrapyardWarehouse.Shared.Models;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Client.Interfaces
{
    public interface IVehicleService
    {  
        // Vehicles
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<IEnumerable<Vehicle>> GetArchivedVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task<Vehicle> InsertVehicle(Vehicle vehicle);
        Task<HttpResponseMessage> UpdateVehicle(Vehicle vehicle);

		Task<HttpResponseMessage> DeleteVehicle(int id);

        // Vehicle Types
        Task<IEnumerable<VehiclesType>> GetVehiclesTypes();
        Task<VehiclesType> GetVehiclesTypeById(int id);
        Task<HttpResponseMessage> InsertVehiclesType(VehiclesType vehiclesType);
        Task<HttpResponseMessage> DeleteVehiclesType(int id);

        // Images
        Task<HttpResponseMessage> AddImageToVehicle(int vehicleId, byte[] imageData);
        Task<HttpResponseMessage> AddImageToPart(int partId, byte[] imageData);
        Task<List<PartImage>> GetPartImagesByPartId(int idPart);
        Task<List<VehicleImage>> GetVehicleImagesByPartId(int idVehicle);

        // Parts
        Task<IEnumerable<Part>> GetParts();
        Task<IEnumerable<Part>> GetArchivedParts();
        Task<Part> GetPartById(int id);
        Task<Part> InsertPart(Part part);
        Task<HttpResponseMessage> UpdatePart(Part part);
        Task<HttpResponseMessage> DeletePart(int id);

        // Attributes
        Task<IEnumerable<Attribute>> GetAttributes();
        Task<Attribute> GetAttributeById(int id);
        Task<Attribute> InsertAttribute(Attribute attribute);
        Task<HttpResponseMessage> UpdateAttribute(Attribute attribute);
        Task<HttpResponseMessage> DeleteAttribute(int id);

        // Vehicle Attribute Values
        Task<IEnumerable<VehicleAttributeValue>> GetVehicleAttributeValues();
        Task<VehicleAttributeValue> GetVehicleAttributeValueById(int id);
        Task<HttpResponseMessage> InsertVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue);
        Task<HttpResponseMessage> UpdateVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue);
        Task<HttpResponseMessage> DeleteVehicleAttributeValue(int id);

        // Vehicle Type Attributes
        Task<IEnumerable<VehicleTypeAttribute>> GetVehicleTypeAttributes();
        Task<VehicleTypeAttribute> GetVehicleTypeAttributeById(int id);
        Task<HttpResponseMessage> InsertVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute);
        Task<HttpResponseMessage> UpdateVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute);
        Task<HttpResponseMessage> DeleteVehicleTypeAttribute(int id);
        Task<List<VehicleTypeAttribute>> GetVehicleTypeAttributeForType(int idType);


        Task<HttpResponseMessage> InsertPartsCatergory(PartsCategory partsCatergory);
        Task<IEnumerable<PartsCategory>> GetPartsCategories();
        Task<HttpResponseMessage> DeletePartsCatergory(int id);
        Task<HttpResponseMessage> UpdatePartsCategory(PartsCategory partsCatergory);

	}
}
