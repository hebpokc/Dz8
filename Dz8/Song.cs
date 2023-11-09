using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz8
{
    class Song
    {
        string _name;
        string _author;
        Song _prev;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        public Song Prev
        {
            get
            {
                return _prev;
            }
            set
            {
                _prev = value;
            }
        }
        public Song(string name, string author, Song prev)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }
        public Song()
        {
            Name = "Неизвестная песня";
            Author = "Неизвестный исполнитель";
            Prev = null;
        }
        public string Title()
        {
            return $"\nНазвание песни: {Name}\nИсполнитель: {Author}";
        }
        public override bool Equals(object obj)
        {
            return this.Name == (obj as Song).Name && this.Author == (obj as Song).Author;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
