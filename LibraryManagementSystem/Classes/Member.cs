using System;

namespace LibraryManagementSystem.Classes;

public class Member
{
    private int _id;
    private string _name;
    private List<Book> _borrowedBooks = new List<Book>();

    public Member(int id,string name)
    {
        this._id = id;
        this._name = name;
    }
    //if you needed  access to private members use this

    public void SetID(int id)
    {
            _id = id;
    }
    public void SetName(string name)
    {
        if (name != null && name.Length > 0)
            _name = name;
    }
  

    public int GetID()
    {
        return _id;
    }
    public string GetName()
    {
        return _name;
    }


    //if you needed  to add book or remove it from BorrowedBooks list
    public void AddBook(Book book)
    {
        _borrowedBooks.Add(book);
    }
    public void RemoveBook(Book book)
    {
         _borrowedBooks.Remove(book);
       
    }
    //if you need to see the BorrowedBooks 

    public int ShowBorrowedBooks()
    {
       return _borrowedBooks.Count();
    }

    public List<Book> GetBorrowedBooks()
    {

        return _borrowedBooks;
    }

}
