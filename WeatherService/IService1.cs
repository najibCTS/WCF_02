using System.ServiceModel;

namespace WeatherService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double Celciustofarenheit(double temp);
        [OperationContract]
        double Farenheittocelcius(double temp);
    }
}
