using AutoMapper;
using Domain;

namespace Application.Core;
public class MapingProfile : Profile
{
    public MapingProfile()
    {
        CreateMap<Activity , Activity>();
    }
}
