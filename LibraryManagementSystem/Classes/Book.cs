namespace LibraryManagementSystem
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _author;
        public bool _isAvailable;

        // Constructor to initialize a Book object
        public Book(int id, string title, string author)
        {
            _id = id;
            _title = title;
            _author = author;
            _isAvailable = true;
        }
        //if you needed  access to private members use this
        
        public void SetID(int id)
        {
            if(id > 0)
                _id = id;
        }
        public void SetTitle(string title)
        {
            if(title != null && title.Length > 0)
            _title = title;
        }
        public void SetAuthor(string author)
        {
            if(author != null && author.Length > 0)
                _author = author;
        }


        public int GetID()
        {
            return _id;
        }
        public string GetTitle()
        {
            return _title;
        }
        public string GetAuthor()
        {
            return _author;
        }
        
        public override string ToString()
        {
            return $"Book ID: {_id}, Title: {_title}, Author: {_author}, Available: {_isAvailable} \n";
        }
    }
}
