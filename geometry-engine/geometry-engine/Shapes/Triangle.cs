using geometry_engine.Interfaces;

namespace geometry_engine.Shapes;

/// <summary>
/// Класс для представления треугольника
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// Длина первой стороны
    /// </summary>
    public double SideA { get; }
    
    /// <summary>
    /// Длина второй стороны
    /// </summary>
    public double SideB { get; }
    
    /// <summary>
    /// Длина третьей стороны
    /// </summary>
    public double SideC { get; }

    /// <summary>
    /// Создает новый экземпляр треугольника с указанными сторонами
    /// </summary>
    /// <param name="sideA">Длина первой стороны</param>
    /// <param name="sideB">Длина второй стороны</param>
    /// <param name="sideC">Длина третьей стороны</param>
    /// <exception cref="ArgumentException">Вызывается, если какая-либо сторона отрицательная или если стороны не образуют треугольник</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Все стороны треугольника должны быть положительными числами");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("Указанные стороны не могут образовывать треугольник");
        }

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    /// <summary>
    /// Вычисляет площадь треугольника по формуле Герона
    /// </summary>
    /// <returns>Площадь треугольника</returns>
    public double CalculateArea()
    {
        // Формула Герона для расчета площади треугольника
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    /// <summary>
    /// Проверяет, является ли треугольник прямоугольным
    /// </summary>
    /// <returns>true - если треугольник прямоугольный, в противном случае - false</returns>
    public bool IsRightAngled()
    {
        // Сортируем стороны от меньшей к большей
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);

        // Проверяем теорему Пифагора с погрешностью для вещественных чисел
        double epsilon = 1e-10;
        return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < epsilon;
    }
} 