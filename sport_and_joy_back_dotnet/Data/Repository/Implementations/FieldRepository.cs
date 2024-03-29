﻿using AutoMapper;
using sport_and_joy_back_dotnet.Data.Repository.Interfaces;
using sport_and_joy_back_dotnet.Entities;
using sport_and_joy_back_dotnet.Models;

namespace sport_and_joy_back_dotnet.Data.Repository.Implementations
{
    public class FieldRepository : IFieldRepository
    {
        private readonly SportContext _context;
        private readonly IMapper _mapper;

        public FieldRepository(SportContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }

        //////// GET ////////
        public List<Field> GetAllFie()
        {
            return _context.Fields.ToList();
        }

        public List<Field> GetAllFieByUser(int userId)
        {
            return _context.Fields.Where(f => f.UserId == userId).ToList();
        }

        public Field GetFieById(int id)
        {
            return _context.Fields.FirstOrDefault(f => f.Id == id);
        }



        //////// POST ////////

        // este post se comenta porque quedamos que un owner no puede crear una cancha.

        //public void CreateFie(FieldForCreationDTO dto, int userId)
        //{
        //    Field field = new Field()
        //    {
        //        UserId = userId,
        //        Name = dto.Name,
        //        Image = dto.Image,
        //        Location = dto.Location,
        //        Description = dto.Description,
        //        LockerRoom = dto.LockerRoom,
        //        Bar = dto.Bar,
        //        Sport = dto.Sport,
        //    };
        //    _context.Fields.Add(field);
        //    _context.SaveChanges();
        //}

        public Field CreateFieAdmin(FieldForCreationDTO dto, int IdUser)
        {
            
                Field field = new Field()
                {
                    UserId = IdUser,
                    Name = dto.Name,
                    Image = dto.Image,
                    Location = dto.Location,
                    Description = dto.Description,
                    LockerRoom = dto.LockerRoom,
                    Bar = dto.Bar,
                    Sport = dto.Sport,
                    Price = dto.Price,
                };

                _context.Fields.Add(field);
                _context.SaveChanges();

                return field;
            
        }




        //////// PUT ////////
        public void UpdateFie(FieldDTO dto, int userId, int id)
        {
            var field = _context.Fields.FirstOrDefault(f => f.UserId == userId && f.Id == id);

            if (field != null)
            {
                field.UserId = userId;
                field.Id = id;
                field.Name = dto.Name;
                field.Image = dto.Image;
                field.Location = dto.Location;
                field.Description = dto.Description;
                field.LockerRoom = dto.LockerRoom;
                field.Bar = dto.Bar;
                field.Sport = dto.Sport;
                field.Price = dto.Price;

                _context.SaveChanges();
            }
        }

        public void UpdateFieAdmin(FieldDTO dto, int id)
        {
            var field = _context.Fields.FirstOrDefault(f => f.Id == id);

            if (field != null)
            {
                field.Id = id;
                field.Name = dto.Name;
                field.Image = dto.Image;
                field.Location = dto.Location;
                field.Description = dto.Description;
                field.LockerRoom = dto.LockerRoom;
                field.Bar = dto.Bar;
                field.Sport = dto.Sport;
                field.Price = dto.Price;


                _context.SaveChanges();
            }
        }



        //////// DELETE ////////

        // este delete se comenta porque quedamos que un owner no puede eliminar una cancha.

        //public void DeleteFie(int id, int userId)
        //{
        //    _context.Fields.Remove(_context.Fields.Single(f => f.Id == id && f.UserId == userId));
        //    _context.SaveChanges();
        //}

        public void DeleteFieAdmin(int id)
        {
            _context.Fields.Remove(_context.Fields.Single(f => f.Id == id));
            _context.SaveChanges();
        }

    }
}