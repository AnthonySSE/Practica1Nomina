using AutoMapper;
using Practica1Nomina.DTOs;
using Practica1Nomina.Models;

namespace Practica1Nomina.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Empleado,Empleado>().ReverseMap();
            
        }
    }
}
