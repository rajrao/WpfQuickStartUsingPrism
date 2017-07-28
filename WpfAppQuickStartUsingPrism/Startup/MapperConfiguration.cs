using AutoMapper;

namespace WpfAppQuickStartUsingPrism.Startup
{
	public class MapperConfiguration
	{
		public static IMapper Configure()
		{
			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				//cfg.CreateMap<Type1, Type2>();
			});

			IMapper mapper = new Mapper(config);
			return mapper;
		}
	}
}