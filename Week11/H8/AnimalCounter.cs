public static class AnimalCounter
{
    public static (int sameSpeciesCount, int sameSpeciesAgeCount) CountOccurrences(Animal[][] AnimalArray, Animal animal)
    {
        // counts how many times animals of the same and of differing species show up
        int sameSpeciesCount = 0;
        int sameSpeciesAgeCount = 0;
        foreach (Animal[] array in AnimalArray)
        {
            foreach(Animal a in array)
            {
                if(a.Species == animal.Species)
                {
                    if(a.Age == animal.Age) { sameSpeciesAgeCount++; }
                    sameSpeciesCount++;
                }
            }
        }
        return (sameSpeciesCount, sameSpeciesAgeCount);
    }
}
