using System.Data.Entity;
using JobHunt.Data.Entities.Attachment;
using JobHunt.Data.Entities.Email;
using JobHunt.Data.Entities.JobHunt;
using JobHunt.Data.Entities.Login;

namespace JobHunt.Data
{
    public class JobHuntContext : DbContext, IEntityContext
    {
        public JobHuntContext()
            : base("name=JobHuntContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            return;
        }


        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<EmailQueue> EmailQueue { get; set; }
        public virtual DbSet<DeliveriedEmail> DeliveriedEmail { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
    }
}
