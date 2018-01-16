using AutoMapper;
using Envoice.MongoIdentityServer.Entities;
using Models = IdentityServer4.Models;

namespace Envoice.MongoIdentityServer.Mappers
{
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.ApiResource ToModel(this ApiResource resource)
        {
            return resource == null ? null : Mapper.Map<Models.ApiResource>(resource);
        }

        public static ApiResource ToEntity(this Models.ApiResource resource)
        {
            return resource == null ? null : Mapper.Map<ApiResource>(resource);
        }
    }
}
