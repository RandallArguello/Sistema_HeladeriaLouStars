using AutoMapper;
using HeladeriaLouStars_API.Dto;
using HeladeriaLouStars_API.Models;

namespace HeladeriaLouStars_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoCreateDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoUpdateDto>().ReverseMap();

            CreateMap<Nomina, NominaDto>().ReverseMap();
            CreateMap<Nomina, NominaCreateDto>().ReverseMap();
            CreateMap<Nomina, NominaUpdateDto>().ReverseMap();

            CreateMap<Contrato, ContratoDto>().ReverseMap();
            CreateMap<Contrato, ContratoCreateDto>().ReverseMap();
            CreateMap<Contrato, ContratoUpdateDto>().ReverseMap();

            CreateMap<Turno, TurnoDto>().ReverseMap();
            CreateMap<Turno, TurnoCreateDto>().ReverseMap();
            CreateMap<Turno, TurnoUpdateDto>().ReverseMap();

            CreateMap<Administrador, AdministradorDto>().ReverseMap();
            CreateMap<Administrador, AdminCreateDto>().ReverseMap();
            CreateMap<Administrador, AdminUpdateDto>().ReverseMap();
        }
    }
}
