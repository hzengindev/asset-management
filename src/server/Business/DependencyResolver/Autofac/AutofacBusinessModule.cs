using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EFProjectDal>().As<IProjectDal>();
            builder.RegisterType<ProjectUserManager>().As<IProjectUserService>();
            builder.RegisterType<EFProjectUserDal>().As<IProjectUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
