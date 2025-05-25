namespace CollegeProject.Models
{
    public class DesignationVM
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public int DesignationCode { get; set; }
        public string? DesignationAcronym { get; set; } 
        public string DesignationName { get; set; }
        public Stream Stream { get; set; } 
        public string RolesandResponsability { get; set; }
    }
}
