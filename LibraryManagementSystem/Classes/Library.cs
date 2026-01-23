using System;

namespace LibraryManagementSystem.Classes;

public class Library
{
    private List<Book> books=new List<Book>();
    private List<Member> members=new List<Member>();

    public List<Book> Getbooks()
    {
        return books;
    }
    public List<Member> Getmember()
    {
        return members;
    }
    public void AddBook(Book book)
    {
        foreach (Book b in books)
        {
            if (b.GetID()==book.GetID())
            {
                Console.WriteLine($"book with ID {book.GetID()} already exists.");
                return;
            }
        }
        books.Add(book);
        Console.WriteLine("book is added successful.");
    }
    public void removeBook(Book book)
    {
        //books.Remove(book);
        Book bookToRemove = null;
        foreach (Book b in books)
        {
            if (b.GetID() == book.GetID())
            {
                bookToRemove = b;
                break;
            }
        }
        if (books != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"book{book.GetTitle()} removed successfully");

        }
        else
        {
            Console.WriteLine($"book{book.GetTitle()} not found");
        }
    }

    public void AddMember(Member member)
    {
        foreach (Member m in members)
        {
            if (m.GetID()==member.GetID())
            {
                Console.WriteLine($"member with ID {member.GetID()} already exists.");
                return;
            }
        }
        members.Add(member);
        Console.WriteLine("member is added successful.");
    }
    public void removeMember(Member member)
    {
        //members.Remove(member);
        Member memberremoeve = null;
        foreach (Member m in members)
        {
            if (m.GetID() == member.GetID())
            {
                memberremoeve = m;
                break;
            }
        }
        if (memberremoeve != null)
        {
            members.Remove(memberremoeve);
            Console.WriteLine($"member{member.GetName()} removed successfully");

        }
        else
        {
            Console.WriteLine($"member{member.GetName()} not found");
        }
    }

    //list all books
    public void DisplayBooks()
    {
        Console.WriteLine("=== Books ===");
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
    }
    //list all members
    public void DisplayMembers()
    {
        Console.WriteLine("=== Members ===");
        foreach (Member m in members)
        {
            Console.WriteLine(m);
        }
    }
    //boorrow book
    public void BorrowBook(int memberId, int bookId)
    {
        Member member = null;
        Book book = null;

        foreach (Member m in members)
        {
            if (m.GetID() == memberId)
            {
                member = m;
                break;
            }
        }

        foreach (Book b in books)
        {
            if (b.GetID() == bookId)
            {
                book = b;
                break;
            }
        }

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Book is already borrowed.");
            return;
        }

        book.IsAvailable=false;
        member.AddBook(book);

        Console.WriteLine($"{member.GetName()} borrowed '{book.GetTitle()}'");
    }
    public void ReturnBook(int memberId, int bookId)
    {
        Member member = null;
        Book book = null;

        foreach (Member m in members)
        {
            if (m.GetID() == memberId)
            {
                member = m;
                break;
            }
        }

        foreach (Book b in books)
        {
            if (b.GetID() == bookId)
            {
                book = b;
                break;
            }
        }

        if (member == null || book == null)
        {
            Console.WriteLine("Member or Book not found.");
            return;
        }

        book.IsAvailable=true;
        member.RemoveBook(book);

        Console.WriteLine("Book returned successfully.");
    }

}
