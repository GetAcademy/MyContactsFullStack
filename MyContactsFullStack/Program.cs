using MyContactsFullStack;
using MyContactsFullStack.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();


const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyContacts;Integrated Security=True";

app.MapGet("/people", () =>
{
    var personRepository = new PersonRepository(connectionString);
    return personRepository.ReadAll();
});
app.MapGet("/people/{id}", (Guid id) =>
{
    var personRepository = new PersonRepository(connectionString);
    return personRepository.ReadById(id);
});
app.MapDelete("/people/{id}", (Guid id) =>
{
    var personRepository = new PersonRepository(connectionString);
    personRepository.Delete(id);
});
app.MapPost("/people", (Person person) =>
{
    var personRepository = new PersonRepository(connectionString);
    personRepository.Create(person);
});
app.MapPut("/people", (Person person) =>
{
    var personRepository = new PersonRepository(connectionString);
    personRepository.Update(person);
});


app.Run();

/*

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
app.MapDelete("/people/{id}", (Guid id) =>
{
    var person = people.SingleOrDefault(p => p.Id == id);
    people.Remove(person);
});
app.MapPost("/people", (Person person) =>
{
    people.Add(person);
});
app.MapPut("/people", (Person person) =>
{
    var changePerson = people.SingleOrDefault(p => p.Id == person.Id);
    changePerson.Name = person.Name;
    changePerson.Email = person.Email;
}); 
 
 */
