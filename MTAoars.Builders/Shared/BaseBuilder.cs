using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Services.Shared;
using MTAoars.Builders.Interfaces;

namespace MTAoars.Builders.Shared {
    public class BaseBuilder : IBaseBuilder
    {
        protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        BuilderContext context;
        public BaseBuilder()
        {
            context = new BuilderContext();
        }

        public BuilderContext CurrentContext
        {
            get { return context; }
            set { context = value; }
        }

    }// class
}// namespace
