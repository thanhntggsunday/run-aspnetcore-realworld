//using AspnetRun.Application.Models;
//using AspnetRun.Core.Entities;
//using AutoMapper;
//using System;

//namespace AspnetRun.Application.Mapper
//{
//    // The best implementation of AutoMapper for class libraries - https://stackoverflow.com/questions/26458731/how-to-configure-auto-mapper-in-class-library-project
//    public class ObjectMapper
//    {
//        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                // This line ensures that internal properties are also mapped over.
//                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//                cfg.AddProfile<AspnetRunDtoMapper>();
//            });
//            var mapper = config.CreateMapper();
//            return mapper;
//        });
//        public static IMapper Mapper => Lazy.Value;
        
//        public class AspnetRunDtoMapper : Profile
//        {
//            public AspnetRunDtoMapper()
//            {
//                CreateMap<Product, ProductDto>()
//                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

//                CreateMap<Category, CategoryDto>().ReverseMap();
//                CreateMap<Wishlist, WishlistDto>().ReverseMap();
//                CreateMap<Compare, CompareDto>().ReverseMap();
//                CreateMap<Order, OrderDto>().ReverseMap();
//                CreateMap<Cart, CartDto>().ReverseMap();
//                CreateMap<CartItem, CartItemDto>().ReverseMap();
//            }
//        }
//    }
//}
