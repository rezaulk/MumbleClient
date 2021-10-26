

using Murmur;

namespace Mumble
{
    public interface IMumbleServerClient
    {
        public Instance GetMumbleIceServerInstance();
        bool IsConnected { get; }
        bool CreateInstance();
    }
}
