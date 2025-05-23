﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(r=>r.Key);

            builder.HasMany(u=>u.Logs)
                .WithOne(l=>l.User)
                .HasForeignKey(l=>l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
