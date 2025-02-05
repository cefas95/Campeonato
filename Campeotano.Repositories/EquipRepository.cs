using Campeonato.Entities;
using Campeonato.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Campeotano.Repositories
{
    public class EquipRepository : IEquipRepository
    {
        private readonly AplicationDbContext context;

        public EquipRepository(AplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Equipo>> GetAsync()
        {
            return await context.Equipos.ToListAsync();
        }

        public async Task<Equipo?> GetAsync(int id)
        {

            return await context.Equipos.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<int> AddAsync(Equipo equipo)
        {
            context.Equipos.Add(equipo);
            await context.SaveChangesAsync();
            return equipo.Id;

        }

        public async Task UpdateAsync(int id, Equipo equipo)
        {
            var item = await GetAsync(id);
            if (item is not null)
            {
                item.Name = equipo.Name;
                item.Status = equipo.Status;

                context.Update(item);
                await context.SaveChangesAsync();
            }

        }
        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item is not null)
            {
                context.Equipos.Remove(item);
                await context.SaveChangesAsync();
            }

        }

    }

    public interface IEquipRepository
    {
    }
}
