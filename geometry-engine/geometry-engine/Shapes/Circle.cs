using geometry_engine.Interfaces;

namespace geometry_engine.Shapes;

/// <summary>
/// Класс для представления круга
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Создает новый экземпляр круга с указанным радиусом
    /// </summary>
    /// <param name="radius">Радиус круга</param>
    /// <exception cref="ArgumentException">Вызывается, если радиус меньше или равен 0</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус должен быть положительным числом", nameof(radius));
        }
        
        Radius = radius;
    }

    /// <summary>
    /// Вычисляет площадь круга
    /// </summary>
    /// <returns>Площадь круга</returns>
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
} 