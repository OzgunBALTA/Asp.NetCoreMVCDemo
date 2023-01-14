using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.ExportHelper.Abstract;
using Core.Utilities.Helpers.ExportHelper.Concrete;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>();

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<NewsLetterManager>().As<INewsLetterService>();
            builder.RegisterType<EfNewsLetterDal>().As<INewsLetterDal>();

            builder.RegisterType<NotificationManager>().As<INotificationService>();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<ExporExcelHelper>().As<IExportHelper>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
