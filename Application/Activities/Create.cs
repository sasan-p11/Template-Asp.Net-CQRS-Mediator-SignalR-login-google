using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities;
public class Create
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x=>x.Activity).SetValidator(new ActivityValidator());
        }
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
            dataContext.activities.Add(request.Activity);
            await dataContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
