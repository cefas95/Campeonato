namespace Campeonato.Entities
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Status { get; set; } = true;
    }
}
