using AdoptToShop.Data_;
using AdoptToShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static AdoptToShop.Data_.IdentityModels;

namespace AdoptToShop.Services
{
    public class AnimalService
    {

        private readonly Guid _userId;

        public AnimalService(Guid userId)
        {
            _userId = userId;
        }

        // CREATE Animal
        public bool CreateAnimal(AnimalCreate model)
        {
            var entity =
                new Animal()
                {
                    PetId = _userId,
                    Name = model.Name,
                    Species = model.Species,
                    Sex = model.Sex,
                    Breed = model.Breed,
                    Age = model.Age,
                    Spayed = model.Spayed,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Animal.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        // GET Animals
        public IEnumerable<AnimalListItem> GetAnimal()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Animal
                        .Where(e => e.PetId == _userId)
                        .Select(
                            e =>
                            new AnimalListItem
                            {
                                PetId = e.PetId,
                                Name = e.Name,
                                Species = e.Species,
                                Sex = e.Sex,
                                Breed = e.Breed,
                                CreatedUtc = e.CreatedUtc
                            }
                            );
                return query.ToArray();
            }
        }

        public AnimalDetail GetAnimalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animal
                        .Single(e => e.PetId == _userId);
                return
                new AnimalDetail
                {
                    PetId = entity.PetId,
                    Name = entity.Name,
                    Breed = entity.Breed,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                };
            }
        }

        // UPDATE Animal
        public bool UpdateAnimal(AnimalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animal
                        .Single(e => e.PetId == model.PetId);

                entity.Name = model.Name;
                entity.Breed = model.Breed;
                entity.Description = model.Description;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAnimal(Guid petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animal
                        .Single(e => e.PetId == petId);
                ctx.Animal.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
