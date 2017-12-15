using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class FileManager
    {
        public delegate void FileFoundHandler();

        public event FileFoundHandler FileFound;

        private event Action _fileNotFound;

        public event Action FileNotFound
        {
            add { _fileNotFound += value; }
            remove { _fileNotFound -= value; }
        }

        public void Search(bool isFound)
        {
            if (isFound)
            {
                OnFileFound();
            } 
            else
            {
                _fileNotFound();
            }
        }

        protected virtual void OnFileFound()
        {
            if (FileFound != null)
            {
                //call event
                FileFound();
            }
        }
    }
}
