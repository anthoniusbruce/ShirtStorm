namespace ShirtStormMvc.Models
{
    public class PreambleViewModel
    {
        public string? FinalTagLine { get; set; }

        public bool ShowFinalTagLine => !string.IsNullOrEmpty(FinalTagLine);
    }
}
