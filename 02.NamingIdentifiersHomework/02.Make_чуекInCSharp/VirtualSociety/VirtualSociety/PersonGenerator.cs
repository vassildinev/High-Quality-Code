namespace VirtualSociety
{
    public enum Gender 
    { 
        Male, 
        Female 
    }

    public class PersonGenerator
    {
        public static void GeneratePerson(int age)
        {
            Person person = new Person();
            person.Age = age;

            int genderDeterminer = age % 2;
            if (genderDeterminer == 0)
            {
                person.Name = "Brad";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Angelina";
                person.Gender = Gender.Female;
            }
        }
    }
}
