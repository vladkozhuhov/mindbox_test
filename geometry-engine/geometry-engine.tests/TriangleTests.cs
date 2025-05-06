using System;
using Xunit;
using geometry_engine;
using geometry_engine.Shapes;

namespace geometry_engine.tests;

public class TriangleTests
{
    [Fact]
    public void CalculateArea_WithValidSides_ReturnsCorrectArea()
    {
        // Arrange
        double a = 3;
        double b = 4;
        double c = 5;
        var triangle = new Triangle(a, b, c);
        
        // Полупериметр
        double s = (a + b + c) / 2;
        double expectedArea = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        
        // Act
        double actualArea = triangle.CalculateArea();
        
        // Assert
        Assert.Equal(expectedArea, actualArea);
    }
    
    [Fact]
    public void Constructor_WithZeroSide_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(0, 4, 5));
        Assert.Throws<ArgumentException>(() => new Triangle(3, 0, 5));
        Assert.Throws<ArgumentException>(() => new Triangle(3, 4, 0));
    }
    
    [Fact]
    public void Constructor_WithNegativeSide_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(-3, 4, 5));
        Assert.Throws<ArgumentException>(() => new Triangle(3, -4, 5));
        Assert.Throws<ArgumentException>(() => new Triangle(3, 4, -5));
    }
    
    [Fact]
    public void Constructor_WithInvalidSides_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        // Сумма двух сторон не больше третьей
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 3, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(3, 1, 1));
    }
    
    [Fact]
    public void IsRightAngled_WithRightAngledTriangle_ReturnsTrue()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);
        
        // Act
        bool isRightAngled = triangle.IsRightAngled();
        
        // Assert
        Assert.True(isRightAngled);
    }
    
    [Fact]
    public void IsRightAngled_WithNonRightAngledTriangle_ReturnsFalse()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 6);
        
        // Act
        bool isRightAngled = triangle.IsRightAngled();
        
        // Assert
        Assert.False(isRightAngled);
    }
    
    [Fact]
    public void CreateTriangleThroughFactory_WithValidSides_ReturnsTriangleObject()
    {
        // Arrange
        double a = 3, b = 4, c = 5;
        
        // Act
        var shape = ShapeFactory.CreateTriangle(a, b, c);
        
        // Assert
        Assert.IsType<Triangle>(shape);
        var triangle = shape as Triangle;
        Assert.Equal(a, triangle.SideA);
        Assert.Equal(b, triangle.SideB);
        Assert.Equal(c, triangle.SideC);
    }
} 