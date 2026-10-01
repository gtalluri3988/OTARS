using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.Utilities.IoC {

    public interface IObjectCreator {

        T Create<T>();

    }// interface

}// namespace
