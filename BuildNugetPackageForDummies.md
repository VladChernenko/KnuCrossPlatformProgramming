# Build Nuget packet, publish to repository and use in project


>https://medium.com/@churi.vibhav/creating-and-using-a-local-nuget-package-repository-9f19475d6af8




# Створення 


<img src="./assets/Pasted image 20230927014234.png">


# Установка Nuget

https://www.nuget.org/downloads

Для роботи потрібно буде встановити NuGet CLI. Зробіть це за посиланням і додайте бінарник в PATH для зручності

# Написання коду


Оформіть код своєї роботи та винесіть її у окрему функцію яка буде використовуватись у клієнтському коді. Наприклад, сигнатура моєї функції має такий вигляд


```csharp
public static void FindSquareOfMaze(string pathToInputFile, string pathToOutputFile)
```


# Білд


Після виконання задачі, перейдіть до `Project > <YOUR PROJECT NAME> properties`

<img src="./assets/Pasted image 20230927014536.png">


Заповніть поля

<img src="./assets/Pasted image 20230927014814.png">


Перед білдом переконайтесь, що отриманий пакет буде релізним. Для цього, оберіть опцію `Release`

<img src="./assets/Pasted image 20230927015013.png">


# Створення локального репозиторію для Nuget пакетів

У деякій директорії створіть репозиторій

```shell
mkdir LocalRepoForNuget
```

Перейдіть в директорію з вашим релізним білдом

```shell
cd C:\Users\<YOUR PATH>\Lab3\bin\Release\
```

І введіть команду

```shell
nuget add <YOUR PACKAGE NAME>.<SEMVER>.nupkg -source C:\Users\Acer\MyProjects\LocalRepoForNuget
```



# Створення проекту який буде використовувати даний Nuget пакет


В тому ж Solution створіть новий проект(або в іншому - за бажанням)


<img src="./assets/Pasted image 20230927015415.png">

Приміром, у мене ієрархія має такий вигляд:

<img src="./assets/Pasted image 20230927015500.png">


# Підключення пакету до проекту


Оберіть `Project > Manage Nuget Packages`


<img src="./assets/Pasted image 20230927015622.png">

Додайте локальний репозиторій в якості додаткового джерела пакетів


<img src="./assets/Pasted image 20230927015720.png">

<img src="./assets/Pasted image 20230927015732.png">

Тепер можна імпортувати пакет


<img src="./assets/Pasted image 20230927015803.png">

Код використання

```csharp

namespace Lab3Usage
{
    class Program
    {
        static void Main(string[] args)
        {

            string pathToInputFile = "../../../input.txt";

            string pathToOutputFile = "../../../output.txt";

            Lab3.Class1.FindSquareOfMaze(pathToInputFile,pathToOutputFile);
        }
    }
}

```


Результат


<img src="./assets/Pasted image 20230927015903.png">


>Приклади вхідних файлів доступні в цьому ж репозиторії


