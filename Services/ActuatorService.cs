using DAL.DTO;
using System.Reflection;

namespace Services;

public interface IActuatorService
{
    public Dictionary<string,string> MyInfo();
    public AssemblyInfoDTO GetAssemblyInfo();
    public ServiceInfoDTO[] GetServicesInfo();
}
public class ActuatorService : IActuatorService
{
    public Dictionary<string, string> MyInfo() => new ()
    {
        { "nameApp","Cholecstitis"},
        { "Developer 1","Ilya"},
        { "Developer 2","Arslan"},
    };

    public AssemblyInfoDTO GetAssemblyInfo()
    {
        var assembly = Assembly.GetExecutingAssembly();

        return new AssemblyInfoDTO
        {
            AssemblyName = assembly.FullName,
            AssemblyVersion = assembly.ImageRuntimeVersion
        };
    }

    public ServiceInfoDTO[] GetServicesInfo()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var services = assembly.GetTypes()
            .Where(t=>t.Name.Contains("Service") && t.IsInterface)
            .Select(t=> new ServiceInfoDTO
            {
                Name = t.FullName,
                MethodsNames = t.GetMethods().Select(m => m.Name).ToArray()
            }
            ).ToArray();
        return services;
    }
}
