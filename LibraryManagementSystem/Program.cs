using LibraryManagementSystem;
using LibraryManagementSystem.Classes;
using LibraryManagementSystem.Statics;

Library library = new Library();

while (true)
{
    Console.WriteLine("\nLibrary Management System");
    Console.WriteLine((int)Options.AddBook + ". Add Book");
    Console.WriteLine((int)Options.RemoveBook + ". Remove Book");
    Console.WriteLine((int)Options.AddMember + ". Add Member");
    Console.WriteLine((int)Options.RemoveMember + ". Remove Member");
    Console.WriteLine((int)Options.BorrowBook + ". Borrow Book");
    Console.WriteLine((int)Options.ReturnBook + ". Return Book");
    Console.WriteLine((int)Options.ListBooks + ". List Books");
    Console.WriteLine((int)Options.ListMembers + ". List Members");
    Console.WriteLine((int)Options.Exit + ". Exit");
    Console.Write("Select an option: ");

    string? input = Console.ReadLine();
    if (!int.TryParse(input, out int option))
    {
        Console.WriteLine("Invalid option. You should enter a number between 1 and 9.");
        continue;
    }

    switch (option)
    {
        case (int)Options.AddBook:
            int bookId = ReadInt("Enter Book ID (0 to cancel): ");
            if (bookId == 0) break;

            if (library.Getbooks().Any(b => b.GetID() == bookId))
            {
                Console.WriteLine($"Book with ID {bookId} already exists.");
                continue;
            }

            string title = ReadString("Enter Title: ");
            string author = ReadString("Enter Author: ");

            library.AddBook(new Book(bookId, title, author));
            // Console.WriteLine($"Book '{title}' added successfully.");
            break;

        case (int)Options.RemoveBook:
            int remBookId = ReadInt("Enter Book ID to remove (0 to cancel): ");
            if (remBookId == 0) break;

            Book? bookToRemove = library.Getbooks().FirstOrDefault(b => b.GetID() == remBookId);
            if (bookToRemove == null)
            {
                Console.WriteLine("Book not found.");
                break;
            }

            library.removebook(bookToRemove);
            //Console.WriteLine($"Book '{bookToRemove.GetTitle()}' removed successfully.");
            break;

        case (int)Options.AddMember:
            int memberId = ReadInt("Enter Member ID (0 to cancel): ");
            if (memberId == 0) break;

            if (library.Getmember().Any(m => m.GetID() == memberId))
            {
                Console.WriteLine($"Member with ID {memberId} already exists.");
                break;
            }

            string name = ReadString("Enter Name: ");

            library.AddMember(new Member(memberId, name));
            // Console.WriteLine($"Member '{name}' added successfully.");
            break;

        case (int)Options.RemoveMember:
            int remMemberId = ReadInt("Enter Member ID to remove (0 to cancel): ");
            if (remMemberId == 0) break;

            Member? memberToRemove = library.Getmember().FirstOrDefault(m => m.GetID() == remMemberId);
            if (memberToRemove == null)
            {
                Console.WriteLine("Member not found.");
                break;
            }

            library.removemember(memberToRemove);
            // Console.WriteLine($"Member '{memberToRemove.GetName()}' removed successfully.");
            break;

        case (int)Options.BorrowBook:
            int borrowBookId = ReadInt("Enter Book ID to borrow (0 to cancel): ");
            if (borrowBookId == 0) break;

            int borrowMemberId = ReadInt("Enter Member ID (0 to cancel): ");
            if (borrowMemberId == 0) break;

            library.BorrowBook(borrowMemberId, borrowBookId);
            break;

        case (int)Options.ReturnBook:
            int returnBookId = ReadInt("Enter Book ID to return (0 to cancel): ");
            if (returnBookId == 0) break;

            int returnMemberId = ReadInt("Enter Member ID (0 to cancel): ");
            if (returnMemberId == 0) break;

            library.ReturnBook(returnMemberId, returnBookId);
            break;

        case (int)Options.ListBooks:
            Console.WriteLine("Books in Library:");
            foreach (Book b in library.Getbooks())
            {
                Console.WriteLine($"ID: {b.GetID()}, Title: {b.GetTitle()}, Author: {b.GetAuthor()}, Available: {b.IsAvailable}");
            }
            break;

        case (int)Options.ListMembers:
            Console.WriteLine("Library Members:");

            foreach (Member m in library.Getmember())
            {
                List<Book> books = m.GetBorrowedBooks();

                Console.Write($"ID: {m.GetID()}, Name: {m.GetName()}, ");

                if (books.Count == 0)
                {
                    Console.WriteLine("Borrowed Books: 0");
                }
                else
                {
                    Console.Write($"Borrowed Books: {books.Count} (");

                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.Write(books[i].GetTitle());

                        if (i < books.Count - 1)
                            Console.Write(", ");
                    }

                    Console.WriteLine(")");
                }
            }
            break;

        case (int)Options.Exit:
            return;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}

static int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value))
        {
            if (value == 0) return 0;
            if (value > 0) return value;

            Console.WriteLine("Please enter a positive number or 0 to cancel.");
        }
        else
        {
            Console.WriteLine("Invalid input. Enter a number or 0 to go back.");
        }
    }
}

static string ReadString(string prompt)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(prompt);
        Console.ResetColor();
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Invalid input. Enter a non-empty string.");
        Console.ResetColor();
    }
}
