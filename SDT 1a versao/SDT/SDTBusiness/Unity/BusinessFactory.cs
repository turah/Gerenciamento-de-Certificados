using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace SDTBusiness.Unity
{
    public class BusinessFactory
    {
        //private readonly static BusinessFactory _instance = new BusinessFactory();

        //public static BusinessFactory GetInstance()
        //{
        //    return _instance;
        //}

        //private BusinessFactory()
        //{
        //    ListBusinessFacadeTypes().ForEach(ContainerManager.Instance.RegisterType);
        //}

        //private IEnumerable<Type> ListBusinessFacadeTypes()
        //{
        //    return Assembly.GetAssembly(GetType()).GetTypes().Where(type =>
        //        type.IsSubclassOf(typeof(BaseUnity)) && !type.IsAbstract &&
        //        !ContainerManager.Instance.IsRegistered(type));
        //}

        //public T Get<T>() where T : BaseUnity
        //{
        //    return ContainerManager.Instance.Get<T>();
        //}

        //public object Get(Type t)
        //{
        //    return ContainerManager.Instance.Get(t);
        //}
    }
}
