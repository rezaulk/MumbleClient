
using MurmurCommon;

namespace Mumble
{
    public class Adapter
    {
        public Instance Instance;  // duck tap

        public Adapter(string version)
        {
            init(new MurmurVersion(version));
        }

        public Adapter(MurmurVersion version)
        {
            init(version);
        }

        private void init(MurmurVersion version)
        {
            var assemblyName = MurmurVersion.GetFileNameFromVersion(version.ToString());
           // Assembly assembly = Assembly.LoadFrom(assemblyName);

            // below for ducktap
            //Type T = assembly.GetType("Murmur.Instance");
            //Instance = (IInstance)Activator.CreateInstance(T);

            // test 1 
            Instance = new Instance();

        }
    }
}
