using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chartback.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chartback.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        ChartDBContext db = new ChartDBContext();

        /// <summary>
        /// Not really necessary
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
        /// Not enabled
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
        /// Create content to chart
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Content content)
        {
            Content c = new Content();

            
            c.ValueX = content.ValueX;
            c.ValueY = content.ValueY;

            db.Content.Add(c);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Delete an individual chart element
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}