using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.Utilities.Interfaces {
    public interface IScopeDataProvider {

        void Register<T>(string key, T item) where T:class;

        T Get<T>(string key) where T:class;

        bool HasRegistered(string key);

        void Remove(string key);

    }// interface
}// namespace
