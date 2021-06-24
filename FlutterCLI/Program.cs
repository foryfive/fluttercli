using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FlutterCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string version = "v1.0.0";
            string rutaBaseApp = Path.GetDirectoryName(Application.ExecutablePath);
            string plantillaStateFullWidget = File.ReadAllText(rutaBaseApp + "//Plantillas/StateFullWidget.txt");

            if (args.Length == 0)
            {
                Console.WriteLine("FLUTTER CLI V1.0.0");
                return;
            }

            var read = args[0];

            switch (read)
            {
                case "generate":
                case "g":
                    {
                        MenuGenerate();
                        var opt = Console.ReadLine().ToString();
                        switch (opt)
                        {
                            case "1":
                                {
                                    Write("Nombre StateFullWidget");
                                    var nombreWidget = Console.ReadLine();
                                    var dartDocument = plantillaStateFullWidget.Replace("ReemplazarNombre", ConvertToFirtWordMayus(nombreWidget));
                                    if (Directory.Exists("lib"))
                                        File.WriteAllText("lib/" + nombreWidget.ToLower() + ".dart", dartDocument);
                                    else
                                        File.WriteAllText(nombreWidget.ToLower() + ".dart", dartDocument);

                                    break;
                                }

                        }
                        break;
                    }
            }

        }

        static void MenuGenerate()
        {
            Write("1 - StateFullWidget");
            Write("2 - Service");
        }

        static void Write(string value)
        {
            Console.WriteLine(value);
        }
        static string ConvertToFirtWordMayus(string value)
        {
            string result = string.Empty;
            string lowerValue = value.ToLower();

            if(lowerValue.Length > 0)
            {
                result = lowerValue[0].ToString();
                if (lowerValue.Length > 1)
                    result += lowerValue.Substring(1, lowerValue.Length);
            }

            return result;
        }
    }
}
