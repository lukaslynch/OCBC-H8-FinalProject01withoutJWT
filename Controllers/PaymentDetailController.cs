using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _004_LukasHansel_FinalProject.Data;
using _004_LukasHansel_FinalProject.Models;

namespace _004_LukasHansel_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentDetailController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PaymentDetailController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.paymentdetail.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(PaymentDetail data)
        {
            if(ModelState.IsValid)
            {
                await _context.paymentdetail.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItems", new { data.paymentDetailId }, data);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.paymentdetail.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, PaymentDetail item)
        {
            if (id != item.paymentDetailId){
                return BadRequest();}

            var existItem = await _context.paymentdetail.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if (existItem == null) { 
                return NotFound();}

            existItem.cardOwnerName = item.cardOwnerName;
            existItem.cardNumber = item.cardNumber;
            existItem.expirationDate = item.expirationDate;
            existItem.securityCode = item.securityCode;
            // Implement the changes on the database level
            await _context.SaveChangesAsync();

            return new JsonResult("Data Berhasil di update") { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existItem = await _context.paymentdetail.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if(existItem == null){
                return NotFound();}

            _context.paymentdetail.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok(existItem);
        }
    }
}
