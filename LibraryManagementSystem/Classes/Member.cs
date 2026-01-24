using System;

namespace LibraryManagementSystem.Classes;

public class Member
{
    private int ID;
    private string Name;
    private List<Book> BorrowedBooks = new List<Book>();

    public Member(int ID,string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
    //if you needed  access to private members use this

    public void SetID(int id)
    {
            ID = id;
    }
    public void SetName(string name)
    {
        if (name != null && name.Length > 0)
            Name = name;
    }
  

    public int GetID()
    {
        return ID;
    }
    public string GetName()
    {
        return Name;
    }


    //if you needed  to add book or remove it from BorrowedBooks list
    public void AddBook(Book book)
    {
        BorrowedBooks.Add(book);
    }
    public void RemoveBook(Book book)
    {
         BorrowedBooks.Remove(book);
       
    }
    //if you need to see the BorrowedBooks 

    public int ShowBorrowedBooks()
    {
       return BorrowedBooks.Count();
    }

    public List<Book> GetBorrowedBooks()
    {

        return BorrowedBooks;
    }

}
