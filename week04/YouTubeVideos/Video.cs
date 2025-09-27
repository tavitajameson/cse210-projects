using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private string _title;
        private string _author;
        private int _length; // in seconds
        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumComments()
        {
            return _comments.Count;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_length} seconds");
            Console.WriteLine($"Number of Comments: {GetNumComments()}");

            foreach (var comment in _comments)
            {
                Console.WriteLine($"   {comment.GetCommentInfo()}");
            }
            Console.WriteLine();
        }
    }
}
