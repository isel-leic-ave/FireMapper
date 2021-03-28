using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace FireSource.Test
{
    [Collection("FireStoreFixture collection")]
    public class FireDataSourceTest
    {
        readonly ITestOutputHelper output;
        private readonly FireStoreFixture fix;
        private readonly FireDataSource studentsDb;

        public FireDataSourceTest(ITestOutputHelper output, FireStoreFixture fix)
        {
            this.output = output;
            this.fix = fix;
            this.studentsDb = fix.studentsDb;
        }
        
        [Fact]
        public void GetAll()
        {
            int count = 0;
            foreach(var dic in studentsDb.GetAll()) {
                output.WriteLine(ToString(dic));
                count++;
            }
            Assert.Equal(9, count);
        }
        
        [Fact]
        public void GetById()
        {
            Dictionary<string, object> st = studentsDb.GetById("44999");
            Assert.Equal("Bartiskovley Navriska Bratsha Sverilev", st["Name"]);
        }

        [Fact]
        public void UpdateStudent()
        {
            studentsDb.Update(new Dictionary<string, object>() {
                {"Number", "55999"},
                {"Name", "Nuwanda Dead Poets Society"}
            });
            Dictionary<string, object> st = studentsDb.GetById("55999");
            Assert.Equal("Nuwanda Dead Poets Society", st["Name"]);
        }

        [Fact]
        public void AddGetAndDeleteAndGetAgain()
        {
            ///
            /// Arrange and Insert new Student
            /// 
            Student st = new Student("823648", "Ze Manel", "TLI41D");
            studentsDb.Add(new Dictionary<string, object>(){
                {"Number", st.Number},
                {"Name", st.Name},
                {"Classroom", st.Classroom},
            });
            /// 
            /// Get newby Student
            /// 
            var actual = studentsDb.GetById(st.Number);
            Assert.Equal(st.Name, actual["Name"]);
            Assert.Equal(st.Number, actual["Number"]);
            Assert.Equal(st.Classroom, actual["Classroom"]);
            /// 
            /// Remove Student
            /// 
            studentsDb.Delete(st.Number);
            Assert.Null(studentsDb.GetById(st.Number));
        }

        static string ToString(Dictionary<string, object> source) {
            StringBuilder buffer = new StringBuilder();
            buffer.Append('{');
            foreach(var pair in source) {
                buffer.Append($"{pair.Key} : {pair.Value},");
            }
            if(buffer.Length > 1) buffer.Length--; // Remove extra comma
            buffer.Append('}');
            return buffer.ToString();
        }
    }
}
