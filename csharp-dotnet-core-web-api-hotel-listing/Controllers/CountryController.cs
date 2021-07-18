using AutoMapper;
using csharp_dotnet_core_web_api_hotel_listing.DTOs;
using csharp_dotnet_core_web_api_hotel_listing.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<CountryController> _logger;
        private IMapper _mapper;
        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll(includes: new List<string> { "Hotels" });
                var results = _mapper.Map <IList<CountryDTO>>(countries);
                return StatusCode(StatusCodes.Status200OK, results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting the countries");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels"} );
                var result = _mapper.Map<CountryDTO>(country);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting the country with id:  " + id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
