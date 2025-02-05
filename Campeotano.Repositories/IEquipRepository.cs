using Campeonato.Entities;

namespace Campeotano.Repositories
{
    public interface IEquipRepository
    {
        Task<int> AddAsync(Equipo equipo);
        Task DeleteAsync(int id);
        Task<List<Equipo>> GetAsync();
        Task<Equipo?> GetAsync(int id);
        Task UpdateAsync(int id, Equipo equipo);
    }
}