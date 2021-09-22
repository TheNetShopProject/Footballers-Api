using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Application.Exceptions;
using Application.Interfaces;
using Application.ModelsDTO;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Services
{
    public class FotballerService : IFootballerService
    {
        private readonly IFootballerRepository _service;
        private readonly IMapper _mapper;
        private readonly ILogger<FotballerService> _logger;

        public FotballerService(IFootballerRepository service, IMapper mapper, ILogger<FotballerService> logger)
        {
            this._service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<FotballerDTO> getAllFotballers()
        {
            var fotballers = _service.GetAll();
            var fotballersDto = _mapper.Map<IEnumerable<FotballerDTO>>(fotballers);
            _logger.LogError(LoggerUtils.DeserializeObjectToString(fotballersDto));
            return fotballersDto;
        }

        public FotballerDTO GetFotballerByID(int id)
        {
           var fotballer = _service.GetByID(id);
           if (fotballer is null)
               throw new NotFoundExceptions("Fotballer not found " + id);
           var footballerDto = _mapper.Map<FotballerDTO>(fotballer);
           return footballerDto;
        }

        public FotballerDTO AddFotballer(CreateFotballerDTO fotballer)
        {
            var fotballerToAdd = _mapper.Map<Fotballer>(fotballer);
            _service.Add(fotballerToAdd);
            return _mapper.Map<FotballerDTO>(fotballerToAdd);
        }

        public void DeleteFotballer(int ID)
        {
            _logger.LogWarning($"Fotballer with ID: {ID} will bee deleted" );
            var fotballer = _service.GetByID(ID);
            if (fotballer is null)
                throw new NotFoundExceptions("Fotballer not found " + ID);
            _logger.LogInformation(JsonConvert.SerializeObject(fotballer));
            _service.Delete(fotballer);
        }

        public IEnumerable<FotballerDTO> GetFotballersByClubId(int id)
        {
            var fotballers = _service.GetAll();
            var fotballersDTO = _mapper.Map<IEnumerable<FotballerDTO>>(fotballers.Where(x=> x.Club.ID == id));
            return fotballersDTO;
        }
    }
}