// (c) 2017 HarpyWar (harpywar@gmail.com))
// This code is licensed under MIT license (see LICENSE for details)

namespace MurmurCommon
{
    public interface IInstanceCallbackHandler
    {
        void Started(IVirtualServer server);
        void Stopped(IVirtualServer server);
    }
}