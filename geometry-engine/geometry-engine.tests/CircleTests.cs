using System;
using Xunit;
using geometry_engine;
using geometry_engine.Shapes;

namespace geometry_engine.tests;

public class CircleTests
{
    [Fact]
    public void CalculateArea_WithValidRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5;
        var circle = new Circle(radius);
        double expectedArea = Math.PI * radius * radius;
        
        // Act
        double actualArea = circle.CalculateArea();
        
        // Assert
        Assert.Equal(expectedArea, actualArea);
    }
    
    [Fact]
    public void Constructor_WithZeroRadius_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Circle(0));
        Assert.Contains("Радиус должен быть положительным числом", exception.Message);
    }
    
    [Fact]
    public void Constructor_WithNegativeRadius_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Circle(-5));
        Assert.Contains("Радиус должен быть положительным числом", exception.Message);
    }
    
    [Fact]
    public void CreateCircleThroughFactory_WithValidRadius_ReturnsCircleObject()
    {
        // Arrange
        double radius = 10;
        
        // Act
        var shape = ShapeFactory.CreateCircle(radius);
        
        // Assert
        Assert.IsType<Circle>(shape);
        var circle = shape as Circle;
        Assert.Equal(radius, circle.Radius);
    }
} 