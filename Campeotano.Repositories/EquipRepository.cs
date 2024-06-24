using Campeonato.Entities;

namespace Campeotano.Repositories
{
    public class EquipRepository
    {
        private readonly List<Equipo> equiposList;
        public EquipRepository()
        {
            equiposList = new List<Equipo>();
            equiposList.Add(new Equipo() { Id = 1, Name = "Armatex" });
            equiposList.Add(new Equipo() { Id = 2, Name = "Santos" });
            equiposList.Add(new Equipo() { Id = 1, Name = "Galaxi" });

        }
        public List<Equipo> Get()
        {
            return equiposList;
        }

        public Equipo? Get(int id)
        {
            return equiposList.FirstOrDefault(x=>x.Id== id); 

        }
        public void Add(Equipo equipo)
        {
            var lastItem = equiposList.MaxBy(x => x.Id);
            equipo.Id = lastItem is null ? 1 : lastItem.Id +1;
            equiposList.Add(equipo);
         }

        public void Update(int id, Equipo equipo) 
        {
            var item = Get(id);
            if (item is not  null) { 
                item.Name = equipo.Name;
                item.Status = equipo.Status;
            }
        
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) 
            {equiposList.Remove(item); 
            }

        }

    }
}
