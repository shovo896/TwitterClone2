using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos;

public class UpdateUserDtos
{
    [Required, StringLength(50, MinimumLength = 1), RegularExpression(@".*\S.*")]
    public required string FirstName { get; set; }

    [Required, StringLength(50, MinimumLength = 1), RegularExpression(@".*\S.*")]
    public required string LastName { get; set; }
}