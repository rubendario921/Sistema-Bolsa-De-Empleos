namespace selecciontalento_api.Models
{
    public class CandidatoIdioma
    {
        public int CanId { get; set; }
        public Candidatos Candidato { get; set; }
        public int IdiId { get; set; }
        public Idiomas Idioma { get; set; }
        public required string CanIdiNivelEscrito { get; set; }
        public required string CanIdiNivelOral { get; set; }
    }
}
