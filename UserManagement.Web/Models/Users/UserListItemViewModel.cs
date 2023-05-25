using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class UserListItemViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Forename is required")]
    public string? Forename { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Email is required")]

    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    public bool IsActive { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    public DateTime? DateOfBirth { get; set; }
}