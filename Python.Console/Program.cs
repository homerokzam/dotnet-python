using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
  .ConfigureServices(services =>
  {
      var home = Path.Join(Environment.CurrentDirectory, "..", "Python.Core");
      services
          .WithPython()
          .WithHome(home)
          .FromConda("/opt/homebrew/Caskroom/miniconda/base")
          .WithCondaEnvironment("projects_env");
          // .FromEnvironmentVariable("Python3_ROOT_DIR", "3.12")
          // .FromMacOSInstallerLocator("3.12")
          // .WithPipInstaller();
  });

var app = builder.Build();

var env = app.Services.GetRequiredService<IPythonEnvironment>();

RunHelloWorld(env);

static void RunHelloWorld(IPythonEnvironment env)
{
  var helloWorld = env.HelloWorld();
  Console.WriteLine(helloWorld.FormatName("Homero"));
}