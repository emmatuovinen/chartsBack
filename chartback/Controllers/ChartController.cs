using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chartback.Models;
using Microsoft.AspNetCore.Mvc;

namespace chartback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        ChartDBContext db = new ChartDBContext();

        /// <summary>
        /// Get all charts
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] { "value1", "value2" };

            var allCharts = from c in db.Chart
                            select c;

            var chartlist = new List<Chart>();
            chartlist = allCharts.ToList();

            return Ok(chartlist);

        }

        /// <summary>
        /// Get chart with content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Create a chart
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Delete a chart and all content
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
