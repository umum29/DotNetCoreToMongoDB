global using DotnetBckofficeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetBckofficeApi.Services;


namespace DotnetBckofficeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
      //since Net 7 does not support EF core for MongoDB, we use "Service layer" instead of Repository/ORM layer
      private readonly HotelService _hotelService;
      public HotelController(HotelService hotelService) => _hotelService = hotelService;

      [HttpGet]
      public async Task<ActionResult<List<Hotel>>> Get() => await _hotelService.GetAsync();

      [HttpGet("{id}")]
      public async Task<ActionResult<Hotel>> Get(string id)
      {
        var hotel = await _hotelService.GetAsync(id);
        if(hotel is null)
        {
          return NotFound();
        }
        return hotel;
      }
       
    }
}