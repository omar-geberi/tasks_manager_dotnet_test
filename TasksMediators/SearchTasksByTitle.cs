using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Data;
using Task_Manager.Models;

namespace Task_Manager.TasksMediators
{
    public class SearchTasksByTitle
    {
        public class QueryTask : IRequest<_Task>
        {
            public string Title { get; set; }
        }

        public class Handler : IRequestHandler<QueryTask, _Task>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<_Task> Handle(QueryTask request, CancellationToken cancellationToken)
            {
        
                var book =  await _context.Tasks.FirstOrDefaultAsync(u => u.Title == request.Title);
                return book;
            }

        }
    }
}