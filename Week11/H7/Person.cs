// example of IComparable and ToString
public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public int CompareTo(Person? person)
    {
        if(person is not null) { return Age.CompareTo(person.Age); }
        return Age;
    }

    public override string ToString()
    {
        return $"{Name}, {Age} years old";
    }
}
