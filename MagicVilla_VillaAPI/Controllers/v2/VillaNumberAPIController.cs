using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {

        protected APIResponse _response;
        private readonly ILogger<v1.VillaNumberAPIController> _logger;
        private readonly IVillaNumberRepository _context;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(IVillaRepository dbVilla, IMapper mapper, ILogger<v1.VillaNumberAPIController> logger, IVillaNumberRepository context)
        {
            _dbVilla = dbVilla;
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 version2", "value2 version2" };
        }

    }
}
