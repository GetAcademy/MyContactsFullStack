namespace MyContactsFullStack.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string name, string email) : this() 
        {
            Name = name;
            Email = email;
        }
    }
}
