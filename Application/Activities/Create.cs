using Application.Core;
using Application.Interface;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;
public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Activity Activity { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext dataContext;
        private readonly IUserAccessor userAccessor;

        public Handler(DataContext dataContext, IUserAccessor userAccessor)
        {
            this.dataContext = dataContext;
            this.userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await dataContext.Users.
                        FirstOrDefaultAsync(x=>x.UserName == userAccessor.GetUser());

            var attendee = new AppUserActivity
            {
                AppUser = user , 
                Activity =request.Activity,
                IsHost = true
            };

            request.Activity.AppUsers.Add(attendee);

            dataContext.activities.Add(request.Activity);
            var result = await dataContext.SaveChangesAsync() > 0;

            if(!result) return Result<Unit>.Failure("Sorry,Fialed to Create Activity");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
