# SectionTriangleAnalyzer
**1. Платформа и язык.**

Net Core 2.2.0, C#

NuGet пакеты: CommandLineParser 2.7.82, NLog 4.6.8, NUnit 3.12.0, Microsoft.Extensions.Configuration 3.1.1

**2. Аргументы командной строки:**

-f <ссылка на текстовый файл с данными> или --files <ссылка на текстовый файл с данными>

Пример запсука на тестовый данных: -f D:\SectionTriangleAnalyzer\data.txt

**3. Структура файла с данными:**

x1 y1 x2 y2 x3 y3 L

где xi, yi - x и y координаты i точки равностороннего треугольника, L - анализируемое значение разреза.

Пример:

0 0 7 0 3.5 6.062177826 50

**4. Алгоритм работы.**

Основная идея алгоритма описана в: [теоретическом решении.](https://github.com/sergbelom/SectionTriangleAnalyzer/blob/master/SectionAnalyzer.pdf)

**TODO List:**
- реализовать unit тесты.
