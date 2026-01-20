using System;

namespace LibraryManagementSystem.Classes;

public class Member(string name)
{
    public Guid Id = new();
    public string Name = name;
    public List<Book> BarrowedBooks = [];

    public override string ToString()
    {
        return $"{Name} with {BarrowedBooks.Count} barrowed books";
    }
}
