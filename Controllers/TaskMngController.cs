using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_Manager.Models;
using Task_Manager.TasksMediators;

namespace Task_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskMngController
    {
        private readonly IMediator _mediator;
        public TaskMngController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(AddNewTask.CreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, EditDraftTask.EditCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<_Task>>> ViewAll()
        {
            return await _mediator.Send(new ViewTasks.QueryTasks());
        }

        [HttpGet("ViewSummary")]
        public async Task<ActionResult<int>> ViewSum()
        {
            return await _mediator.Send(new ViewTasksSummary.QueryTasks());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new DeleteDraftTask.DeleteCommand{Id = id});
        }   

        [HttpGet("{title}")]
        public async Task<ActionResult<_Task>> SearchByTitle(string title)
        {
            return await _mediator.Send(new SearchTasksByTitle.QueryTask{Title = title});
        }

        [HttpGet("searchBystatus/{status}")]
        public async Task<ActionResult<_Task>> SearchByStatus(_TaskStatus status)
        {
            return await _mediator.Send(new SearchTasksByStatus.QueryTask{Status = status});
        }

    }
}