using CarScrapyardWarehouse.Server.Models;
using CarScrapyardWarehouse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarScrapyardWarehouse.Server.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IDbContextFactory<Server.Models.AppContext> _db;

        public WarehouseService(IDbContextFactory<Server.Models.AppContext> db)
        {
            _db = db;
        }

        public async Task<List<Area>> GetAreas()
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Areas.Include(a => a.IdWarehouseNavigation).ToListAsync();
            }
        }
        public async Task<Area> GetAreaById(int id)
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Areas.Where(x => x.Id == id).Include(a => a.IdWarehouseNavigation).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Position>> GetLocations()
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Positions.Include(l => l.IdAreaNavigation).ToListAsync();
            }
        }
        public async Task<Position> GetPositionsById(int id)
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Positions.Where(x => x.Id == id).Include(l => l.IdAreaNavigation).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Warehouses.ToListAsync();
            }
        }
        public async Task<Warehouse> GetWarehouseById(int id)
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Warehouses.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task AddArea(Area area)
        {
            using (var context = _db.CreateDbContext())
            {
                context.Areas.Add(area);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddLocation(Position location)
        {
            using (var context = _db.CreateDbContext())
            {
                context.Positions.Add(location);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddLocations(List<Position> locations)
        {
            using (var context = _db.CreateDbContext())
            {
                context.Positions.AddRange(locations);
                await context.SaveChangesAsync();
            }
        }
        public async Task<Position> UpdateLocation(Position location)
        {
            using (var context = _db.CreateDbContext())
			{
				context.Entry(location).State = EntityState.Modified;
				await context.SaveChangesAsync();
                return location;
			}
        }

        public async Task AddWarehouse(Warehouse warehouse)
        {
            using (var context = _db.CreateDbContext())
            {
                context.Warehouses.Add(warehouse);
                await context.SaveChangesAsync();
            }
        }
        public async Task<Warehouse> UpdateWarehouse(Warehouse warehouse)
        {
            using (var context = _db.CreateDbContext())
			{
				context.Entry(warehouse).State = EntityState.Modified;
				await context.SaveChangesAsync();
                return warehouse;
			}
        }
        public async Task<Area> UpdateArea(Area area)
        {
            using (var context = _db.CreateDbContext())
			{
				context.Entry(area).State = EntityState.Modified;
				await context.SaveChangesAsync();
                return area;
			}
        }

        public async Task RemoveArea(int areaId)
        {
            using (var context = _db.CreateDbContext())
            {
                var areaToRemove = await context.Areas.FindAsync(areaId);

                if (areaToRemove != null)
                {
                    context.Areas.Remove(areaToRemove);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Area not found.");
                }
            }
        }

        public async Task RemoveLocation(int locationId)
        {
            using (var context = _db.CreateDbContext())
            {
                var locationToRemove = await context.Positions.FindAsync(locationId);

                if (locationToRemove != null)
                {
                    context.Positions.Remove(locationToRemove);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Location not found.");
                }
            }
        }

        public async Task RemoveWarehouse(int warehouseId)
        {
            using (var context = _db.CreateDbContext())
            {
                var warehouseToRemove = await context.Warehouses.FindAsync(warehouseId);

                if (warehouseToRemove != null)
                {
                    context.Warehouses.Remove(warehouseToRemove);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Warehouse not found.");
                }
            }
        }

        public async Task<List<Position>> GetLocationsInWarehouse(int warehouseId)
        {
            using (var context = _db.CreateDbContext())
            {
                return await context.Positions
                    .Where(l => l.IdAreaNavigation.IdWarehouseNavigation.Id == warehouseId)
                    .Include(l => l.IdAreaNavigation).ThenInclude(l => l.IdWarehouseNavigation)
                                              .ToListAsync();
            }
        }
    }
}
