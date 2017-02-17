

namespace SmartHomeSystems
{
    public interface ISystem { }
    public abstract class LightSystem : ISystem { }
    public abstract class SecuritySystem : ISystem{ }
    public abstract class TemperatureSystem : ISystem { }
    public abstract class PowerSystem : ISystem { }
    public abstract class Appliance : ISystem { }
}