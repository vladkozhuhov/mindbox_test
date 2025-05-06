using System;
using Xunit;
using geometry_engine;
using geometry_engine.Interfaces;
using geometry_engine.Shapes;

namespace geometry_engine.tests;

public class ShapeFactoryTests
{
    [Fact]
    public void CreateCircle_WithValidRadius_ReturnsCircle()
    {
        // Arrange
        double radius = 5;
        
        // Act
        var shape = ShapeFactory.CreateCircle(radius);
        
        // Assert
        Assert.IsType<Circle>(shape);
    }
    
    [Fact]
    public void CreateTriangle_WithValidSides_ReturnsTriangle()
    {
        // Arrange
        double a = 3, b = 4, c = 5;
        
        // Act
        var shape = ShapeFactory.CreateTriangle(a, b, c);
        
        // Assert
        Assert.IsType<Triangle>(shape);
    }
    
    [Fact]
    public void CreateCircle_WithInvalidRadius_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircle(-5));
    }
    
    [Fact]
    public void CreateTriangle_WithInvalidSides_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(-1, 2, 3));
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(1, 1, 3));
    }
    
    [Fact]
    public void UseShapeWithoutKnowingType_CalculateArea_ReturnsCorrectArea()
    {
        // Arrange
        IShape circle = ShapeFactory.CreateCircle(5);
        IShape triangle = ShapeFactory.CreateTriangle(3, 4, 5);
        
        // Act
        double circleArea = circle.CalculateArea();
        double triangleArea = triangle.CalculateArea();
        
        // Assert
        Assert.Equal(Math.PI * 25, circleArea);
        Assert.Equal(6, triangleArea);
    }
} 