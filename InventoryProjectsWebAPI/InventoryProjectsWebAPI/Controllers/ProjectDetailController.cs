﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryProjectsWebAPI.Models;

namespace InventoryProjectsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailController : ControllerBase
    {
        private readonly ProjectDetailContext _context;

        public ProjectDetailController(ProjectDetailContext context)
        {
            _context = context;
        }

        // GET: api/ProjectDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetail>>> GetProjectDetails()
        {
            return await _context.ProjectDetails.ToListAsync();
        }

        // GET: api/ProjectDetail/5
      //  [HttpGet("{id}")]
      //  public async Task<ActionResult<ProjectDetail>> GetProjectDetail(int id)
       // {
       //    var projectDetail = await _context.ProjectDetails.FindAsync(id);

         //   if (projectDetail == null)
        //    {
          //      return NotFound();
           // }

           // return projectDetail;
       // }

        // PUT: api/ProjectDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDetail(int id, ProjectDetail projectDetail)
        {
            if (id != projectDetail.PMId)
            {
                return BadRequest();
            }

            _context.Entry(projectDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectDetail
        [HttpPost]
        public async Task<ActionResult<ProjectDetail>> PostProjectDetail(ProjectDetail projectDetail)
        {
            _context.ProjectDetails.Add(projectDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectDetail", new { id = projectDetail.PMId }, projectDetail);
        }

        // DELETE: api/ProjectDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDetail>> DeleteProjectDetail(int id)
        {
            var projectDetail = await _context.ProjectDetails.FindAsync(id);
            if (projectDetail == null)
            {
                return NotFound();
            }

            _context.ProjectDetails.Remove(projectDetail);
            await _context.SaveChangesAsync();

            return projectDetail;
        }

        private bool ProjectDetailExists(int id)
        {
            return _context.ProjectDetails.Any(e => e.PMId == id);
        }
    }
}
