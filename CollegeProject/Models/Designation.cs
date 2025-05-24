using Microsoft.Build.Framework;

namespace CollegeProject.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public int DesignationCode { get; set; }
        [Required]
        public string? DesignationAcronym { get; set; } // CEO
        [Required]
        public string DesignationName { get; set; }
        public Stream Stream { get; set; } // Maths or science
        [Required]
        public string RolesandResponsability { get; set; }


    }
    public enum Stream
    {
        All,
        Maths,
        Science,
        SocialScience
    }
}
