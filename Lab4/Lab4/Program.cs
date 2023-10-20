using System;
using McMaster.Extensions.CommandLineUtils;


// Лабораторні роботи
using Lab4ClassLibs;


public class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication();

        app.HelpOption();

        //___________________Define commands___________________

        app.Command("version", command => {

            command.Description = "Display the author and CLI version";

            command.OnExecute(()=>Console.WriteLine("Amazing CLI for Lab4 v1.0.0 created by Vlad Chernenko"));

        });

        app.Command("set-path", command =>
        {

            command.Description = "Set the path to input/output files for labs";
            
            var pathOption = command.Option("-p|--path", "Path to the folder with input and output files", CommandOptionType.SingleValue);

            // Зазначаємо що параметр є обов'язковим
            pathOption.IsRequired();

            command.OnExecute(() => {

                var pathValue = pathOption.Value();

                //Зберігаємо в LAB_PATH змінну середовища
                System.Environment.SetEnvironmentVariable("LAB_PATH",pathValue, EnvironmentVariableTarget.User);

                Console.WriteLine($"LAB_PATH has been set to: {pathValue}");

            });

        });
        
        app.Command("run", command => {

            command.Description = "Execute labs 1-3";


            var labArgument = command.Argument("lab", "The lab to run (lab1, lab2, lab3)");

            var inputOptionPath = command.Option("-i|--input <path>", "Input file path", CommandOptionType.SingleValue);
            var outputOptionPath = command.Option("-o|--output <path>", "Output file path", CommandOptionType.SingleValue);


            command.OnExecute(() => {


                var inputOption = inputOptionPath.Value();
                var outputOption = outputOptionPath.Value();

                //Визначаємо пріорітетність шляху

                //1. Якщо значення встановлені - нічого не змінюємо
                //2. Якщо значення немає - перевіряємо шлях в LAB_PATH
                //3. Інакше - встановлюємо значення домашньої директорії користувача від імені якого буде запускатись бінарник

                if (string.IsNullOrEmpty(inputOption))
                {

                    inputOption = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);

                    if (string.IsNullOrEmpty(inputOption))
                    {

                        inputOption = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                        if (!string.IsNullOrEmpty(inputOption)) inputOption = Path.Combine(inputOption, "input.txt");

                    }
                    else
                    {

                        inputOption = Path.Combine(inputOption, "input.txt");

                    }

                }

                if (string.IsNullOrEmpty(outputOption))
                {

                    outputOption = Environment.GetEnvironmentVariable("LAB_PATH",EnvironmentVariableTarget.User);

                    if (string.IsNullOrEmpty(outputOption))
                    {

                        outputOption = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                        if (!string.IsNullOrEmpty(outputOption)) outputOption = Path.Combine(outputOption, "output.txt");
                    }
                    else
                    {

                        outputOption = Path.Combine(outputOption, "output.txt");

                    }

                }

                // Перевіряємо наявність input.txt по шляху

                if (File.Exists(inputOption))
                {
                    string labValue = labArgument.Value;

                    if (string.IsNullOrEmpty(labValue)||(labValue != "lab1" && labValue != "lab2" && labValue != "lab3"))
                    {
                        Console.WriteLine("Invalid lab value. Use lab1, lab2, or lab3.");

                    }
                    else {

                        if (labValue == "lab1") Lab1.Lab1Execution(inputOption, outputOption);

                        else if (labValue == "lab2") Lab2.Lab2Execution(inputOption, outputOption);

                        else Lab3.Lab3Execution(inputOption, outputOption);

                    }


                }
                else {

                    Console.WriteLine($"Can't find input.txt file by path {inputOption}\n\n");

                    command.ShowHelp();
                
                }

            });


        });

        app.OnExecute(() => app.ShowHelp());

        return app.Execute(args);

    }

}