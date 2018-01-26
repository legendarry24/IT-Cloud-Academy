using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Create code");
        }

        public void SaveCode()
        {
            Console.WriteLine("Save code");
        }
    }

    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compile");
        }
    }

    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Execute");
        }

        public void Finish()
        {
            Console.WriteLine("Finished");
        }
    }

    class VisualStudio
    {
        TextEditor editor;
        CLR clr;
        Compiler compiler;

        public VisualStudio()
        {
            editor = new TextEditor();
            clr = new CLR();
            compiler = new Compiler();
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }

    class Developer
    {
        VisualStudio _visualStudio;

        public Developer(VisualStudio visualStudio)
        {
            _visualStudio = visualStudio;
        }
        public void CreateApplication()
        {

        }
    }
}
