using System.Collections.Generic;

class AviaryClass
{
    public string aviaryName;
    public int aviarySquare, heightOfWall;

    public List<AnimalClass> animals = new List<AnimalClass>();
}

class AnimalClass
{
    public string animalName, animalFoodType;
    public int animalWeight, countOfFood;
}