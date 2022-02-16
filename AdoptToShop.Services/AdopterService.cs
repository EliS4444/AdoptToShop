using AdoptToShop.Data_;
using AdoptToShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdoptToShop.Data_.IdentityModels;

namespace AdoptToShop.Services
{
    public class AdopterService
    {
        private readonly Guid _userId;

        public AdopterService(Guid userId)
        {
            _userId = userId;
        }

        // CREATE Adopter
        public bool CreateAdopter(AdopterCreate model)
        {
            var entity =
                new Adopter()
                {
                    AdopterId = _userId,
                    FullName = model.FullName,
                    Contact = model.Contact
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adopter.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET Adopter
        public IEnumerable<AdopterListItem> GetAdopter()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Adopter
                    .Where(e => e.AdopterId == _userId)
                    .Select(
                        e =>
                        new AdopterListItem
                        {
                            AdopterId = e.AdopterId,
                            FullName = e.FullName,
                            Contact = e.Contact,
                            CreatedUtc = e.CreatedUtc
                        });
                return query.ToArray();
            }
        }

        public AdopterDetail GetAdopterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Adopter
                    .Single(e => e.AdopterId == _userId);
                return
                    new AdopterDetail
                    {
                        AdopterId = entity.AdopterId,
                        FullName = entity.FullName,
                        Contact = entity.Contact,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // UPDATE Adopter

        public bool UpdateAdopter(AdopterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Adopter
                    .Single(e => e.AdopterId == model.AdopterId);

                entity.FullName = model.FullName;
                entity.Contact = model.Contact;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE Adopter
        public bool DeteleAdopter(Guid adopterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Adopter
                    .Single(e => e.AdopterId == adopterId);
                ctx.Adopter.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
