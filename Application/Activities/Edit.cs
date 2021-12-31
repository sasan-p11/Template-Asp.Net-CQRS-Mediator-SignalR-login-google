using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;
public class Edit
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await dataContext.activities.FindAsync(request.Activity.Id);

            mapper.Map(request.Activity, activity);

            await dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
