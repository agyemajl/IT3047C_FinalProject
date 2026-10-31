using System.ComponentModel.DataAnnotations;

namespace IT3047C_FinalProject.Models;

public class TeamMember
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A name is required.")]
    public string? Name { get; set; }

    public string? MNumber { get; set; }

    [Required(ErrorMessage = "An email is required.")]
    public string? Email { get; set; }

    public string? GitHubUsername { get; set; }
}
