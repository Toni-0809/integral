using System;

class Program
{
    // Интегрирования методом прямоугольников
    public static double Integrate(Func<double, double> func, double a, double b, double limit)
    {
        int n = 1; // Начальное количество прямоугольников
        double previousIntegral = 0; // Предыдущее значение интеграла
        double currentIntegral = 0; // Текущее значение интеграла
        double h;

        do
        {
            h = (b - a) / n; // Обновляем ширину каждого прямоугольника
            currentIntegral = 0; // Сбрасываем текущее значение интеграла


            for (int i = 0; i < n; i++)
            {

                // Вычисляем значение функции в левой точке каждого подинтервала
                double x = a + i * h;
                currentIntegral += func(x)*h; // Прибавляем
            }

            //Проверяем достижение заданной точности
            if (n > 1 && Math.Abs(currentIntegral - previousIntegral) < limit)
            {
                break; // Если разница между текущим и предыдущим интегралом меньше заданной точности, выходим
            }

            previousIntegral = currentIntegral; // Обновляем предыдущее значение интеграла
            n *= 2; // Удваиваем количество прямоугольников

        } while (true);

        return currentIntegral;
    }
    static void Main(string[] args)
    {
        // Пример функции: f(x) = x^2
        Func<double, double> func = x => x * x;

        double a = 0; // Нижний предел интегрирования
        double b = 1; // Верхний предел интегрирования
        double limit = 1e-6; // Заданная точность

        double result = Integrate(func, a, b,limit);
        Console.WriteLine($"Интеграл функции от {a} до {b} = {result}");
    }
}