using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.Configs
{
    public class MapperProfile:Profile
    {
        void AnimalProfile() 
        {
            CreateMap<AnimalRequest, Animal>()
                .ForMember(dest=>dest.AnimalSex,opt=>opt.MapFrom(src => Enum.Parse<Animal.Sex>(src.AnimalSex)))
                .ForMember(dest=>dest.AnimalKind,opt=>opt.MapFrom(src => Enum.Parse<Animal.Kind>(src.AnimalKind)));
            CreateMap<Animal, AnimalResponse>()
                .ForMember(dest => dest.AnimalKind, opt => opt.MapFrom(src => src.AnimalKind.ToString()))
                .ForMember(dest => dest.AnimalSex, opt => opt.MapFrom(src => src.AnimalSex.ToString()));
        }
        void AppointmentProfile() 
        {
            CreateMap<AppointmentRequest, Appointment>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTime.ParseExact(src.StartTime!, "dd-MM-yyyy-HH-mm-ss", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.ParseExact(src.EndTime!, "dd-MM-yyyy-HH-mm-ss", CultureInfo.InvariantCulture)));
            CreateMap<Appointment, AppointmentResponse>();
        }
        void CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
        void DoctorProfile() 
        {
            CreateMap<Doctor, DoctorResponse>();
        }
        void ProcedureProfile() 
        {
            CreateMap<Procedure, ProcedureResponse>()
                .ForMember(dest => dest.ProcedureName, opt => opt.MapFrom(src => src.ProcedureName.ToString()));
        }
        public MapperProfile()
        {
            AnimalProfile();
            AppointmentProfile();
            CustomerProfile();
            ProcedureProfile();
            DoctorProfile();
        }
    }
}
