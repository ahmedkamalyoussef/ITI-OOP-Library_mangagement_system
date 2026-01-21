namespace LibraryManagementSystem
{
    internal class Book
    {
        private int ID;
        private string Title;
        private string Author;
        public bool IsAvailable;

        // Constructor to initialize a Book object
        public Book(int id, string title, string author)
        {
            ID = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }
        //if you needed  access to private members use this
        
        public void SetID(int id)
        {
            if(id > 0)
                ID = id;
        }
        public void SetTitle(string title)
        {
            if(title != null && title.Length > 0)
            Title = title;
        }
        public void SetAuthor(string author)
        {
            if(author != null && author.Length > 0)
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
        
        public override string ToString()
        {
            return $"Book ID: {ID}, Title: {Title}, Author: {Author}, Available: {IsAvailable} \n";
        }
    }
}
