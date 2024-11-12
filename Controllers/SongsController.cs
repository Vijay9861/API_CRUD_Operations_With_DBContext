using Microsoft.AspNetCore.Mvc;
using NewAPI.Models;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace NewAPI.Controllers
{
    //[Route("[controller]")]
    [Route("College")]
    public class SongsController : Controller
    {

        private readonly UsbmContext context;
        public SongsController(UsbmContext context)
        {
            this.context = context;
        }

        [HttpGet("Student")]
        public IActionResult GetAll()
        {
            var Data = context.Students.ToList();
            if (Data == null)
            {
                return NotFound("No Data");
            }
            return Ok(Data);
        }
        [HttpGet("StudentGetBy/{id}")]
        public IActionResult GetById(int id)
        {
            var Data = context.Students.FirstOrDefault(x => x.StdId == id);
            if (Data == null)
            {
                return NotFound("No Data");
            }
            return Ok(Data);
        }
        [HttpPost("AddNewStudent")]
        public IActionResult InsertStd([Bind("StdName","Age","City")] Student Obj)
        {

            if (Obj != null)
            {
                context.Students.Add(Obj);
                context.SaveChanges();
                return Ok(Obj);
            }
            return NotFound("No Data Added");
        }
        [HttpPut("UpdateStudent")]
        public IActionResult Update([Bind("StdId","StdName", "Age", "City")] Student Obj)
        {
            var Data = context.Students.FirstOrDefault(x => x.StdId == Obj.StdId);
            if (Data != null)
            {

                Data.StdName=Obj.StdName;
                Data.Age=Obj.Age;
                Data.City=Obj.City;
                context.SaveChanges();
            }
            return Ok(Data);

        }
        [HttpDelete("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            var Data = context.Students.FirstOrDefault(e => e.StdId == id);
            if (Data == null)
            {
                return BadRequest("No Data");
            }
            context.Students.Remove(Data);
            context.SaveChanges();
            return Ok(Data);
        }





    }
}
