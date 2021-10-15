using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLiderEntrega
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        static AutoMapperConfiguration()
        {
            if (_mapperConfiguration is null)
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ServicioPrueba.Saldo, Models.Saldo>().ReverseMap();
                });
        }

        public static IMapper GetMapper()
        {
            return _mapperConfiguration.CreateMapper();
        }
    }
}
