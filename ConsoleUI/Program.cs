using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // We simply apply our Student-Structure to XML
            string studentsXML =
                @"<Students>
                   <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                        <Semester>6</Semester>
                   </Student> 
                   <Student>
                        <Name>Carla</Name>
                        <Age>17</Age>
                        <University>Yale</University>
                        <Semester>1</Semester>
                   </Student>  
                   <Student>
                        <Name>Leyla</Name>
                        <Age>19</Age>
                        <University>Beijing Tech</University>
                        <Semester>3</Semester>
                   </Student>  
                   <Student>
                        <Name>Frank</Name>
                        <Age>25</Age>
                        <University>Beijing Tech</University>
                        <Semester>10</Semester>
                   </Student>  
                  </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               Univesity = student.Element("University").Value,
                               Semester = student.Element("Semester").Value
                           };

            foreach (var s in students)
            {
                Console.WriteLine($"Student {s.Name} with " +
                    $"age {s.Age} from university {s.Univesity} is in his/her {s.Semester} semester");
            }

            var sortedStudentsByAge = from student in students
                                      orderby student.Age
                                      select student;


            Console.WriteLine("Students sorted by age: ");
            foreach (var s in sortedStudentsByAge)
            {
                Console.WriteLine($"Student {s.Name} with " +
                    $"age {s.Age} from university {s.Univesity} is in his/her {s.Semester} semester");
            }

            Console.ReadLine();
        }
    }
}
