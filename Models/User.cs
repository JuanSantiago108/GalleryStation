#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GalleryStation.Models;
public class User
{

    [Key]
    public int UserId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Name")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Email")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters")]
    public string Email {get; set;}


    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password {get; set;}

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "doesn't match password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword {get; set;}

    public string ProfilePic {get;set;} = "./img/Jiji.png";


    public DateTime CreateAt {get; set;} = DateTime.Now;

    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Art> SubmitedArt {get; set;} = new List<Art>();

    public List<ShoppingCart> CurrentCart { get; set; } = new List<ShoppingCart>();
    

}


