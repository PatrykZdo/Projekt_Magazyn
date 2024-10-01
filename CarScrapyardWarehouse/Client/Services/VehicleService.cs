using CarScrapyardWarehouse.Client.Interfaces;
using CarScrapyardWarehouse.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Client.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IHttpService _httpService;
        private const string BaseUrl = "api/vehicle/";

        public VehicleService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        // Vehicles
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _httpService.Get<IEnumerable<Vehicle>>(BaseUrl + "vehicles");
        }
        public async Task<IEnumerable<Vehicle>> GetArchivedVehicles()
        {
            return await _httpService.Get<IEnumerable<Vehicle>>(BaseUrl + "archivedVehicles");
        }


        public async Task<Vehicle> GetVehicleById(int id)
        {
            return await _httpService.Get<Vehicle>(BaseUrl + $"vehicles/{id}");
        }

        public async Task<Vehicle> InsertVehicle(Vehicle vehicle)
        {
            return await _httpService.Post<Vehicle>(BaseUrl + "vehicles", vehicle);
        }

        public async Task<HttpResponseMessage> DeleteVehicle(int id)
        {
            return await _httpService.Delete(BaseUrl + $"vehicles/{id}");
        }

        // Vehicle Types
        public async Task<IEnumerable<VehiclesType>> GetVehiclesTypes()
        {
            return await _httpService.Get<IEnumerable<VehiclesType>>(BaseUrl + "vehicletypes");
        }

        public async Task<VehiclesType> GetVehiclesTypeById(int id)
        {
            return await _httpService.Get<VehiclesType>(BaseUrl + $"vehicletypes/{id}");
        }

        public async Task<HttpResponseMessage> InsertVehiclesType(VehiclesType vehiclesType)
        {
            return await _httpService.Post(BaseUrl + "vehicletypes", vehiclesType);
        }

        public async Task<HttpResponseMessage> DeleteVehiclesType(int id)
        {
            return await _httpService.Delete(BaseUrl + $"vehicletypes/{id}");
        }

        // Images
        public async Task<HttpResponseMessage> AddImageToVehicle(int vehicleId, byte[] imageData)
        {
            return await _httpService.Post(BaseUrl + $"vehicles/{vehicleId}/images", imageData);
        }

        public async Task<HttpResponseMessage> AddImageToPart(int partId, byte[] imageData)
        {
            return await _httpService.Post(BaseUrl + $"parts/{partId}/images", imageData);
        }
        public async Task<List<PartImage>> GetPartImagesByPartId(int idPart)
        {
            return await _httpService.Get<List<PartImage>>(BaseUrl + $"partImages/{idPart}");
        }
        public async Task<List<VehicleImage>> GetVehicleImagesByPartId(int idVehicle)
        {
            return await _httpService.Get<List<VehicleImage>>(BaseUrl + $"vehicleImages/{idVehicle}");
        }

        // Parts
        public async Task<IEnumerable<Part>> GetParts()
        {
            return await _httpService.Get<IEnumerable<Part>>(BaseUrl + "parts");
        }
        public async Task<IEnumerable<Part>> GetArchivedParts()
        {
            return await _httpService.Get<IEnumerable<Part>>(BaseUrl + "archivedParts");
        }

        public async Task<Part> GetPartById(int id)
        {
            return await _httpService.Get<Part>(BaseUrl + $"parts/{id}");
        }

        public async Task<Part> InsertPart(Part part)
        {
            return await _httpService.Post<Part>(BaseUrl + "parts", part);
        }

        public async Task<HttpResponseMessage> UpdatePart(Part part)
        {
            return await _httpService.Put(BaseUrl + "parts", part);
        }

        public async Task<HttpResponseMessage> DeletePart(int id)
        {
            return await _httpService.Delete(BaseUrl + $"parts/{id}");
        }

        // Attributes
        public async Task<IEnumerable<Attribute>> GetAttributes()
        {
            return await _httpService.Get<IEnumerable<Attribute>>(BaseUrl + "attributes");
        }

        public async Task<Attribute> GetAttributeById(int id)
        {
            return await _httpService.Get<Attribute>(BaseUrl + $"attributes/{id}");
        }

        public async Task<Attribute> InsertAttribute(Attribute attribute)
        {
            return await _httpService.Post<Attribute>(BaseUrl + "attributes", attribute);
        }

        public async Task<HttpResponseMessage> UpdateAttribute(Attribute attribute)
        {
            return await _httpService.Put(BaseUrl + "attributes", attribute);
        }

        public async Task<HttpResponseMessage> DeleteAttribute(int id)
        {
            return await _httpService.Delete(BaseUrl + $"attributes/{id}");
        }

        // Vehicle Attribute Values
        public async Task<IEnumerable<VehicleAttributeValue>> GetVehicleAttributeValues()
        {
            return await _httpService.Get<IEnumerable<VehicleAttributeValue>>(BaseUrl + "vehicleattributevalues");
        }

        public async Task<VehicleAttributeValue> GetVehicleAttributeValueById(int id)
        {
            return await _httpService.Get<VehicleAttributeValue>(BaseUrl + $"vehicleattributevalues/{id}");
        }

        public async Task<HttpResponseMessage> InsertVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
        {
            return await _httpService.Post(BaseUrl + "vehicleattributevalues", vehicleAttributeValue);
        }

        public async Task<HttpResponseMessage> UpdateVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
        {
            return await _httpService.Put(BaseUrl + "vehicleattributevalues", vehicleAttributeValue);
        }
        public async Task<HttpResponseMessage> UpdateVehicle(Vehicle vehicle)
        {
            return await _httpService.Put(BaseUrl + "vehicle", vehicle);
        }

        public async Task<HttpResponseMessage> DeleteVehicleAttributeValue(int id)
        {
            return await _httpService.Delete(BaseUrl + $"vehicleattributevalues/{id}");
        }

        // Vehicle Type Attributes
        public async Task<IEnumerable<VehicleTypeAttribute>> GetVehicleTypeAttributes()
        {
            return await _httpService.Get<IEnumerable<VehicleTypeAttribute>>(BaseUrl + "vehicletypeattributes");
        }

        public async Task<VehicleTypeAttribute> GetVehicleTypeAttributeById(int id)
        {
            return await _httpService.Get<VehicleTypeAttribute>(BaseUrl + $"vehicletypeattributes/{id}");
        }

        public async Task<List<VehicleTypeAttribute>> GetVehicleTypeAttributeForType(int idType)
        {
            return await _httpService.Get<List<VehicleTypeAttribute>>(BaseUrl + $"vehicletypeattributesfortype/{idType}");
        }

        public async Task<HttpResponseMessage> InsertVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
        {
            return await _httpService.Post(BaseUrl + "vehicletypeattributes", vehicleTypeAttribute);
        }

        public async Task<HttpResponseMessage> UpdateVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
        {
            return await _httpService.Put(BaseUrl + "vehicletypeattributes", vehicleTypeAttribute);
        }

        public async Task<HttpResponseMessage> DeleteVehicleTypeAttribute(int id)
        {
            return await _httpService.Delete(BaseUrl + $"vehicletypeattributes/{id}");
        }
		public async Task<HttpResponseMessage> InsertPartsCatergory(PartsCategory partsCatergory)
		{
			return await _httpService.Post(BaseUrl + "partscategory", partsCatergory);
		}
		public async Task<IEnumerable<PartsCategory>> GetPartsCategories()
		{
			return await _httpService.Get<IEnumerable<PartsCategory>>(BaseUrl + "partscategories");
		}
		public async Task<HttpResponseMessage> DeletePartsCatergory(int id)
		{
			return await _httpService.Delete(BaseUrl + $"daletepartscategory/{id}");
		}
		public async Task<HttpResponseMessage> UpdatePartsCategory(PartsCategory partsCatergory)
		{
			return await _httpService.Put(BaseUrl + "partsCategory", partsCatergory);
		}
	}
}
