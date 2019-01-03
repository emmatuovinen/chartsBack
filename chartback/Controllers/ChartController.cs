using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chartback.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace chartback.Controllers
{
    [EnableCors("MyPolicy")]
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
            //return "value";

            Chart chart = db.Chart.Find(id);

            var chartAndContent = from b in db.Chart
                                  join c in db.Content on b.ChartId equals c.ChartId
                                  where b.ChartId == chart.ChartId
                                  select new { X = c.ValueX,  Y = c.ValueY };

            return Ok(chartAndContent);

        }

        /// <summary>
        /// Create a chart
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Chart chart)
        {
            Chart c = new Chart();

            //var chartCount = (from a in db.Chart
            //                 select a).Count();

            //c.ChartId = chartCount + 1;
            c.Headline = chart.Headline;
            c.Description = chart.Description;

            db.Chart.Add(c);
            db.SaveChanges();


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
           Chart chart = db.Chart.Find(id);

            db.Chart.Remove(chart);
            db.SaveChanges();
        }
    }
}
