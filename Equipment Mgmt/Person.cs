namespace Equipment_Mgmt
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title{ get; set; }
        public string[] Devices { get; set; }

        public Person(string firstName, string lastName,string title, string[] devices)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Title= title;
            this.Devices = devices;
        }
    }


}
