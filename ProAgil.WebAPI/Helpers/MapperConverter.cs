using AutoMapper;
using ProAgil.Domen.DTOs;
using ProAgil.Domen.Identity;
using ProAgil.Domen.ModelBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebAPI.Helpers
{
    public class MapperConverter : Profile
    {
        public MapperConverter()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();

            CreateMap<Palestrante, PalestranteDTO>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDTO>().ReverseMap();
            CreateMap<Lote, LoteDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
        }
    }
}
