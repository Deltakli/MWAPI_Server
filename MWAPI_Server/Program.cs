WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

List<Superhero> heroes = new();

heroes.Add(new() {Name="Superman", Power=9001});
heroes.Add(new() {Name="Batman", Power=9});
heroes.Add(new() {Name="Wallman", Power=-5});

//10.156.10.218

//Superhero hero = new Superhero();
//hero.Name = "Superman";
//hero.Power = 9001;
//hero.UndewearOnTheOutside = true;

app.MapGet("/",Answer);

app.MapGet("/superhero/", () => 
{
  return heroes;
});

app.MapGet("/superhero/{num}", (int num) =>
{
    if (num >= 0 && num < heroes.Count)
    {
    return Results.Ok(heroes[num]);
    }

return Results.NotFound();
});

app.MapPost("/superhero/", () =>
{
    Console.WriteLine("I GOT POST");
});



app.Run();


static string Answer()
{
    return "Hello TE20A";
}