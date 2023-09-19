// See https://aka.ms/new-console-template for more information
using ConfiguratorDevelopmentStudio;


  string xmlFilePath = "C:\\Users\\Khafizov_ili\\Desktop\\DeletMe\\_ConfigSettings.xml";

  var settings = new Setting();
  settings.LoadFromXml(xmlFilePath);

  // Пример использования полученных данных
  Console.WriteLine("Variables:");
  foreach (var variable in settings.Variables)
  {
    Console.WriteLine($"Name: {variable.Key}, Value: {variable.Value}");
  }

  Console.WriteLine("\nRepositories:");
  foreach (var repository in settings.Repositories)
  {
    Console.WriteLine($"FolderName: {repository.FolderName}, SolutionType: {repository.SolutionType}, URL: {repository.Url}");
  }

  Console.WriteLine($"\nForceUseAppDataPath: {settings.ForceUseAppDataPath}");

