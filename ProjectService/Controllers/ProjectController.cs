﻿using Microsoft.AspNetCore.Mvc;
using ProjectService.Models;
using ProjectService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;

        }
        // GET: api/ProjectController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.GetAllAsyc();
            return Ok(projects);
        }

        // GET api/ProjectController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/ProjectController
        [HttpPost]
        public async Task<IActionResult> Post(Project project)
        {
            await _projectService.CreateAsync(project);
            return Ok("Created successfully");
        }

        // PUT api/ProjectController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Project newproject)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
                return NotFound();

            await _projectService.UpdateAsync(id, newproject);
            return Ok("Updated successfully");
        }

        // DELETE api/ProjectController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
                return NotFound();
            await _projectService.DeleteAysnc(id);
            return Ok("deleted Successfully");
        }
    }
}
