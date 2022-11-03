namespace Edziennik.Data.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
    }
}
