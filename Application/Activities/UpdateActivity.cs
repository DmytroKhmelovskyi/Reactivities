using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Activities
{
    public class UpdateActivity
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            /// <inheritdoc />
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity =
                     await _context.Activities.SingleOrDefaultAsync(a => a.Id == request.Activity.Id, cancellationToken);

                _mapper.Map(request.Activity, activity);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
