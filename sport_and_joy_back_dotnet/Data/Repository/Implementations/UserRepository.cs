﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sport_and_joy_back_dotnet.Data.Repository.Interfaces;
using sport_and_joy_back_dotnet.Entities;
using sport_and_joy_back_dotnet.Models;

namespace sport_and_joy_back_dotnet.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private SportContext _context;
        private readonly IMapper _mapper;
        public UserRepository(SportContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //////// GET ////////
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetListUser()
        {
            return _context.Users.ToList();
        }


        //////// POST ////////

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }


        //////// PUT ////////

        public void UpdateUserData(User user)
        {
            var userItem = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userItem != null)
            {
                userItem.Image = user.Image;
                userItem.FirstName = user.FirstName;
                userItem.Email = user.Email;
                userItem.LastName = user.LastName;
                if (user.Password != null)
                {
                    userItem.Password = user.Password;
                }
                userItem.Role = user.Role;

                _context.SaveChanges();
            }
        }



        //////// DELETE ////////

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }



        /////// REPORTS //////

        public async Task<List<ReportUserWithReservationsDTO>> PlayersWithReservations()
        {
            var users = await _context.Users
                .Include(u => u.Reservations)
                .Where(u => u.Role == Erole.PLAYER && u.Reservations.Any())
                .Select(u => new ReportUserWithReservationsDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ReservationsCount = u.Reservations.Count()
                })
                .ToListAsync();

            return users;
        }

        public async Task<List<ReportUserWithFieldsDTO>> OwnersWithFields()
        {
            var users = await _context.Users
                .Include(u => u.Fields)
                .Where(u => u.Role == Erole.OWNER && u.Fields.Any())
                .Select(u => new ReportUserWithFieldsDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    FieldsCount = u.Fields.Count()
                })
                .ToListAsync();

            return users;

        }


    }
}