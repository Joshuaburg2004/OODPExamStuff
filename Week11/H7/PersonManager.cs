public static class PersonManager
{
    // Sorts the Person Array, as there is no Sort method for Arrays
    public static void SortAndDisplayPersonsByAge(Person[,] PersonArray)
    {
        Person[] newPersonArray = new Person[PersonArray.GetLength(0) * PersonArray.GetLength(1)];
        int Index = 0;
        for(int i = 0; i < PersonArray.GetLength(0); i++)
        {
            for(int j = 0; j < PersonArray.GetLength(1); j++)
            {
                newPersonArray[Index] = PersonArray[i, j];
                Index++;
            }
        }
        Array.Sort(newPersonArray);
        foreach(Person person in newPersonArray)
        {
            Console.WriteLine(person);
        }
    }
}
