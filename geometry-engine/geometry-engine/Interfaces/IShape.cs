namespace geometry_engine.Interfaces;

/// <summary>
/// Базовый интерфейс для всех геометрических фигур
/// </summary>
public interface IShape
{
    /// <summary>
    /// Вычисляет площадь фигуры
    /// </summary>
    /// <returns>Площадь фигуры</returns>
    double CalculateArea();
} 