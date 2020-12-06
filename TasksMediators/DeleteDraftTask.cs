using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Task_Manager.Data;

namespace Task_Manager.TasksMediators
{
    public class DeleteDraftTask
    {
        public class DeleteCommand : IRequest
        {
            public int Id { get; set; }   
        }

        public class Handler : IRequestHandler<DeleteCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.FindAsync(request.Id);
                if (task == null)
                {
                    throw new Exception("Could not find the specified task");
                }
                _context.Remove(task);
                var result = await _context.SaveChangesAsync();
                if (result>0)
                {
                    return Unit.Value;
                }
                throw new Exception("A problem happened while Deleting the draft task");
            }

        }
    }
}