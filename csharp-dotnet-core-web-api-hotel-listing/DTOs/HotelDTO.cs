using csharp_dotnet_core_web_api_hotel_listing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.DTOs
{

    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }
    }

    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Hotel Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Hotel Address is too long")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

}
