using System;

namespace WeatherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            double degree = 0.0;
            double result = 0.0;
            ServiceReference1.Service1Client svcClinet = new ServiceReference1.Service1Client();

            Console.WriteLine("Enter Temperature in Celcius: ");
            degree = Convert.ToDouble(Console.ReadLine());
            result = svcClinet.Celciustofarenheit(degree);
            Console.WriteLine("Result in Farenheight: " + result);

            Console.WriteLine("------------------------------------");

            Console.WriteLine("Enter Temperature in Farenheight: ");
            degree = Convert.ToDouble(Console.ReadLine());
            result = svcClinet.Farenheittocelcius(degree);
            Console.WriteLine("Result in Celcius: " + result);

            Console.ReadKey();
        }
    }
}
