using System;

namespace L03ToDos
{

    //2.ToDo
    public class Person
    {
        public string Name;
        public int Age; /*anzahl der jahre */
        public override string ToString()
        { //ToString wandele den aufgerufenen in einen string um
            return $"Name: { Name }, Alter: { Age }";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 4245; //bsp


            //2. ToDo
            //Person einePerson = new Person(); -> Array für call stack
            Person[] personen ={
                new Person{ Name = "Horst", Age = 42},
                new Person{ Name = "Dieter", Age = 46},
                new Person{ Name = "Karl", Age = 79},
                new Person{ Name = "Schorsch", Age = 45},
                new Person{ Name = "Ernst", Age = 39},
                };

            foreach (var person in personen)
            {
                MachWasMitPerson(person);
            }
        }

        static void MachWasMitPerson(Person person)
        {
            if (person.Age > 40)
            {
                Console.WriteLine("Du bist alt!");
            }
            else
            {
                Console.WriteLine("On the right side of fourty...");
            }
        }

        // einePerson.Name = "Horst";
        //einePerson.Age = 42;

        //Console.WriteLine(i); /*bsp, Inhalt einer integer variable angegeben statt zeichenkette, beachte Integer-Arithmetik */
        //Console.WriteLine(einePerson); /*name L03ToDos.Person, daher einePerson.Name */

        //}
    }
}