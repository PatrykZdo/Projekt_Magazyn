using CarScrapyardWarehouse.Shared.Models;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Server.Services
{
    public interface IVehicleService
    {
        //vehicles
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicleById(int id);
        Vehicle InsertVehicle(Vehicle vehicle);
        Vehicle UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        IEnumerable<Vehicle> GetArchivedVehicles();

        //types
        IEnumerable<VehiclesType> GetVehiclesTypes();
        VehiclesType GetVehiclesTypeById(int id);
        void InsertVehiclesType(VehiclesType vehiclesType);
        void DeleteVehiclesType(int id);

        //images
        void AddImageToVehicle(int vehicleId, byte[] imageData);
        void AddImageToPart(int partId, byte[] imageData);
        List<VehicleImage> GetVehicleImagesByPartId(int vehicleId);
        List<PartImage> GetPartImagesByPartId(int partId);

        //parts
        IEnumerable<Part> GetParts();
        IEnumerable<Part> GetArchivedParts();
        Part GetPartById(int id);
        Task<Part> InsertPart(Part part);
        void UpdatePart(Part part);
        void DeletePart(int id);

        //attributes
        IEnumerable<Attribute> GetAttributes();
        Attribute GetAttributeById(int id);
        Task<Attribute> InsertAttribute(Attribute attribute);
        void UpdateAttribute(Attribute attribute);
        void DeleteAttribute(int id);

        //vehicle attribute values
        IEnumerable<VehicleAttributeValue> GetVehicleAttributeValues();
        VehicleAttributeValue GetVehicleAttributeValueById(int id);
        void InsertVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue);
        void UpdateVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue);
        void DeleteVehicleAttributeValue(int id);
        IEnumerable<VehicleAttributeValue> GetVehicleAttributeValuesByVehicleId(int vehicleId);

        //VehicleTypeAttributes
        IEnumerable<VehicleTypeAttribute> GetVehicleTypeAttributes();
        VehicleTypeAttribute GetVehicleTypeAttributeById(int id);
        void InsertVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute);
        void UpdateVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute);
        void DeleteVehicleTypeAttribute(int id);
        Task<List<VehicleTypeAttribute>> GetVehicleTypeAttributeForType(int idType);

        //partscategory
        PartsCategory UpdatePartsCatergory(PartsCategory partsCatergory);
        void DeletePartsCatergory(int id);
        IEnumerable<PartsCategory> GetPartsCategories();
        PartsCategory InsertPartsCatergory(PartsCategory partsCatergory);

	}
}