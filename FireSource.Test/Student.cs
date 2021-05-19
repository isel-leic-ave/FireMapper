namespace FireSource.Test
{
    public record Student(string Name, string Classroom) 
    {

        public string Number {get; set; }

        public Student() :this(null, null, null) {}
        public static Student Parse(string input)
        {
            string[] words = input.Split(';');
            return new Student(words[0], words[1], words[2]);
        }

    }
}