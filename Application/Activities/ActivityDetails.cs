using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ActivityDetails
    {
        public class Query : IRequest<Activity>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            /// <inheritdoc />
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);
            }
        }
    }
}
