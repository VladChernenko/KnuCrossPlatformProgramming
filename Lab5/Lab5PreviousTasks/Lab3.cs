using System;
using System.Collections.Generic;
using System.IO;


/*
 

MIT License

by Vlad Chernenko (IPZ-41/1)
 
Ticket 15

Lab3


[Task]:

    Лабіринт являє собою квадрат, що складається з N×N сегментів.
    Кожен із сегментів може бути або порожнім, або заповнений стіною
    Гарантується, що лівий верхній та правий нижній сегменти порожні
    Лабіринт обнесений зверху, снизу, слева і справа стінами, які залишають тільки верхній лівий та правий нижній кут

    Директор лабіринта вирішив пофарбувати стіни лабіринту, видимі ізсередини
    Треба обчислити площу стінок


[Solution]:

    1) Отримуємо N та лабіринт із вхідного файлу построчно
    2) Оскільки лабіринт обнесено стіною, то фактично розміри лабіринту будуть не NxN, а (N+2)x(N+2)
    3) Оскільки розглядати будемо лабіринт як матрицю, то ці додаткові стіни будуть заповнені знаком *

        Таким чином легенда має такий вигляд:

            1) '.' - немає стіни
            2) '#' - стіна
            3) '*' - границя лабіринту

    4) Використовуючи обхід в ширину BFS проходимо по кліткам лабіринту. Починаємо з верхнього лівого - тут буде координата (1;1)
    5) Відкриваючи нові клітки додаємо їх в чергу
    6) Довкола поточної клітки яку перевіряємо перевіряємо всі 4 суміжні клітки. Якщо сусідня клітка рівна '.' - збільшуємо counter змінної пустих клітинок поряд
    7) В кінці функції перевірки повертаємо кількість видимих стін з даної клітки - це буде 4-<кількість порожніх довкола поточної клітки>
    
    __________Loops resolution__________

    8) Якщо пусті клітинки з усіх боків оточені стіною, то відповідні площі рахувати не треба(бо їх не видно з середини петлі)
    9) Цього можна уникнути як вже запропоновано в алгоритмі - роблячи прохід в ширину ТІЛЬКИ ПО ПОРОЖНІМ КЛІТИНКАМ
    10) Це буде гарантією того, що ми ніколи не натрапимо на клітинку зі стіною, а отже клітинка що знаходиться в петлі НІКОЛИ НЕ ПОТРАПИТЬ до черги обходу





*/

namespace Lab5PreviousTasks
{
    public class Lab3
    {

        static int Check(int row, int col, char[][] lab, int[][] visited, Queue<int> plan)
        {
            int empty = 0;
            if (visited[row][col] != 1)
            {
                if (lab[row + 1][col] == '.')
                {
                    empty++;
                    if (visited[row + 1][col] != 1)
                    {
                        plan.Enqueue(row + 1);
                        plan.Enqueue(col);
                    }
                }
                if (lab[row - 1][col] == '.')
                {
                    empty++;
                    if (visited[row - 1][col] != 1)
                    {
                        plan.Enqueue(row - 1);
                        plan.Enqueue(col);
                    }
                }
                if (lab[row][col + 1] == '.')
                {
                    empty++;
                    if (visited[row][col + 1] != 1)
                    {
                        plan.Enqueue(row);
                        plan.Enqueue(col + 1);
                    }
                }
                if (lab[row][col - 1] == '.')
                {
                    empty++;
                    if (visited[row][col - 1] != 1)
                    {
                        plan.Enqueue(row);
                        plan.Enqueue(col - 1);
                    }
                }
                visited[row][col] = 1;
                return 4 - empty;
            }
            return 0;
        }

        public static string Lab3Execution(string pathToInputFile, string pathToOutputFile)
        {
            int N;
            using (StreamReader reader = new StreamReader(pathToInputFile))
            {
                N = int.Parse(reader.ReadLine());
            }

            char[][] lab = new char[N + 2][];
            int[][] visited = new int[N + 2][];

            for (int i = 0; i < N + 2; i++)
            {
                lab[i] = new char[N + 2];
                visited[i] = new int[N + 2];
                for (int j = 0; j < N + 2; j++)
                {
                    visited[i][j] = 0;
                    if (i == 0 || i == N + 1 || j == 0 || j == N + 1)
                    {
                        lab[i][j] = '*';
                    }
                }
            }

            using (StreamReader reader = new StreamReader(pathToInputFile))
            {
                // Drop first line with N
                string firstline = reader.ReadLine();

                for (int i = 1; i <= N; i++)
                {
                    string line = reader.ReadLine();
                    for (int j = 1; j <= N; j++)
                    {
                        lab[i][j] = line[j - 1];
                    }
                }
            }

            Queue<int> plan = new Queue<int>();

            plan.Enqueue(1);
            plan.Enqueue(1);

            int walls = 0;

            while (plan.Count > 0)
            {
                int row = plan.Dequeue();
                int col = plan.Dequeue();
                walls += Check(row, col, lab, visited, plan);
            }

            if (visited[N][N] != 1) // якщо не потрапили до правої нижньої клітини - продовжуємо підрахунок площі починаючи з неї
            {

                plan.Enqueue(N);
                plan.Enqueue(N);

                while (plan.Count > 0)
                {
                    int row = plan.Dequeue();
                    int col = plan.Dequeue();

                    walls += Check(row, col, lab, visited, plan);

                }

            }

            walls -= 4; // не рахуємо 4 стіни довкола вхідних кліток

            int meters = walls * 5 * 5; // стіни 5x5

            string response = "";

            response += "Total meters are => " + meters;

            // Записуємо результати у файл
            using (StreamWriter writer = new StreamWriter(pathToOutputFile))
            {
                writer.WriteLine(meters);
            }

            return response;
        }

    }
}