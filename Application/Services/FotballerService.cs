using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Application.Interfaces;
using Application.ModelsDTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class FotballerService : IFootballerService
    {
        private readonly IFootballerRepository _service;
        private readonly IMapper _mapper;

        public FotballerService(IFootballerRepository service, IMapper mapper)
        {
            this._service = service;
            _mapper = mapper;
        }

        public IEnumerable<FotballerDTO> getAllFotballers()
        {
            var fotballers = _service.GetAll();
            var fotballersDto = _mapper.Map<IEnumerable<FotballerDTO>>(fotballers);
            return fotballersDto;
        }

        public FotballerDTO GetFotballerByID(int id)
        {
           var fotballer = _service.GetByID(id);
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
            var fotballer = _service.GetByID(ID);
            if (fotballer is null)
                throw new Exception("Nie znaleziono Piłkarza o ID " + ID);
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