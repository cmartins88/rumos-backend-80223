using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectoFinal.Data;
using ProjectoFinal.Models;

namespace ProjectoFinal.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
        {
            if (_context.WeatherForecasts == null)
            {
                return NotFound();
            }
            return Ok(_context.WeatherForecasts);
        }

        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast forecast)
        {
            if (_context.WeatherForecasts == null)
            {
                return NotFound();
            }

            if (forecast == null)
                return Problem("Forecast is null");

            try
            {
                _context.WeatherForecasts.Add(forecast);
            } catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem("Error while insert");
            }

            return Ok(forecast);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeatherForecast>> PutWeatherForecast(Guid id, WeatherForecast forecast)
        {
            if (_context.WeatherForecasts == null)
            {
                return NotFound();
            }

            if (forecast == null)
                return Problem("Forecast is null");

            try
            {
                if (_context.WeatherForecasts.Remove(_context.WeatherForecasts.Where(f => f.Id == id).First()))
                    _context.WeatherForecasts.Add(forecast);
                else
                    return Problem("can't find forecast");
            } catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem("Error while update");
            }


            return Ok(forecast);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherForecast>> DeleteWeatherForecast(Guid id)
        {
            if (_context.WeatherForecasts == null)
            {
                return NotFound();
            }

            try
            {
                if (_context.WeatherForecasts.Remove(_context.WeatherForecasts.Where(f => f.Id == id).Single()))
                    return Ok(id);
                else
                    return Problem("can't find forecast");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem("Error while remove");
            }
        }
    }
}