using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities;
public class Edit
{
    public class Command : IRequest<Result<Unit>>
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

    public class Handler : IRequestHandler<Command , Result<Unit>>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await dataContext.activities.FindAsync(request.Activity.Id);
            
            if(activity == null) return null;

            mapper.Map(request.Activity, activity);

            var result = await dataContext.SaveChangesAsync() > 0;

            if(!result) return Result<Unit>.Failure("Sorry , Failed To Update Activity");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
