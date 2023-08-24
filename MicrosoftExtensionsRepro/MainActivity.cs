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
            .AddScoped<IFoo>(_ => new FooService())
            .BuildServiceProvider();

        Scoped(provider);

        // Second call would hit S.R.E
        //Scoped(provider);
    }

    static void Scoped(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var foo = scope.ServiceProvider.GetRequiredService<IFoo>();
        foo.DoStuff();
    }
}

interface IFoo
{
    void DoStuff();
}

class FooService : IFoo
{
    static int count;
    int ID = ++count;

    public void DoStuff() => Console.WriteLine($"Did it! ID: {ID}");
}