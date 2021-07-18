using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}
