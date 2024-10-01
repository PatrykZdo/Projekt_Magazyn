using CarScrapyardWarehouse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Server.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IDbContextFactory<Server.Models.AppContext> _dbFactory;

        public VehicleService(IDbContextFactory<Server.Models.AppContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        //vehicles
        public IEnumerable<Vehicle> GetVehicles()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Vehicles.Where(x => x.Archived == false)
								.Include(x => x.IdTypeNavigation)
								.Include(x => x.VehicleAttributeValues)
								.ThenInclude(x => x.IdAttributeNavigation)
								.Include(x => x.VehicleImages)
								.ThenInclude(x => x.IdImageNavigation)
								.ToList();
			}
        }
        public IEnumerable<Vehicle> GetArchivedVehicles()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Vehicles.Where(x => x.Archived == true)
                                .Include(x => x.IdTypeNavigation)
                                .Include(x => x.VehicleAttributeValues)
                                .ThenInclude(x => x.IdAttributeNavigation)
                                .Include(x => x.VehicleImages)
                                .ThenInclude(x => x.IdImageNavigation)
                                .ToList();
            }
        }

        public Vehicle GetVehicleById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Vehicles
                                .Include(x => x.IdTypeNavigation)
                                .Include(x => x.VehicleAttributeValues)
                                .ThenInclude(x => x.IdAttributeNavigation)
                                .Include(x => x.VehicleImages)
                                .ThenInclude(x => x.IdImageNavigation)
                                .FirstOrDefault(v => v.Id == id);
            }
        }

        public Vehicle InsertVehicle(Vehicle vehicle)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                vehicle.Model = vehicle.Model.ToUpper();
                vehicle.Brand = vehicle.Brand.ToUpper();
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return vehicle;
            }
        }
        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            using (var db = _dbFactory.CreateDbContext())
			{
				db.Entry(vehicle).State = EntityState.Modified;
				db.SaveChanges();
                return vehicle;
			}
        }

        public void DeleteVehicle(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehicle = db.Vehicles.FirstOrDefault(v => v.Id == id);
                if (vehicle != null)
                {
                    vehicle.Archived = true;
                    db.Vehicles.Update(vehicle);
                    db.SaveChanges();
                }
            }
        }
    
        //types
        public IEnumerable<VehiclesType> GetVehiclesTypes()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehiclesTypes.ToList();
            }
        }

        public VehiclesType GetVehiclesTypeById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehiclesTypes.FirstOrDefault(vt => vt.Id == id);
            }
        }

        public void InsertVehiclesType(VehiclesType vehiclesType)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.VehiclesTypes.Add(vehiclesType);
                db.SaveChanges();
            }
        }

        public void DeleteVehiclesType(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehiclesType = db.VehiclesTypes.FirstOrDefault(vt => vt.Id == id);
                if (vehiclesType != null)
                {
                    db.VehiclesTypes.Remove(vehiclesType);
                    db.SaveChanges();
                }
            }
        }

        //images
        public void AddImageToVehicle(int vehicleId, byte[] imageData)
        {
            var data = Resize2Max50Kbytes(imageData);
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehicle = db.Vehicles.Find(vehicleId);
                if (vehicle != null)
                {
                    var image = new Image { Image1 = data };
                    db.Images.Add(image);
                    db.SaveChanges();

                    vehicle.VehicleImages.Add(new VehicleImage { IdImage = image.Id, IdVehicle = vehicle.Id, InsertDate = DateTime.Now });
                    db.SaveChanges();
                }
            }
        }

        public byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            using (var image = SixLabors.ImageSharp.Image.Load(byteImageIn))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(400, 400),
                    Mode = ResizeMode.Max
                }));
                using (var outputStream = new MemoryStream())
                {
                    image.Save(outputStream, new JpegEncoder());
                    return outputStream.ToArray();
                }
            }
        }
        public void AddImageToPart(int partId, byte[] imageData)
        {
            var data = Resize2Max50Kbytes(imageData);
            using (var db = _dbFactory.CreateDbContext())
            {
                var part = db.Parts.Find(partId);
                if (part != null)
                {
                    var image = new Image { Image1 = data };
                    db.Images.Add(image);
                    db.SaveChanges();

                    part.PartImages.Add(new PartImage { IdImage = image.Id, IdPart = part.Id, InsertDate = DateTime.Now });
                    db.SaveChanges();
                }
            }
        }
        public List<PartImage> GetPartImagesByPartId(int partId)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var partImages = db.PartImages
                                    .Where(pi => pi.IdPart == partId)
                                    .ToList();
                return partImages;
            }
        }
        public List<VehicleImage> GetVehicleImagesByPartId(int vehicleId)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehicleImages = db.VehicleImages
                                    .Where(pi => pi.IdVehicle == vehicleId)
                                    .ToList();
                return vehicleImages;
            }
        }

        //parts
        public IEnumerable<Part> GetParts()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                
                var temp = db.Parts.Where(x => x.Archived == false)
							.Include(x => x.PartImages)
							.ThenInclude(x => x.IdImageNavigation)
							.ToList();
                return temp;
			}
            
        }
        public IEnumerable<Part> GetArchivedParts()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Parts.Where(x => x.Archived == true)
					        .Include(x => x.IdVehicleNavigation)
                            .Include(x => x.IdPositionNavigation)
                            .Include(x => x.PartImages)
                            .ThenInclude(x => x.IdImageNavigation)
                            .ToList();
            }
        }

        public Part GetPartById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Parts.Where(p => p.Id == id)
                            .Include(x => x.PartImages)
                            .ThenInclude(x => x.IdImageNavigation)
                            .FirstOrDefault();
            }
        }

        public async Task<Part> InsertPart(Part part)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                part.Name = part.Name.ToUpper();
                db.Parts.Add(part);
                await db.SaveChangesAsync();
                return part;
            }
        }

        public void UpdatePart(Part part)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeletePart(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var part = db.Parts.FirstOrDefault(p => p.Id == id);
                if (part != null)
                {
                    part.Archived = true;
                    db.Parts.Update(part);
                    db.SaveChanges();
                }
            }
        }

        //attributes
        public IEnumerable<Attribute> GetAttributes()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Attributes.ToList();
            }
        }

        public Attribute GetAttributeById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.Attributes.FirstOrDefault(a => a.Id == id);
            }
        }

        public async Task<Attribute> InsertAttribute(Attribute attribute)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Attributes.Add(attribute);
                await db.SaveChangesAsync();
                return attribute;
            }
        }

        public void UpdateAttribute(Attribute attribute)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Entry(attribute).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteAttribute(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var attribute = db.Attributes.FirstOrDefault(a => a.Id == id);
                if (attribute != null)
                {
                    db.Attributes.Remove(attribute);
                    db.SaveChanges();
                }
            }
        }

        //vehicle attribute values
        public IEnumerable<VehicleAttributeValue> GetVehicleAttributeValues()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehicleAttributeValues.ToList();
            }
        }
        public VehicleAttributeValue GetVehicleAttributeValueById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehicleAttributeValues.FirstOrDefault(vav => vav.Id == id);
            }
        }

        public void InsertVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.VehicleAttributeValues.Add(vehicleAttributeValue);
                db.SaveChanges();
            }
        }

        public void UpdateVehicleAttributeValue(VehicleAttributeValue vehicleAttributeValue)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Entry(vehicleAttributeValue).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteVehicleAttributeValue(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehicleAttributeValue = db.VehicleAttributeValues.FirstOrDefault(vav => vav.Id == id);
                if (vehicleAttributeValue != null)
                {
                    db.VehicleAttributeValues.Remove(vehicleAttributeValue);
                    db.SaveChanges();
                }
            }
        }
        public IEnumerable<VehicleAttributeValue> GetVehicleAttributeValuesByVehicleId(int vehicleId)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehicleAttributeValues.Where(vav => vav.IdVehicleNavigation.Id == vehicleId).Include(x => x.IdAttributeNavigation).ToList();
            }
        }


        //VehicleTypeAttributes
        public IEnumerable<VehicleTypeAttribute> GetVehicleTypeAttributes()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehicleTypeAttributes.ToList();
            }
        }

        public VehicleTypeAttribute GetVehicleTypeAttributeById(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return db.VehicleTypeAttributes.FirstOrDefault(vta => vta.Id == id);
            }
        }

        public void InsertVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.VehicleTypeAttributes.Add(vehicleTypeAttribute);
                db.SaveChanges();
            }
        }

        public void UpdateVehicleTypeAttribute(VehicleTypeAttribute vehicleTypeAttribute)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Entry(vehicleTypeAttribute).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteVehicleTypeAttribute(int id)
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var vehicleTypeAttribute = db.VehicleTypeAttributes.FirstOrDefault(vta => vta.Id == id);
                if (vehicleTypeAttribute != null)
                {
                    db.VehicleTypeAttributes.Remove(vehicleTypeAttribute);
                    db.SaveChanges();
                }
            }
        }

		//partscategory
		public IEnumerable<PartsCategory> GetPartsCategories()
		{
			using (var db = _dbFactory.CreateDbContext())
			{
				return db.PartsCatergories.ToList();
			}
		}
		public PartsCategory UpdatePartsCatergory(PartsCategory partsCatergory)
		{
			using (var db = _dbFactory.CreateDbContext())
			{
				db.Entry(partsCatergory).State = EntityState.Modified;
				db.SaveChanges();
				return partsCatergory;
			}
		}
		public void DeletePartsCatergory(int id)
		{
			using (var db = _dbFactory.CreateDbContext())
			{
				var vehicle = db.PartsCatergories.FirstOrDefault(v => v.Id == id);
				if (vehicle != null)
				{
					db.PartsCatergories.Remove(vehicle);
					db.SaveChanges();
				}
			}
		}
		public PartsCategory InsertPartsCatergory(PartsCategory partsCatergory)
		{
			using (var db = _dbFactory.CreateDbContext())
			{
				db.PartsCatergories.Add(partsCatergory);
				db.SaveChanges();
				return partsCatergory;
			}
		}
        public async Task<List<VehicleTypeAttribute>> GetVehicleTypeAttributeForType(int idType) 
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                return await db.VehicleTypeAttributes.Where(x => x.IdVehiclesType == idType).Include(x => x.IdAttributeNavigation).Include(x => x.IdVehiclesTypeNavigation).ToListAsync();
            }
        }
	}
}
