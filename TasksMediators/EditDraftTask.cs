using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task_Manager.Data;
using Task_Manager.Models;

namespace Task_Manager.TasksMediators
{
    public class EditDraftTask
    {
        public class EditCommand : IRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string  Description  { get; set; }
            public DateTime  CreatedOn  { get; set; }
            public _TaskStatus Status { get; set; }
        }

        public class Handler : IRequestHandler<EditCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.FindAsync(request.Id);
                if (task == null)
                {
                    throw new Exception("Task Not found");
                }
                task.Title = request.Title ;
                task.Description = request.Description ;
                task.CreatedOn = request.CreatedOn ;
                task.Status = _TaskStatus.Draft;

                var result = await _context.SaveChangesAsync();
                if (result>0)
                {
                    return Unit.Value;
                }
                throw new Exception(" A problem happened while editing the Draft Task");
            }

        }
    }
}