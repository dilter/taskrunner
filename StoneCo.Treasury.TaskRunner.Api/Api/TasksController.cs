using System;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using StoneCo.Treasury.TaskRunner.Api.Commands.Inputs;

namespace StoneCo.Treasury.TaskRunner.Api.Api
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public void Post([FromBody] TaskInput input)
        {
            RecurringJob
                .AddOrUpdate(input.Id.ToString("D"), () => Console.WriteLine($"Task {input.Id:D}"), Cron.Minutely);
        }

        [Route("{id}")]
        [HttpDelete]        
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                RecurringJob.RemoveIfExists($"{id:D}");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
