using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Raiz.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var ruta = @"D:\Trabajos\output\RaizNet\";
            var listaAssy = new List<String>();
            listaAssy.Add("Raiz.Common.CL.dll");
            listaAssy.Add("Raiz.Main.exe");
            listaAssy.Add("Raiz.Modulo1.dll");
            listaAssy.Add("Raiz.Modulo2.dll");
            foreach (var strAssy in listaAssy)
            {
                Console.WriteLine(strAssy);
                Assembly assy = Assembly.ReflectionOnlyLoadFrom(ruta + strAssy);

                var path = assy.Location;
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
                Console.WriteLine(fvi.FileVersion);
                Console.WriteLine(fvi.ProductVersion);

                Console.WriteLine(fvi.ProductMajorPart);
                Console.WriteLine(fvi.ProductMinorPart);
                Console.WriteLine(fvi.ProductBuildPart);
                Console.WriteLine(fvi.ProductPrivatePart);
                Console.WriteLine(fvi.SpecialBuild);
                //var attrs = CustomAttributeData.GetCustomAttributes(assy);
                //foreach (var cad in attrs)
                //{
                //    Console.WriteLine(cad.ToString());
                //}
                
                //Console.WriteLine("RuntimeVersion:{0} - {1}", strAssy, rtv);
            }
            Console.ReadKey();
        }
    }
}
