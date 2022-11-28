using HRMM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMM.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDataModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserDataModel> UsersF { get; set; }

        public DbSet<RoomDataModel> Rooms { get; set; }

        public DbSet<ReservationDataModel> Reservations { get; set; }

        public DbSet<ClientDataModel> Clients { get; set; }
    }
}
