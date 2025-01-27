using Microsoft.AspNetCore.Mvc;
using HardkorowyKodsu.WebApi.Business.Interfaces;
using HardkorowyKodsu.WebApi.CommonModel.Structures;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HardkorowyKodsu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseStructureController : ControllerBase
    {
        private IDatabaseStructureManager _databaseStructureManager;

        public DatabaseStructureController(IDatabaseStructureManager databaseStructureManager)
        {
            Log.Debug("Creating Controler");
            _databaseStructureManager = databaseStructureManager;
        }

        // GET: api/<DatabaseStructureController>
        [HttpGet]
        public async Task<ActionResult<DatabaseStructure>> GetDatabaseStructure()
        {
            try
            {
                Log.Information("Getting database structure");
                var databaseStructure = await _databaseStructureManager.GetDatabaseStructureAsync();

                Log.Debug("Returning database structure");
                return Ok(databaseStructure);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when trying to get database structure");
                return StatusCode(500);
            }

        }

        // GET api/<DatabaseStructureController>/Person
        [HttpGet("{name}")]
        public async Task<ActionResult<TableStructure>> GetTableStructure(string name)
        {
            try
            {
                Log.Information("Getting structure for table {Name}", name);
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"Element „{nameof(name)}” nie może mieć wartości null ani być pusty.", nameof(name));
                }

                var tableStructure = await _databaseStructureManager.GetTableStructureAsync(name);

                Log.Debug("Returning table structure");
                return Ok(tableStructure);
            }
            catch(ArgumentException ex)
            {
                Log.Warning(ex, "Provided table name was null or empty");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when trying to get table structure");
                return StatusCode(500);
            }
        }

    }
}
