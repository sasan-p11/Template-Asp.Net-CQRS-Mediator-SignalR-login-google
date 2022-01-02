using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;
public class DataSeeder
{
    private readonly DataContext _dataContext;
    private readonly UserManager<AppUser> userManager;

    public DataSeeder(DataContext dataContext, UserManager<AppUser> userManager)
    {
        _dataContext = dataContext;
        this.userManager = userManager;
    }

    public void Seed()
    {
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>
                {
                    new AppUser{Bio = "developer" ,DisplayName = "sasan" , UserName="Sasan" , Email="sasan@test.com"},
                    new AppUser{Bio = "architecture" ,DisplayName = "babak" , UserName="Babak" , Email="babak@test.com"},
                    new AppUser{Bio= "docter" ,DisplayName = "sina" , UserName="Sina" , Email="sina@test.com"}
                };

            users.ForEach(async x => await userManager.CreateAsync(x, "Pa$$w0rd"));
            _dataContext.Users.AddRange(users);
            _dataContext.SaveChanges();
        }



        if (!_dataContext.activities.Any())
        {
            var activities = new List<Activity>()
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                    }
                };

            _dataContext.activities.AddRange(activities);
            _dataContext.SaveChanges();
        }
    }
}
