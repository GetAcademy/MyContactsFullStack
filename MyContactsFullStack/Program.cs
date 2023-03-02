using MyContactsFullStack.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

var people = new List<Person>
{
    new Person("Per", "per@mail.com"),
    new Person("Pål", "paal@mail.com"),
    new Person("Espen", "espene@mail.com"),
};

app.MapGet("/people", () =>
{
    return people;
});
app.MapGet("/people/{id}", (Guid id) =>
{
    return people.SingleOrDefault(p => p.Id == id);
});
app.Run();
