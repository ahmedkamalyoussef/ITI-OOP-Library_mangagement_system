# Library Management System (ITI OOP)

A simple console-based Library Management System implemented in C# to demonstrate
object-oriented programming (OOP) principles. The application supports adding,
removing, listing books and members, borrowing and returning books, and displays
available/borrowed books.


Main Features
--
- Add, remove, and list books
- Add, remove, and list library members
- Borrow and return books
- Display available and borrowed books

Project Structure
--
The project is organized into classes to illustrate OOP concepts:

- `Book`: Represents a book with fields such as ID, Title, Author, and Availability.
- `Member`: Represents a library member with fields such as ID, Name, and a list of borrowed books.
- `Library`: Manages collections of books and members and handles operations like borrowing and returning books.
- `Program`: Contains the main menu and console user interaction logic.

Console Usage Examples
--
Below are representative console interactions demonstrating typical operations.

Example: Adding Books and Listing Them

Library Management System
1. Add Book
2. Remove Book
3. Add Member
4. Remove Member
5. Borrow Book
6. Return Book
7. List Books
8. List Members
9. Exit
Select an option: 1
Enter Book ID: 1
Enter Title: The Great Gatsby
Enter Author: F. Scott Fitzgerald
Book 'The Great Gatsby' added successfully.

Example: Borrowing and Returning a Book

Select an option: 3
Enter Member ID: 101
Enter Name: Alice Smith
Member 'Alice Smith' added successfully.

Select an option: 5
Enter Book ID: 1
Enter Member ID: 101
Alice Smith borrowed 'The Great Gatsby'.

Select an option: 6
Enter Book ID: 1
Enter Member ID: 101
Alice Smith returned 'The Great Gatsby'.

Error Handling Examples
--
- Attempting to borrow an already borrowed book shows an error message.
- Selecting an invalid menu option shows an "Invalid option. Try again." message.

Running the Project
--
Requirements: .NET SDK (target framework: net10.0 as in project files).

To run the console application from the repository root:

```bash
cd LibraryManagementSystem
dotnet run
```

Files of interest
--
- LibraryManagementSystem/Classes/Book.cs
- LibraryManagementSystem/Classes/Member.cs
- LibraryManagementSystem/Classes/Library.cs
- LibraryManagementSystem/Program.cs

-------------------------------------------------
|                   Library                     |<-------
-------------------------------------------------       |
| - Books : List<Book>                          |       | 
| - Members : List<Member>                      |       |
-------------------------------------------------       |
| + AddBook(Book)                               |       |
| + RemoveBook(int)                             |       |
| + AddMember(Member)                           |       |
| + RemoveMember(int)                           |       |
| + BorrowBook(int bookId, int memberId)        |       |
| + ReturnBook(int bookId, int memberId)        |       |
| + ListBooks()                                 |       |
| + ListMembers()                               |       |
-------------------------------------------------       |
        |Aggregation (Library owns Books)               |
        |                                               |
        | 1 to many                                     |
        v                                               |
-------------------------------------------------       |
|                    Book                       |       |
-------------------------------------------------       |
| - Id : int                                   |        |
| - Title : string                             |        |
| - Author : string                            |        |
| - IsAvailable : bool                         |        |
-------------------------------------------------       |
| + Book()                                     |        |
| + override ToString() : string               |        |
| + CheckAvailablity()                         |        |                            
-------------------------------------------------       |
        ^ Assosiation (Member borrows Books)            |
        |                                               |
        | many to many                                  |
        |                                               |
-------------------------------------------------       |
|                   Member                     |        | 
-------------------------------------------------       |
| - Id : int                                   |        |
| - Name : string                              |        |
| - BorrowedBooks : List<Book>                 |        |
-------------------------------------------------       |
| + BorrowBook(Book)                           |        |
| + ReturnBook(Book)                           |        | 
| + override ToString() : string               |        |
-------------------------------------------------       |
        |                                               |
        | Aggregation (Library owns Members)            |
        |                                               |
        | 1 to many                                     | 
        ------------------------------------------------

