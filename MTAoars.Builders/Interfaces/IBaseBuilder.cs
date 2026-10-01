using MTAoars.ViewModels.Operations;
using System.Collections.Generic;
using MTAoars.Services.Shared;

namespace MTAoars.Builders.Interfaces {
    public interface IBaseBuilder {

        BuilderContext CurrentContext { get; set; }

    }// interface
}// namespace
