namespace DemoProject.Model
{
    class AddItemEventArgs : EventArgs
    {
        public string? Name { get; set; }
        public int? NumberOfPets { get; set; }
        public DateOnly? Birthday { get; set; }
    }
}
