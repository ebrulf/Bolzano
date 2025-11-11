// See https://aka.ms/new-console-template for more information

using System.CommandLine;

Console.WriteLine("Hello, World!");
//przykładowy kod
//StreamReader w Systems.IO dołączony
double[] x = new double[] { 1, 2 };
double[] y = new double[] { 5, 10 };
// zważa na wielkość liter
Option<bool> helpOption = new("--help", ["-h", "/h", "-?", "/?"]);
helpOption.Aliases.Add("--pomoc");
RootCommand rootCommand = new("Praca inżynierska");// i już nie trzeba doprecyzować typu
