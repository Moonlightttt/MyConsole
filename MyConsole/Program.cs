using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWindsorContainer container = new WindsorContainer();
            //container.Register(Component.For<AnimalSay>()
            //    .Named("DOG")
            //    .ImplementedBy<Dog>(),
            //    Component.For<AnimalSay>()
            //    .ImplementedBy<Cat>().IsDefault()
            //);

            //AnimalSay cat = container.Resolve<AnimalSay>(new Castle.MicroKernel.Arguments ( new { Name = "little cat" } ));
            //AnimalSay dog = container.Resolve<AnimalSay>("DOG");

            //cat.Say();
            //dog.Say();
            Expression<Func<Cat, bool>> exp = x => (x.Name == "dog" || x.Name == "cat") && (x.Name != "dog" || x.Name.Contains("cat"));

            var r = new ExpressionResolver();
            r.Visit(exp);
            var s = r.Result;

            //Console.ReadKey();
        }

        public static string MoneyToCap(string money)
        {
            if (string.IsNullOrEmpty(money))
            {
                return "";
            }
            string s = double.Parse(money).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string s1 = double.Parse(money).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[.]|$))))", "${b}${z}");
            string e = Regex.Replace(s1, @"((?<=-|^)[^1-9]*)", "${b}${z}");
            return Regex.Replace(d, ".", (Match m) =>
            {
                return "负圆空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万億兆京垓秭穰"[m.Value[0] - '-'].ToString();
            });
        }
    }
}
