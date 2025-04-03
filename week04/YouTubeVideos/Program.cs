using System;
using System.Collections.Generic;

class Comment
{
    public string Username { get; set; }
    public string Text { get; set; }

    public Comment(string username, string text)
    {
        Username = username;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Username}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}\nComments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        Video video1 = new Video("Python Tutorial", "Codeacademy", 600);
        Video video2 = new Video("Data Structures", "TechwithJuan", 1200);
        Video video3 = new Video("OOP in C#", "Programming with Felipe", 900);

        video1.AddComment(new Comment("Alicia", "Great tutorial!"));
        video1.AddComment(new Comment("Nelson", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Loved the explanation."));

        video2.AddComment(new Comment("David", "Can you make one on trees?"));
        video2.AddComment(new Comment("Eva", "This was awesome!"));
        video2.AddComment(new Comment("Franco", "Really clear and concise."));

        video3.AddComment(new Comment("Graciela", "Helped me a lot!"));
        video3.AddComment(new Comment("Javier", "finally makes sense."));
        video3.AddComment(new Comment("Juan", "This was exactly what I needed!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}