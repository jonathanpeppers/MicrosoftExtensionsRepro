using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftExtensionsRepro;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        // Microsoft.Extensions thingies
        var provider = new ServiceCollection()
            .AddSingleton<IFoo>(_ => new FooService())
            .BuildServiceProvider();

        var foo = provider.GetService<IFoo>();
        if (foo != null)
        {
            foo.DoStuff();
        }
        else
        {
            Console.WriteLine("foo is null!");
        }
    }
}

interface IFoo
{
    void DoStuff();
}

class FooService : IFoo
{
    public void DoStuff() => Console.WriteLine("Did it!");
}