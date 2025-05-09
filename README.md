# Тестовые задания

В этом репозитории представлены решения двух тестовых заданий:

## Задание 1: Библиотека для вычисления площадей фигур

**Файл**: [geometry-engine/](geometry-engine/)

Библиотека на C#, которая вычисляет площадь круга по радиусу и треугольника по трем сторонам. 

Реализовано:
- Вычисление площади круга и треугольника
- Проверка на прямоугольность треугольника
- Вычисление площади без знания типа фигуры в compile-time
- Легкое добавление новых типов фигур
- Юнит-тесты для всех функций библиотеки

## Задание 2: PySpark приложение для работы с продуктами и категориями

**Файл**: [product-category-mapper.py](product-category-mapper.py)

PySpark метод, который работает с датафреймами продуктов и категорий. 

Реализовано:
- Получение всех пар «Имя продукта – Имя категории»
- Получение имен всех продуктов без категорий
- Демонстрация работы на тестовых данных 