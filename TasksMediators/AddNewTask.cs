using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task_Manager.Data;
using Task_Manager.Models;

namespace Task_Manager.TasksMediators
{
    public class AddNewTask
    {
        public class CreateCommand : IRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string  Description  { get; set; }
            public DateTime  CreatedOn  { get; set; }
            public _TaskStatus Status { get; set; }

        }

        
            public class Handler : IRequestHandler<CreateCommand>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                var task = new _Task {
                    Id  = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    CreatedOn = DateTime.Now,
                    Status = _TaskStatus.Draft
                };
                _context.Tasks.Add(task);
                var result = await _context.SaveChangesAsync() ;
                if(result>0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("An error happened during the Creation of the Task");
                }
            }


        }
    }
}