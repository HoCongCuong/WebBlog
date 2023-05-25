using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebBlog.Areas.Identity.Data;

namespace WebBlog.Models
{
    public partial class enviwebContext : IdentityDbContext<ApplicationUser>
    {
        public enviwebContext()
        {
        }

        public enviwebContext(DbContextOptions<enviwebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<ArticleMetum> ArticleMeta { get; set; } = null!;
        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; } = null!;
        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; } = null!;
        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; } = null!;
        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; } = null!;
        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; } = null!;
        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentDetail> CommentDetails { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=enviweb;uid=root;pwd=123456Av@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasIndex(e => e.AuthorId, "fk_author");

                entity.HasIndex(e => e.CategoryId, "fk_category");

                entity.Property(e => e.ArticleId).HasColumnName("article_Id");

                entity.Property(e => e.AuthorId).HasColumnName("author_Id");

                entity.Property(e => e.CategoryId).HasColumnName("category_Id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_Date");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("published_Date");

                entity.Property(e => e.Summary)
                    .HasColumnType("tinytext")
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_Date");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_author");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_category");
            });

            modelBuilder.Entity<ArticleMetum>(entity =>
            {
                entity.HasKey(e => e.ArticleMetaId)
                    .HasName("PRIMARY");

                entity.ToTable("article_meta");

                entity.HasIndex(e => e.ArticleId, "fk_article_meta");

                entity.Property(e => e.ArticleMetaId)
                    .ValueGeneratedNever()
                    .HasColumnName("article_Meta_Id");

                entity.Property(e => e.ArticleId).HasColumnName("article_Id");

                entity.Property(e => e.MetaContent)
                    .HasColumnType("text")
                    .HasColumnName("meta_content");

                entity.Property(e => e.MetaKey)
                    .HasMaxLength(255)
                    .HasColumnName("meta_Key");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleMeta)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_article_meta");
            });

            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasMaxLength(6);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Aspnetuserrole",
                        l => l.HasOne<Aspnetrole>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                        r => r.HasOne<Aspnetuser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("aspnetuserroles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.CategoryName, "category_Name")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("category_Id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .HasColumnName("category_Name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_Id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_Date");
            });

            modelBuilder.Entity<CommentDetail>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.UserId, e.CommentId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("comment_detail");

                entity.HasIndex(e => e.CommentId, "fk_comment");

                entity.HasIndex(e => e.UserId, "fk_user_comment");

                entity.Property(e => e.ArticleId).HasColumnName("article_Id");

                entity.Property(e => e.UserId).HasColumnName("user_Id");

                entity.Property(e => e.CommentId).HasColumnName("comment_Id");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.CommentDetails)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("fk_article_comment");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentDetails)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("fk_comment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_comment");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_Name");

                entity.Property(e => e.Intro)
                    .HasMaxLength(255)
                    .HasColumnName("intro");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .HasColumnName("middle_Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("phone_Number");

                entity.Property(e => e.Profile)
                    .HasColumnType("text")
                    .HasColumnName("profile");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_Date");

                entity.Property(e => e.UserAuthority)
                    .HasMaxLength(20)
                    .HasColumnName("user_Authority");

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .HasConstraintName("fk_accountId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
