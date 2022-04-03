using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusev_ITMO_Lab20
{
    class Program
    {
        delegate double GeomDelegate(double R);
        
        static void Main(string[] args)
        {
            double R=0;
            double answer;
            bool inputNotOk=false;
            GeomDelegate myGeomDelegate = new GeomDelegate(CircumferenceCalculation);
           // myGeomDelegate += AreaOfCircleCalculation;
           // myGeomDelegate += VolumeOfSphereCalculation;

            do
            {
                inputNotOk=false;
                Console.Write("Введите значение R: ");
                try
                {
                    R = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputNotOk = true;
                }
            }while(inputNotOk);

            if (myGeomDelegate != null)
            {
                answer = myGeomDelegate(R);
                Console.WriteLine("Длина окружности D = 2 * PI* R = {0:.00}.", answer);
            }
            else
            {
                Console.WriteLine("myGeomDelegate == null");
            }

            myGeomDelegate = AreaOfCircleCalculation;
            if (myGeomDelegate != null)
            {
                answer = myGeomDelegate(R);
                Console.WriteLine("Площадь круга S = PI* R^2 = {0:.00}.", answer);
            }
            else
            {
                Console.WriteLine("myGeomDelegate == null");
            }

            myGeomDelegate = VolumeOfSphereCalculation;
            if (myGeomDelegate != null)
            {
                answer = myGeomDelegate(R);
                Console.WriteLine("Объем шара V = 4/3 * PI * R^3 = {0:.00}.", answer);
            }
            else
            {
                Console.WriteLine("myGeomDelegate == null");
            }

            Console.ReadKey();
        }

        static double CircumferenceCalculation(double R)
        { 
            return(2*Math.PI*R);
        }

        static double AreaOfCircleCalculation(double R)
        { 
            return(Math.PI*Math.Pow(R,2)); 
        }

        static double VolumeOfSphereCalculation(double R)
        {
            return (4*Math.PI*Math.Pow(R,3)/4);
        }
    }
}
