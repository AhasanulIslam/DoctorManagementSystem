using System;
using System.Linq;
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
   public class DoctorController : ControllerBase
    {
         private readonly DataContext _context;
        public DoctorController(DataContext context)
        {
            _context = context;
            
        }

       [AllowAnonymous]
        [HttpGet("dc")]
        public async Task<IActionResult> GetDoctors(int id)
        {
              var doctors = await _context.Doctors.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Doctors").ToListAsync();

            return Ok(doctors);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostDoctor([FromBody]DoctorDtos doctor)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var doctors = new Doctor
            {
                DoctorName = doctor.DoctorName,
                Qualification = doctor.Qualification,
                JobPlace = doctor.JobPlace,
                Designation = doctor.Designation,
                Field = doctor.Field

               
            };
            await _context.Doctors.AddAsync(doctors);//this doesnt change in our database
            await _context.SaveChangesAsync();
  
            return Ok(doctors);
        }


        [AllowAnonymous]
        [HttpGet("{test}")]
        public IActionResult Test()
        {
            return Ok("su");
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