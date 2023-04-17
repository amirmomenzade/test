using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Activity, Activity>();
        }
    }
}
