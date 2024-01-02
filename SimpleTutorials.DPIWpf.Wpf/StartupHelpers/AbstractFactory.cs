using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTutorials.DPIWpf.Wpf.StartupHelpers
{
    internal class AbstractFactory<T> : IAbstractFactory<T>
    {
        private readonly Func<T> _Factory;
        public AbstractFactory(Func<T> factory)
        {
            _Factory = factory;
        }

        public T Create() => _Factory();
    }
}
