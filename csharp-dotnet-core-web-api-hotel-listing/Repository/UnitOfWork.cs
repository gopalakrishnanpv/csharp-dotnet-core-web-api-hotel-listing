using csharp_dotnet_core_web_api_hotel_listing.Data;
using csharp_dotnet_core_web_api_hotel_listing.IRepository;
using csharp_dotnet_core_web_api_hotel_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private DatabaseContext _context;
        private IGenericRepository<Country> countries;
        private IGenericRepository<Hotel> hotels;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Country> Countries => countries ?? new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => hotels ?? new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
