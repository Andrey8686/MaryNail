using AutoMapper;

namespace Site.Code.Utils
{
    public class Binder
    {
        public static void Bind<TSource, TDest>(TSource source, ref TDest dest)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDest>(); });
            var mapper = config.CreateMapper();
            dest = mapper.Map(source, dest);
        }

        public static TDest Bind<TSource, TDest>(TSource source) where TDest : new()
        {
            var dest = new TDest();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDest>(); });
            var mapper = config.CreateMapper();
            dest = mapper.Map(source, dest);
            return dest;
        }
    }
}