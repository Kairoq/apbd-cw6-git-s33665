using System.ComponentModel.DataAnnotations;

namespace apbd_cw5_git_s33665.Model;

public class Room
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name not provided")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Building Code not provided")]
    public string BuildingCode { get; set; }

    [Required(ErrorMessage = "Floor not provided")]
    public int? Floor { get; set; }

    [Required(ErrorMessage = "Capacity not provided")]
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
    public int? Capacity { get; set; }

    [Required(ErrorMessage = "Provide projector availability information")]
    public bool? HasProjector { get; set; }

    [Required(ErrorMessage = "Provide status information")]
    public bool? IsActive { get; set; }
}