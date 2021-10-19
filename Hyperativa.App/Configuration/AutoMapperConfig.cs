using AutoMapper;
using Hyperativa.App.ViewModels;
using Hyperativa.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Card, CardViewModel>().ReverseMap();
        }
    }
}
