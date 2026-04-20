using System.ComponentModel.DataAnnotations;

namespace apbd_cw5_git_s33665.Model;

public class Reservation :  IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Room Id not provided")]
    public int? RoomId { get; set; }

    [Required(ErrorMessage = "Organizer name not provided")]
    public string OrganizerName { get; set; }

    [Required(ErrorMessage = "Topic not provided")]
    public string Topic { get; set; }

    [Required(ErrorMessage = "Date not provided")]
    public DateOnly? Date { get; set; }

    [Required(ErrorMessage = "Beginning time not provided")]
    public TimeSpan? StartTime { get; set; }

    [Required(ErrorMessage = "Ending time not provided")]
    public TimeSpan? EndTime { get; set; }

    [Required(ErrorMessage = "Status not provided")]
    public string Status { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime.Value <= StartTime.Value)
        {
            yield return new ValidationResult("Reservation end time must be after start time", 
                new[] { nameof(EndTime) }); 
        }
    }
}