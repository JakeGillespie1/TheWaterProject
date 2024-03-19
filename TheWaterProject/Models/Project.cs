using System.ComponentModel.DataAnnotations;

namespace TheWaterProject.Models
{
    public class Project
    {
        [Key]
        public int projectId { get; set; }

        public string projectName { get; set; }

        public string programName { get; set; }

        public string? projectType { get; set; }

        public int projectImpact {  get; set; }

        public DateTime projectInstallation {  get; set; }

        public string projectPhase { get; set; }
    }
}
