using System;

namespace StoneCo.Treasury.TaskRunner.Api.Commands.Inputs
{
    public class TaskInput
    {
        public Guid Id { get; set; }

        public TaskInput()
        {
            this.Id = Guid.NewGuid();
        }
    }
}