using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video v1 = new Video("Intro to C#", "Alice", 600);
            v1.AddComment(new Comment("John", "Very helpful, thanks!"));
            v1.AddComment(new Comment("Sara", "Great explanation."));
            v1.AddComment(new Comment("Mike", "Loved it!"));

            Video v2 = new Video("Design Patterns", "Bob", 1200);
            v2.AddComment(new Comment("Emma", "Clear and concise."));
            v2.AddComment(new Comment("Liam", "Can you do Singleton next?"));
            v2.AddComment(new Comment("Olivia", "Amazing tutorial."));

            Video v3 = new Video("OOP in C#", "Charlie", 900);
            v3.AddComment(new Comment("Sophia", "This really helped."));
            v3.AddComment(new Comment("James", "Can you explain interfaces more?"));
            v3.AddComment(new Comment("Mason", "Perfect for beginners."));

            videos.Add(v1);
            videos.Add(v2);
            videos.Add(v3);

            foreach (var video in videos)
            {
                video.DisplayInfo();
            }
        }
    }
}
