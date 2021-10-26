using MurmurCommon;
using System;

namespace Mumble
{
    public class MumbleServerClient : IMumbleServerClient
    {
  //      private readonly SentraServerConfig _sentraServerConfig;
        private Instance _mumbleIceServerInstance = null;
        public MumbleServerClient()
        {
           // _sentraServerConfig = mumbleServerConfig;
            CreateInstance();
        }

        public bool CreateInstance()
        {
            try
            {
                _mumbleIceServerInstance = new Adapter("1.2.9").Instance;
                //_mumbleIceServerInstance.Connect(_sentraServerConfig.Address, _sentraServerConfig.Port, _sentraServerConfig.Secret, _sentraServerConfig.CallbackAddress, _sentraServerConfig.CallbackPort);
                _mumbleIceServerInstance.Connect("18.184.39.143", 6502, "NybSys123!", "127.0.0.1", 1);
            }
            catch (ConnectionRefusedException e1)
            {
                Console.WriteLine("Could not connect");
           //     Console.WriteLine("Server address: " + _sentraServerConfig.Address + ". Port:  " + _sentraServerConfig.Port + ". Secret: " + _sentraServerConfig.Secret + ". Callbackaddress: " + _sentraServerConfig.CallbackAddress + ". Callbackport: " + _sentraServerConfig.CallbackPort);

            }
            catch (InvalidSecretException e2)
            {
                Console.WriteLine("Wrong Ice secret");
            }
            catch (Exception e3)
            {
                Console.WriteLine(e3.Message);
            }

            return true;
        }

        public bool IsConnected
        {
            get
            {
                return _mumbleIceServerInstance.IsConnected();
            }
        }

        public Instance GetMumbleIceServerInstance()
        {
            //return _mumbleIceServerInstance;
            try
            {
                //if (!_mumbleIceServerInstance.IsConnected())
                //{
                //    CreateInstance();
                //}
                return _mumbleIceServerInstance;
            }
            catch (Exception ex)
            {
                throw new Exception("Sentra Server Failed!");
            }

        }
    }
}
