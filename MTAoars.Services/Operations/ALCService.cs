using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Services.Shared;
using MTAoars.Services.Interfaces;
using MTAoars.Validators;
using MTAoars.Repositories.Interfaces;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.Utilities.Extensions;
using MTAoars.Utilities.Constants;
using System.Transactions;
using MTAoars.ViewModels.Notifications;
using MTAoars.Mappers.Operations;
using MTAoars.ViewModels.Operations;
using System.Data;

namespace MTAoars.Services.Operations {
    public class ALCService : BaseService, IALCService {

        IALCRepository alcRepository;
        public ALCService(IValidationProvider validationProvider, IALCRepository alcRepository)
            : base(validationProvider) {
                this.alcRepository = alcRepository;
                ALCHeader h;
        }

        public void Save(ALCHeaderViewModel input) {
            var header = Mapper.Map<ALCHeaderViewModel, ALCHeader>(input);
            alcRepository.SaveHeader(header);
        }
        
    }// class
}// namespace
