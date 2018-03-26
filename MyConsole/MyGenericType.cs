using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public interface  IMyGenericTypeInterface<T,U> where T : class where U:T
    {
        U Change(T s);
    }
    public class MyGenericTypeInterface<T, U> : IMyGenericTypeInterface<T, U> where T : class where U : T
    {
        public U Change(T s)
        {
            return (U)s;
        }
    }
}
