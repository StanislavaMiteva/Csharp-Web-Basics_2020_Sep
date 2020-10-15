using System;

namespace SUS.MVCFramework
{
    public interface IServiceCollection
    {
        //.Add<IUsersService, UsersService>
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}
