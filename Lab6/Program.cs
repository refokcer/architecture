using Lab6.Application;
using Lab6.Infrastructure.Factories;
using Lab6.Infrastructure.Rendering;
using Lab6.Presentation;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var generatorFactory = new FractalGeneratorFactory();
var svgRenderer = new SvgRenderer();
var renderer = new MetricsRendererDecorator(svgRenderer);
var app = new FractalApplication(generatorFactory, renderer);
var ui = new ConsoleUi(app);

ui.Run();
