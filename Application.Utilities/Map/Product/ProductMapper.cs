using Application.Entities.Product.Create;
using Application.Entities.Product.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities.Map.Product
{
    public class ProductMapper
    {
        private static ProductMapper instance = null;
        private IMapper _mapper;
        private static readonly object mapLocker = new object();

        ProductMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCreateInputModel, Entities.Product.DAL.Product>();
                cfg.CreateMap<ProductUpdateInputModel, Entities.Product.DAL.Product>();
            });

            this._mapper = config.CreateMapper();
        }

        public static ProductMapper Instance
        {
            get
            {
                lock (mapLocker)
                {
                    if (instance == null)
                    {
                        instance = new ProductMapper();
                    }
                    return instance;
                }
            }
        }

        public static IMapper Mapper {
            get
            {
                return Instance._mapper;
            }
        }
    }
}
