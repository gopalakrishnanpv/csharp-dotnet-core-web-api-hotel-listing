using csharp_dotnet_core_web_api_hotel_listing.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Hotel> Hotels { get; }

        Task Save();
    }
}
