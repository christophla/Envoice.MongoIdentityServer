using AutoMapper;
using Envoice.MongoIdentityServer.Entities;

namespace Envoice.MongoIdentityServer.Mappers
{
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static IdentityServer4.Models.IdentityResource ToModel(this IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<IdentityServer4.Models.IdentityResource>(resource);
        }

        public static IdentityResource ToEntity(this IdentityServer4.Models.IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<IdentityResource>(resource);
        }
    }
}
