﻿namespace NETCoreExperimentalWebApp.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }
        public string Image { get; set; }
    }

    public enum BookType
    {
        Board, Electronic, Standard
    }
}