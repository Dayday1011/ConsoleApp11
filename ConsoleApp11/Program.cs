using System;

class Program
{
    static void Main(string[] args)
    {
        var userInfo = GetUserInfo();
        DisplayUserInfo(userInfo);
    }
    static (string Name, string Surname, int Age, bool HasPet, string[] PetNames, string[] FavoriteColors) GetUserInfo()
    {
        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите вашу фамилию: ");
        string surname = Console.ReadLine();
        int age = GetValidIntInput("Введите ваш возраст: ");
        Console.WriteLine("Есть ли у вас питомец? (да/нет): ");
        bool hasPet = Console.ReadLine().ToLower() == "да";
        //proverka
        string[] petNames = null;
        if (hasPet)
        {
            int petCount = GetValidIntInput("Сколько у вас питомцев: ");
            if (petCount > 0)
            {
                petNames = GetPetNames(petCount);
            }
        }
        int colorCount = GetValidIntInput("Сколько у вас любимых цветов: ");
        string[] favoriteColors = GetFavoriteColors(colorCount);
        return (name, surname, age, hasPet, petNames, favoriteColors);
    }
    static int GetValidIntInput(string prompt)
    {
        int result;
        bool isValid = false;
        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            //  na 0 proverka2.0:
            if (int.TryParse(input, out result) && result > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное число больше 0.");
            }

        } while (!isValid);

        return result;
    }
    static string[] GetPetNames(int count)
    {
        string[] petNames = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите кличку питомца {i + 1}: ");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }
    static string[] GetFavoriteColors(int count)
    {
        string[] favoriteColors = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите ваш любимый цвет {i + 1}: ");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }
    static void DisplayUserInfo((string Name, string Surname, int Age, bool HasPet, string[] PetNames, string[] FavoriteColors) userInfo)
    {
        Console.WriteLine("\nИнформация о пользователе:");
        Console.WriteLine($"Имя: {userInfo.Name}");
        Console.WriteLine($"Фамилия: {userInfo.Surname}");
        Console.WriteLine($"Возраст: {userInfo.Age}");
        if (userInfo.HasPet && userInfo.PetNames != null)
        {
            Console.WriteLine($"Клички питомцев: {string.Join(", ", userInfo.PetNames)}");
        }
        else
        {
            Console.WriteLine("Питомцев нет.");
        }
        Console.WriteLine($"Любимые цвета: {string.Join(", ", userInfo.FavoriteColors)}");
    }
}
