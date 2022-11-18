namespace Equipment_Mgmt
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Devices { get; set; }

        public Person(string firstName, string lastName, string[] devices)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Devices = devices;
        }
    }
}
