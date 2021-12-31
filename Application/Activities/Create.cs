using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;
public class Create
{
    public class Command : IRequest
    {
        public Activity activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext dataContext;

        public Handler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            dataContext.activities.Add(request.activity);
            await dataContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
