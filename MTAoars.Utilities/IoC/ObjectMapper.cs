using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.Utilities.IoC {

    public class ObjectMapper : IObjectMapper {

        TDestination IObjectMapper.Map<TSource, TDestination>(TSource source) {
            throw new NotImplementedException();
        }

    }// class

}// namespace
