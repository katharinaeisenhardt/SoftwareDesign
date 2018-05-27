using System;
using System.Collections.Generic;

namespace UML
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public class Person{
            public string name;
            public int age;
        }

        public class Participant : Person{
            public int matriculationNumber;
            public List<Course> Courses = new List<Course>();
        }

        public class Lecturer : Person{
            public string officeRoom;
            public DateTime officeHours;
            public List<Course> Courses = new List<Course>();

            public void teachingCourses(){
                Console.WriteLine("Kurse: ");
                foreach( var course in Courses){
                    Console.WriteLine("->" + course.title);
                }
            }

            public List<Participant> currentParticipants(){
                List<Participant> nowParticipants = new List<Participant>();
                foreach(var course in Courses){
                    nowParticipants.AddRange(course.Participants);              //nur Add kann nicht konvertieren, AddRange fügt nicht nur 1 Objekt
                }                                                               // hinzu sondern Elemente einer IEnumerable<T> collection.
                return nowParticipants;
            }
        }

        public class Course{
            public string title;
            public DateTime courseHours;
            public string courseRoom;
            public Lecturer Lecturer;
            public List<Participant> Participants;

            public string infotext(){
                return "Die Veranstaltung " + title + " wird " + courseHours + " vom Dozenten " + Lecturer.name + " im Raum " + courseRoom + " abgehalten.";
            }
        }
    }
}
