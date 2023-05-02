using System;
using System.ComponentModel;

namespace ImageProcessingApp.Model
{
    public class UserModel
    {
        public int Id { get; set; }
       
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        [DisplayName("Email")]
        public string Email { get; set; }

        
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Profile Picture")]
        public string Image { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Is Account Active")]
        public bool IsActive { get; set; }

        [DisplayName("Are You Admin")]
        public bool IsAdmin { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        [DisplayName("Profile Picture URL")]
        public string ProfilePictureUrl { get; set; }
    }
}
