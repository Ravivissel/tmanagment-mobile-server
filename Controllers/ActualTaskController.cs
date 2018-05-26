using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ActualTasks.Models;
using DBServices.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ActualTasksApi.Controllers
{
    [Route("api/[controller]")]
    public class ActualTasksController : Controller
    {
        private readonly DBservice _context;

        public ActualTasksController(DBservice context)
        {
            _context = context;
        }
        [HttpGet]
        public List<ActualTask> GetAll()
        {
            return _context.ActualTasks.ToList();
        }
        [HttpGet("{id}", Name = "id")]
        public List<ActualTask> GetActualTaskByID(int id)
        {
            var value = from ActualTask in _context.ActualTasks where ActualTask.Id == id select ActualTask;

            return value.ToList();
        }

        [HttpPost()]
        public ActionResult InsetActualTask([FromBody]ActualTask actualTask)
        {
            try
            {
                _context.Entry(actualTask).State = actualTask.Id == 0? EntityState.Added : EntityState.Modified;
                _context.SaveChanges();
                return Ok("Task added");
            }
            catch (Exception e)
            {
                 return StatusCode(500, "exception: " + e);

            }
        }


    }
}