namespace LibraryManagementSystem
{
    internal class Book
    {
        private int ID;
        private string Title;
        private string Author;
        private bool IsAvailable;

        // Constructor to initialize a Book object
        public Book(int id, string title, string author)
        {
            ID = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }
        //if you needed  access to private members use this
        public void SetAvailability(bool availability)
        {
            IsAvailable = availability;
        }   
        public void SetID(int id)
        {
            ID = id;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetAuthor(string author)
        {
            Author = author;
        }


        public int GetID()
        {
            return ID;
        }
        public string GetTitle()
        {
            return Title;
        }
        public string GetAuthor()
        {
            return Author;
        }
        public bool CheckAvailability()
        {
            return IsAvailable;
        }
        public override string ToString()
        {
            return $"Book ID: {ID}, Title: {Title}, Author: {Author}, Available: {IsAvailable} \n";
        }
    }
}
