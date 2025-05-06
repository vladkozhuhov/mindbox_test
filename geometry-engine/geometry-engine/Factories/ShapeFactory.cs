using geometry_engine.Interfaces;
using geometry_engine.Shapes;

namespace geometry_engine;

/// <summary>
/// Фабричный класс для создания геометрических фигур
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Создает круг с заданным радиусом
    /// </summary>
    /// <param name="radius">Радиус круга</param>
    /// <returns>Объект круга</returns>
    public static IShape CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    /// <summary>
    /// Создает треугольник с заданными сторонами
    /// </summary>
    /// <param name="sideA">Первая сторона</param>
    /// <param name="sideB">Вторая сторона</param>
    /// <param name="sideC">Третья сторона</param>
    /// <returns>Объект треугольника</returns>
    public static IShape CreateTriangle(double sideA, double sideB, double sideC)
    {
        return new Triangle(sideA, sideB, sideC);
    }
} 