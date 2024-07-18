using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>
        {
            new Video("Learning C# Basics", "John Doe", 300),
            new Video("Advanced C# Programming", "Jane Smith", 600),
            new Video("C# Design Patterns", "Bob Johnson", 450)
        };

        videos[0].AddComment(new Comment("User1", "Great video!"));
        videos[0].AddComment(new Comment("User2", "Very informative."));
        videos[0].AddComment(new Comment("User3", "Thanks for sharing!"));

        videos[1].AddComment(new Comment("User4", "Amazing content."));
        videos[1].AddComment(new Comment("User5", "Loved it!"));
        videos[1].AddComment(new Comment("User6", "Good job."));

        videos[2].AddComment(new Comment("User7", "This helped a lot."));
        videos[2].AddComment(new Comment("User8", "Awesome video."));
        videos[2].AddComment(new Comment("User9", "Well explained."));

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
