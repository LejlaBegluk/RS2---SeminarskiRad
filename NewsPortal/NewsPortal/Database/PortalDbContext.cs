﻿using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;
using System;

namespace NewsPortal.WebAPI.Database
{
    public class PortalDbContext :DbContext
    {

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAnswer> PollAnswer { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaidArticle> PaidArticles { get; set; }
        public DbSet<ArticlePayment> ArticlePayments { get; set; }
        public DbSet<PaidArticleStatus> PaidArticleStatuses { get; set; }


        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }
    }
}
