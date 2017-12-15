using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text:file.txt(6B);Some string content
                            Image:img.bmp(19MB);1920x1080
                            Text:data.txt(12B);Another string
                            Text:data1.txt(7B);Yet another string
                            Movie:logan.2017.mkv(19GB);1920x1080;2h12m";
            #region
            //var textFile = new TextFile
            //{
            //    Name = "file.txt",
            //    Extension = "txt",
            //    Size = 6,
            //    Content = "Some string content"
            //};
            //Console.WriteLine(textFile);

            //var movie = new Movie
            //{
            //    Name = "logan.2017.mkv",
            //    Extension = "mkv",
            //    Size = 19,
            //    Resolution = "1920x1080",
            //    Length = "2h12m"
            //};
            //Console.WriteLine(movie);

            //var image = new Image
            //{
            //    Name = "img.bmp",
            //    Extension = "bmp",
            //    Size = 19,
            //    Resolution = "1920x1080"
            //};
            //Console.WriteLine(image);
            #endregion
            string[] files = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in files)
            {
                if (item.Contains("Text:"))
                {
                    var textFile = new TextFile
                    {
                        Name = item.Substring(item.IndexOf(':') + 1, 8),
                        Extension = item.Substring(item.IndexOf('.') + 1, 3),
                        Size = int.Parse(item.Substring(item.IndexOf('(') + 1, 1)),
                        Content = item.Substring(item.IndexOf(';') + 1)
                    };
                    Console.WriteLine(textFile);
                }
                if (item.Contains("Movie:"))
                {
                    var movie = new Movie
                    {
                        Name = item.Substring(item.IndexOf(':') + 1, 8),
                        Extension = item.Substring(item.IndexOf('.') + 1, 3),
                        Size = int.Parse(item.Substring(item.IndexOf('(') + 1, 1)),
                        Resolution = item.Substring(item.IndexOf(';') + 9),
                        Length = item.Substring(item.IndexOf(';'))
                    };
                    Console.WriteLine(movie);
                }
                if (item.Contains("Image:"))
                {
                    var image = new Image
                    {
                        Name = item.Substring(item.IndexOf(':') + 1, 8),
                        Extension = item.Substring(item.IndexOf('.') + 1, 3),
                        Size = int.Parse(item.Substring(item.IndexOf('(') + 1, 1)),
                        Resolution = item.Substring(item.IndexOf(';') + 1)
                    };
                    Console.WriteLine(image);
                }
            }

            Console.ReadKey();
        }
    }
}
