﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SubmissionAPI.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
