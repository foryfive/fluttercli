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
            string plantillaStateLessWidget = File.ReadAllText(rutaBaseApp + "//Plantillas/StateLessWidget.txt");

            if (args.Length == 0)
            {
                Console.WriteLine("FLUTTER CLI V1.0.0");
                return;
            }

            var read = args[0].ToLower();

            switch (read)
            {
                case "--help":
                case "-help":
                case "-h":
                case "--h":
                    {
                        Write("Command");
                        Write("generate | create widget/servicios");
                        Write("generate statefullwidget NameWidget | add new StateFullWidget");
                        Write("generate statelesswidget NameWidget | add new StateLessWidget");
                        break;
                    }
                case "generate":
                case "g":
                    {
                        var opt = "";
                        var nameWidget = "";
                        if (args.Length > 1)
                        {
                            opt = args[1].ToLower();

                            if (args.Length > 2)
                                nameWidget = args[2];
                        }
                        else
                        {
                            MenuGenerateWidget();
                            opt = Console.ReadLine().ToString();
                        }

                        switch (opt)
                        {
                            case "1":
                            case "statefullwidget":
                            case "sfullwidget":
                            case "sfw":
                            case "fullwidget":
                            case "fullw":
                                {
                                    if (nameWidget == "")
                                    {
                                        Write("Nombre StateFullWidget");
                                        nameWidget = Console.ReadLine();
                                    }

                                    var dartDocument = plantillaStateFullWidget.Replace("ReemplazarNombre", ConvertToFirtWordMayus(nameWidget));
                                    if (Directory.Exists("lib"))
                                        File.WriteAllText("lib/" + nameWidget.ToLower() + ".dart", dartDocument);
                                    else
                                        File.WriteAllText(nameWidget.ToLower() + ".dart", dartDocument);

                                    break;
                                }
                            case "2":
                            case "statelesswidget":
                            case "slesswidget":
                            case "slw":
                            case "lesswidget":
                            case "lessw":
                                {
                                    if (nameWidget == "")
                                    {
                                        Write("Nombre StateLessWidget");
                                        nameWidget = Console.ReadLine();
                                    }

                                    var dartDocument = plantillaStateLessWidget.Replace("ReemplazarNombre", ConvertToFirtWordMayus(nameWidget));
                                    if (Directory.Exists("lib"))
                                        File.WriteAllText("lib/" + nameWidget.ToLower() + ".dart", dartDocument);
                                    else
                                        File.WriteAllText(nameWidget.ToLower() + ".dart", dartDocument);

                                    break;
                                }

                        }
                        break;
                    }
                default:
                    {
                        Write("Comando incompleto");
                        Write("para ver el menú de ayuda -> fluttercli --help");
                        break;
                    }
            }

        }

        static void MenuGenerateWidget()
        {
            Write("1 - StateFullWidget");
            Write("2 - StateLessWidget");
        }

        static void Write(string value)
        {
            Console.WriteLine(value);
        }

        static string ConvertToFirtWordMayus(string value)
        {
            string result = string.Empty;
            string lowerValue = value.ToLower();

            if (lowerValue.Length > 0)
            {
                result = lowerValue[0].ToString().ToUpper();
                if (lowerValue.Length > 1)
                    result += lowerValue.Substring(1, lowerValue.Length - 1);
            }

            return result;
        }
    }
}
