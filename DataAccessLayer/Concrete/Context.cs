using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Core5Exam;Integrated Security=True;");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ReceiverMessage
            //SenderMessage

            // Gönderici İçin
            modelBuilder.Entity<AllMessage>()
                .HasOne(k => k.SenderUser)
                .WithMany(u => u.SenderMessage)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            // Alıcı İçin
            modelBuilder.Entity<AllMessage>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(g => g.ReceiverMessage)
                .HasForeignKey(e => e.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                //ReceiverUser
                //SenderUser

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<SubscribeMail> SubscribeMails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AllMessage> AllMessages { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
