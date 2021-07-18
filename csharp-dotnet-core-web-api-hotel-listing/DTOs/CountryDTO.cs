using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.DTOs
{
    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }

        public IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Country Code is too long")]
        public string Code { get; set; }
    }
}
