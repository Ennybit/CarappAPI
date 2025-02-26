using CarAPI.Data;
using CarAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories;

namespace CarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext context;
        public AdminController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Login(Login Login)
        {
            if(Login.Username == "admin" && Login.Password == "admin")
            {
                return Ok("Login Successful");
            }
            return Unauthorized();
        }


        [HttpGet]
        public ActionResult GetCars()
        {
            
            return Ok(context.Cars.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetCars(int id)
        {
            return Ok(context.Cars.Find(id));
        }
        [HttpGet]
        public ActionResult GetInquires()
        {

            return Ok(context.Inquiries.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> AddCars(AddCarsRepo repo)
        {
            var result = new Cars
            {
                Make = repo.Make,
                Model = repo.Model,
                Year = repo.Year,
                Price = repo.Price,
                ImageURL = repo.ImageURL,
                Description = repo.Description
            };
            await context.Cars.AddAsync(result);
            await context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCars(int id)
        {
            var find = await context.Cars.FindAsync(id);
            if(find == null)
            {
                return NotFound();
            }
            context.Cars.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCars( EditCarsRepo repo)
        {
            var find = await context.Cars.FindAsync(repo.Id);
            if(find == null)
            {
                return NotFound();
            }

            find.Make = repo.Make;
            find.Model = repo.Model;
            find.Year = repo.Year;
            find.Price = repo.Price;
            find.ImageURL = repo.ImageURL;
            find.Description = repo.Description;
            find.UpdateAt = repo.UpdateAt;
            context.Entry(find).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(find);
        }
    }
}
