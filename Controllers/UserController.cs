using CarAPI.Data;
using CarAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace CarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IEmailService _emailservice;
        public UserController(DataContext context, IEmailService emailservice)
        {
            this.context = context;
            _emailservice = emailservice;
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

        [HttpPost]
        public async Task<IActionResult> SubmitInquiries(SubmitInquiriesrepo repo)
        {
            var body = await context.Cars.FindAsync(repo.CarsId);
            if (body == null)
            {
                return NotFound();
            }
            var inquiry = new Inquiries
            {
                Name = repo.Name,
                Email = repo.Email,
                Message = repo.Message,
                CarsId = repo.CarsId,
            };
            await context.Inquiries.AddAsync(inquiry);
            
            string emailBody = $@"
            <html>
            <body>
                <h2>Hello {repo.Name},</h2>
                <p>Thank you for inquiring about <b>{body.Model}</b>.</p>
                <p><b>Product Details:</b></p>
                <ul>
                    <li><b>Description:</b> {body.Description}</li>
                    <li><b>Price:</b> ${body.Price}</li>
                </ul>
                <img src='{body.ImageURL}' alt='Product Image' width='400' />
                <p><b>Your Message:</b> {repo.Message}</p>
                <p>We will get back to you soon!</p>
            </body>
            </html>";

            var mailrequest = new MailRequest() { ToEmail = repo.Email, Subject = "Car Inquiry", Body = emailBody };
            await _emailservice.SendEmailAsync(mailrequest);


            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Contactme(ContactMe contact)
        {
            var mailrequest = new ContactMe() { Email = contact.Email, Subject = contact.Subject, Body = contact.Body };
            await _emailservice.UserSendEmailAsync(mailrequest);
            return Ok();

        }
    }
}
