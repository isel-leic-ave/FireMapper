using FireMapper.Attributes;

namespace FireSource.Test
{
     [FireCollection("Students")]
    public record Student(
        [property:FireKey] string Number,
        string Name, 
        [property:FireIgnore] string Classroom) 
    {
        public Student() :this(null, null, null) {}
        public static Student Parse(string input)
        {
            string[] words = input.Split(';');
            return new Student(words[0], words[1], words[2]);
        }

    }
}