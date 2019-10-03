namespace WeatherService
{
    public class Service1 : IService1
    {
        public double Celciustofarenheit(double temp)
        {
            return (temp * 9) / 5 + 32;
        }
        public double Farenheittocelcius(double temp)
        {
            return (temp - 32) * 5 / 9;
        }
    }
}
