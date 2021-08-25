﻿using Microsoft.Extensions.Configuration;
using RG_Potter_API.DB;
using RG_Potter_API.Models;
using System;

namespace RG_Potter_API
{
    internal class DbInitializer
    {
        private readonly bool _reset;

        public DbInitializer(IConfiguration configuration)
        {
            _reset = bool.Parse(configuration["ResetDB"] ?? "true");
        }

        internal void Initialize(PotterContext context)
        {
            if (_reset) context.Database.EnsureDeleted();

            if (!context.Database.EnsureCreated()) return;


            var houses = new[]
            {
                new House
                {
                    Id = "gryffindor",
                    Name = "Grifinória"
                },
                new House
                {
                    Id = "hufflepuff",
                    Name = "Lufa-Lufa"
                },
                new House
                {
                    Id = "slytherin",
                    Name = "Sonserina"
                },
                new House
                {
                    Id = "ravenclaw",
                    Name = "Corvinal"
                }
            };

            foreach (var house in houses) context.Houses.Add(house);


            var users = new User[0];

            foreach (var user in users) context.Users.Add(user);


            context.SaveChanges();
        }
    }
}