using AutoMapper;
using JourneyToTheWestAPI.Entities;
using JourneyToTheWestAPI.Enums;
using JourneyToTheWestAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.DAOs
{
    public class ActorDAO
    {
        private journeytothewestContext _context;
        private readonly IMapper _mapper;

        public ActorDAO(journeytothewestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ActorDTO> getList()
        {
            var actors = (from actor in _context.Actors
                          where actor.Status == (int)Status.ACTIVE && actor.Role == (int)Constants.ACTOR
                          select
                              _mapper.Map<ActorDTO>(actor)
                                           ).ToList();
            return actors;
        }

        public ActorDTO getActor(int id)
        {
            var actor = (from ac in _context.Actors
                         where ac.IdActor == id && ac.Status == (int)Status.ACTIVE
                         select _mapper.Map<ActorDTO>(ac)).FirstOrDefault();
            return actor;
        }

        public int createActor(ActorDTO dto)
        {
            int id = (int)Constants.FAIL;


            Actor actor = _mapper.Map<Actor>(dto);
            actor.Status = (int)Status.ACTIVE;
            actor.Role = (int)Constants.ACTOR;
            actor.DateUpdated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));


            _context.Actors.Add(actor);
            if (_context.SaveChanges() == (int)Constants.SUCCESS)
            {
                id = actor.IdActor;
            }

            return id;
        }

        public bool updateActor(ActorDTO dto)
        {
            bool isUpdated = false;

            Actor actor = _context.Actors.Find(dto.IdActor);

            if (actor != null)
            {
                _context.Entry(actor).State = EntityState.Detached;
                actor = _mapper.Map<Actor>(dto);
                actor.Status = (int)Status.ACTIVE;
                actor.Role = (int)Constants.ACTOR;
                actor.DateUpdated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                _context.Entry(actor).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isUpdated = true;
                }
            }
            return isUpdated;
        }

        public bool deleteActor(int id)
        {
            bool isDeleted = false;


            Actor actor = _context.Actors.Find(id);

            if (actor != null)
            {
                actor.Status = (int)Status.DELETED;
                _context.Entry(actor).State = EntityState.Detached;
                _context.Entry(actor).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isDeleted = true;
                }
            }
            return isDeleted;
        }


        public ActorDTO login(String username, String password) {

            var actor = (from ac in _context.Actors
                         where ac.Username == username && ac.Password == password && ac.Status == (int)Status.ACTIVE
                         select _mapper.Map<ActorDTO>(ac)).FirstOrDefault();

            return actor;

        }

    }
}
