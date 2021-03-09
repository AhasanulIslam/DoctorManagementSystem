using System.Threading.Tasks;
using DoctorManagement.Data;
using DoctorManagement.Dtos;
using DoctorManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagement.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
   public class PatientController : ControllerBase
    {
         private readonly DataContext _context;
        public PatientController(DataContext context)
        {
            _context = context;
            
        }
     [AllowAnonymous]
        [HttpGet("pc")]
        public async Task<IActionResult> GetPatients(int id)
        {
              var patients = await _context.Patients.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Patients").ToListAsync();

            return Ok(patients);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostDoctor([FromBody]PatientDtos patient)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var patients = new Patient
            {
                PatientName = patient.PatientName,
                Age = patient.Age,
                Gender = patient.Gender

               
            };
            await _context.Patients.AddAsync(patients);//this doesnt change in our database
            await _context.SaveChangesAsync();
  
            return Ok(patients);
        }


       
        //  [AllowAnonymous]
        // [HttpGet("{name}/{id}")]
        // public IActionResult DeleteUser(int id)
        // {
        //     var Id = Convert.ToInt16(id);
        //     var user = _context.Customars.FirstOrDefault(x => x.CustomarId == Id);
        //     _context.Customars.Remove(user);
        //     // _context.Staffs.RemoveRange
        //     //     (_context.Staffs.Where(x => x.StaffId == Id));
        //     _context.SaveChanges();

        //     return Ok(user);

        // }
    

    }
}