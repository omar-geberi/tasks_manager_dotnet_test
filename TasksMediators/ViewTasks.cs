using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Data;
using Task_Manager.Models;

namespace Task_Manager.TasksMediators
{
    public class ViewTasks
    {
        public class QueryTasks : IRequest<List<_Task>>
        {

        }
        public class Handler : IRequestHandler<QueryTasks, List<_Task>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<_Task>> Handle(QueryTasks request, CancellationToken cancellationToken)
            {
                var books = await  _context.Tasks.ToListAsync();
                return books;
            }

        }
    }
}