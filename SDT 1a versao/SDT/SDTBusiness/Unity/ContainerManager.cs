using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace SDTBusiness.Unity
{
    internal class ContainerManager : IDisposable
    {
        private readonly IUnityContainer _container;

        //internal readonly static ContainerManager Instance = new ContainerManager();

        //private ContainerManager()
        //{
        //    _container = new UnityContainer();
        //    _container.AddNewExtension<Interception>();
        //}

        //internal T Get<T>()
        //{
        //    return (T)Get(typeof(T));
        //}

        //internal object Get(Type t)
        //{
        //    if (!_container.IsRegistered(t))
        //    {
        //        RegisterType(t);
        //    }
        //    return _container.Resolve(t);
        //}

        //internal bool IsRegistered(Type type)
        //{
        //    return _container.IsRegistered(type);
        //}

        //internal void RegisterType(Type type)
        //{
        //    _container.RegisterType(type,
        //        new TransientLifetimeManager(),
        //        new Interceptor<TransparentProxyInterceptor>(),
        //        new InterceptionBehavior<BusinessMethodManagementBehavior>());
        //}

        public void Dispose() 
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}
