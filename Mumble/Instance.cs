// (c) 2017 HarpyWar (harpywar@gmail.com))
// This code is licensed under MIT license (see LICENSE for details)

using Murmur;
using MurmurCommon;
using Sentra.PTT.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mumble
{
    public partial class Instance : IInstance, IDisposable
    {
        private SerializableDictionary<int, IVirtualServer> _servers = new SerializableDictionary<int, IVirtualServer>();


        private IceClient _client;
        private MetaPrx _meta;
        private Ice.ObjectAdapter _adapter;

        internal MetaPrx Meta
        {
            get
            {
                return _meta;
            }
        }
        internal Ice.ObjectAdapter Adapter
        {
            get
            {
                return _adapter;
            }
        }



        public void Connect(string address, int port = 6502, string secret = "", string callbackAddress = "127.0.0.1", int callbackPort = 0, int timeout = 1000)
        {
            _address = address;
            _port = port;
            _callbackAddress = callbackAddress;
            _callbackPort = callbackPort;
            _client = new IceClient();
            _client.Connect(address, port, secret, callbackAddress, callbackPort, timeout);
            _meta = _client.Meta;
            _adapter = _client.Adapter;
        }


        public string Address
        {
            get
            {
                return _address;
            }
        }
        private string _address;
        public int Port
        {
            get
            {
                return _port;
            }
        }
        private int _port;

        public string CallbackAddress
        {
            get
            {
                return _callbackAddress;
            }
        }
        private string _callbackAddress;

        public int CallbackPort
        {
            get
            {
                return _callbackPort;
            }
        }
        private int _callbackPort;


        /// <summary>
        /// Return all servers
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public SerializableDictionary<int, IVirtualServer> GetAllServers(bool cache = false)
        {
            try
            {
                // clear 
                //  (it's needed to update one time to cache)
                if (_isNewAllServers || !cache)
                {
                    _isNewAllServers = false;

                    // add to cache
                    foreach (var s in _meta.getAllServers())
                    {
                        var vs = new VirtualServer(s, this);
                        if (!_servers.ContainsKey(vs.Id))
                            _servers.Add(vs.Id, vs);
                    }
                }

                return _servers;
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }
        }

        public Dictionary<int, Channel> GetChannels()
        {
            try
            {
                var server = _meta.getServer(1);
                return server.getChannels();
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }
        }

        public int CreateChannel(int serverID, string channelName, int parentId = 0)
        {
            try
            {
                var server = _meta.getServer(serverID);
                return server.addChannel(channelName, parentId);
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }

        public void GetChannel(int id = 0)
        {
            try
            {
                // clear 
                //  (it's needed to update one time to cache)
                if (_isNewAllServers)
                {
                    _isNewAllServers = false;

                    // add to cache
                    foreach (var s in _meta.getAllServers())
                    {
                        var vs = new VirtualServer(s, this);
                        if (!_servers.ContainsKey(vs.Id))
                            _servers.Add(vs.Id, vs);
                    }
                }

                //_meta.getServer(1);

                // return _servers;
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }

        public int RegisterUser(Dictionary<VirtualServerEntity.User.UserInfo, string> userInfo)
        {
            try
            {
                var server = _meta.getServer(1);

                Dictionary<UserInfo, string> userMap = new Dictionary<UserInfo, string>();

                string userName = string.Empty;
                string userPassword = string.Empty;
                userInfo.TryGetValue(VirtualServerEntity.User.UserInfo.UserName, out userName);
                userInfo.TryGetValue(VirtualServerEntity.User.UserInfo.UserPassword, out userPassword);

                userMap.Add(UserInfo.UserName, userName);
                userMap.Add(UserInfo.UserPassword, userPassword);


                return server.registerUser(userMap);

                //Dictionary<MurmurPlugin.VirtualServerEntity.User.UserInfo, string> userMap = new Dictionary<MurmurPlugin.VirtualServerEntity.User.UserInfo, string>();

                //userMap.Add(MurmurPlugin.VirtualServerEntity.User.UserInfo.UserName, "JafarIceUser");
                //userMap.Add(MurmurPlugin.VirtualServerEntity.User.UserInfo.UserPassword, "abc");
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }

        //public Dictionary<int, VirtualServerEntity.User> GetUsers()
        //{
        //    var server = _meta.getServer(1);
        //    Dictionary<int, Murmur.User> userList = server.getUsers();
        //}

        private bool _isNewAllServers = true;

        /// <summary>
        /// Get one server
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="cache"></param>
        /// <returns>throws KeyNotFoundException if server not found</returns>
        public IVirtualServer GetServer(int serverId, bool cache = false)
        {
            try
            {
                if (!cache || !_servers.ContainsKey(serverId))
                {
                    //Code by Md. Foyjul Bary
                    if (_meta == null)
                    {
                        throw new KeyNotFoundException();
                    }

                    var server = _meta.getServer(serverId);
                    if (server == null)
                        throw new KeyNotFoundException();

                    var vs = new VirtualServer(server, this);

                    // add to cache
                    if (!_servers.ContainsKey(serverId))
                        _servers.Add(serverId, vs);
                    else
                        _servers[serverId] = vs;
                }

                return _servers[serverId];
            }
            catch (Exception ex)
            {
                throw new MumbleException("Sentra Server Failed!");
            }
        }

        /// <summary>
        /// Create new server
        /// </summary>
        /// <param name="slots"></param>
        /// <param name="port">if port == 0 then random port will be used</param>
        /// <returns></returns>
        public IVirtualServer CreateServer(int slots = 10, int port = 0)
        {
            try
            {
                // add server on remote side
                var server = _meta.newServer();

                var vs = new VirtualServer(server, this);

                // setup server
                vs.Port = (port == 0) ? GetNextAvailablePort() : port;
                vs.Slots = slots;

                // add to cache
                _servers.Add(vs.Id, vs);

                return vs;
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }

        /// <summary>
        /// Delete the server
        /// If something wrong exception will be thrown
        /// </summary>
        public void DeleteServer(int serverId)
        {
            try
            {
                var server = _meta.getServer(serverId);

                // delete on remote side
                server.delete();

                // remove from cache
                if (_servers.ContainsKey(serverId))
                    _servers.Remove(serverId);
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }


        /// <summary>
        /// Return version on Murmur
        /// </summary>
        /// <returns></returns>
        public string GetVersionString()
        {
            try
            {
                if (_version == null)
                {
                    int major = 0, minor = 0, patch = 0;
                    _meta.getVersion(out major, out minor, out patch, out _version);
                    //return string.Format("{0}.{1}.{2}", major, minor, patch);
                }
                return _version;
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }
        private string _version;

        /// <summary>
        /// Return version string of Murmur122.ice
        /// </summary>
        /// <returns></returns>
        public static string GetIceVersionString()
        {
            try
            {
                // assembly file version   
                var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
                return assemblyVersion.ToString();
            }
            catch (Exception)
            {
                throw new MumbleException("Sentra Server Failed!");
            }

        }

        /// <summary>
        /// Check connection is estabilished or not
        /// </summary>
        public bool IsConnected()
        {
            try
            {
                _meta.ice_ping();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Default config values (always cached)
        /// </summary>
        /// <returns></returns>
        public SerializableDictionary<string, string> GetDefaultConf()
        {
            if (_defaultConf != null)
                return _defaultConf;

            _defaultConf = new SerializableDictionary<string, string>();
            foreach (var c in _meta.getDefaultConf())
            {
                _defaultConf.Add(c.Key, c.Value);
            }
            return _defaultConf;
        }
        private SerializableDictionary<string, string> _defaultConf = null;


        /// <summary>
        /// Return next available server port
        /// </summary>
        /// <returns></returns>
        public int GetNextAvailablePort()
        {
            int defaultPort = int.Parse(GetDefaultConf()["port"]);
            var lastId = GetAllServers().Last().Key;

            int port = 0;
            // countdown lastId value while it not found 
            while (port == 0)
            {
                // increase port to (base port + max sever id)
                int newPort = (defaultPort + lastId);

                // if port greater then 65535, then move port number in the opposite direction
                if (newPort > ushort.MaxValue)
                    newPort = ushort.MaxValue - (newPort - defaultPort);

                // check port for availability (it should be closed)
                if (!Helper.IsPortOpened(Address, newPort, 2))
                {
                    port = newPort;
                    break;
                }
                lastId++;
            }
            return port;
        }

        #region CALLBACKS

        //private Dictionary<string, MetaCallbackPrx> callbacks = new Dictionary<string, MetaCallbackPrx>();

        //public string AddCallback(IInstanceCallbackHandler callback)
        //{
        //    if (_client == null)
        //    {
        //        throw new InsufficientExecutionStackException("You have to Connect() before add AddCallback()");
        //    }
        //    var callbackWrapper = new InstanceCallbackWrapper(this, callback);

        //    // Create identity and callback for Metaserver
        //    var key = Guid.NewGuid().ToString();
        //    var meta_callback = MetaCallbackPrxHelper.checkedCast(_adapter.add(callbackWrapper, new Ice.Identity(key, "")));
        //    _meta.addCallback(meta_callback);

        //    callbacks.Add(key, meta_callback);
        //    return key;
        //}


        //public KeyValuePair<string, ServerCallbackPrx> AddVirtualServerCallback(IVirtualServerCallbackHandler callback, VirtualServer vs)
        //{
        //    var callbackWrapper = new VirtualServerCallbackWrapper(vs, callback);

        //    // Create identity and callback for Virtual server
        //    var key = Guid.NewGuid().ToString();
        //    var server_callback = ServerCallbackPrxHelper.checkedCast(_adapter.add(callbackWrapper, new Ice.Identity(key, "")));
        //    vs.Server.addCallback(server_callback);
        //    return new KeyValuePair<string, ServerCallbackPrx>(key, server_callback);
        //}

        //internal KeyValuePair<string, ServerContextCallbackPrx> AddVirtualServerContextCallback(int session, string action, string title, IVirtualServerContextCallbackHandler callback, int ctx, VirtualServer vs)
        //{
        //    var callbackWrapper = new VirtualServerContextCallbackWrapper(vs, callback);

        //    // Create identity and callback for Virtual server
        //    var key = Guid.NewGuid().ToString();
        //    var server_context_callback = ServerContextCallbackPrxHelper.checkedCast(_adapter.add(callbackWrapper, new Ice.Identity(key, "")));
        //    vs.Server.addContextCallback(session, action, title, server_context_callback, ctx);
        //    return new KeyValuePair<string, ServerContextCallbackPrx>(key, server_context_callback);
        //}


        ///// <summary>
        ///// Remove instance callback by id
        ///// </summary>
        ///// <param name="id">If id == null then remove all callbacks</param>
        //public void RemoveCallback(string id = null)
        //{
        //    foreach (var c in callbacks)
        //    {
        //        if (id != null && id != c.Key)
        //        {
        //            continue;
        //        }
        //        _meta.removeCallback(c.Value);
        //    }
        //}

        public List<LogEntry> GetServerLogs(int serverID)
        {
            List<LogEntry> lstLogEntry = new List<LogEntry>();

            try
            {
                var server = _meta.getServer(serverID);
                int count = 50;

                List<LogEntry> logList = server.getLog(0, count).ToList();
                lstLogEntry.AddRange(logList);

                while (logList.Count == 50)
                {
                    count += 50;
                    logList = server.getLog(0, count).ToList();
                    lstLogEntry.AddRange(logList);
                }
            }
            catch (Exception ex)
            {
                lstLogEntry = null;
            }
            return lstLogEntry;
        }

        public List<Ban> GetBanUsers(int serverID)
        {
            List<Ban> lstBan = new List<Ban>();
            try
            {
                var server = _meta.getServer(serverID);
                lstBan = server.getBans().ToList();
            }
            catch (Exception ex)
            {
                lstBan = null;
            }
            return lstBan;
        }

        public string GetServerConfiguration(string serverkey)
        {
            string configuration = string.Empty;
            try
            {
                var server = _meta.getServer(1);
                configuration = server.getConf(serverkey);
            }
            catch (Exception ex)
            {
                configuration = string.Empty;
            }
            return configuration;
        }

        public bool SetConfigurationUser(int serverID, string serverkey, int numberOfUser)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.setConf(serverkey, numberOfUser.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        public bool SendMessage(int serverID, int userSession, string message)
        {
            try
            {
                var server = GetServer(serverID);
                server.SendMessage(userSession, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool SendMessageToChannel(int serverID, int channelID, string message)
        {
            try
            {
                var server = GetServer(serverID);
                server.SendMessageChannel(channelID, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        public bool SetSuperUserPassword(int serverID, string password)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.setSuperuserPassword(password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        #endregion


        #region hannan vai
        public bool MuteUser(IVirtualServer server, VirtualServerEntity.OnlineUser onlineUser)
        {
            try
            {
                onlineUser.Mute = true;
                //onlineUser.Supress = true;
                server.UpdateUserState(onlineUser);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UnmuteUser(IVirtualServer server, VirtualServerEntity.OnlineUser onlineUser)
        {
            try
            {
                onlineUser.Mute = false;
                //onlineUser.Supress = false;
                server.UpdateUserState(onlineUser);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UnDeafUser(IVirtualServer server, VirtualServerEntity.OnlineUser onlineUser)
        {
            try
            {
                onlineUser.Deaf = false;
                //onlineUser.Supress = false;
                server.UpdateUserState(onlineUser);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeafUser(IVirtualServer server, VirtualServerEntity.OnlineUser onlineUser)
        {
            try
            {
                onlineUser.Deaf = true;
                //onlineUser.Supress = false;
                server.UpdateUserState(onlineUser);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SetUserState(int serverID, VirtualServerEntity.OnlineUser onlineUser)
        {
            try
            {
                var server = GetServer(serverID);
                server.UpdateUserState(onlineUser);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SetState(int serverID, User user)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.setState(user);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool HasPermission(int serverID, int session, int channelID, int prem)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.hasPermission(session, channelID, prem);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool EffectivePermission(int serverID, int session, int channelID)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.effectivePermissions(session, channelID);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Channel GetChannenlState(int serverID, int channelID)
        {
            Channel channel = new Channel();
            try
            {
                var server = _meta.getServer(1);
                channel = server.getChannelState(channelID);
            }
            catch (Exception ex)
            {
                return null;
            }
            return channel;
        }

        public User GetState(int serverID, int sessionID)
        {
            User user = new User();
            try
            {
                var server = _meta.getServer(serverID);
                user = server.getState(sessionID);
            }
            catch (Exception ex)
            {
                return null;
            }
            return user;
        }

        public bool SetACL(int serverID, int channelID, List<ACL> acls, List<Group> groups, bool inherit)
        {
            try
            {
                var server = _meta.getServer(1);
                server.setACL(channelID, acls.ToArray(), groups.ToArray(), inherit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool AddUserToGroup(int serverID, int channelID, int sessionID, string group)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.addUserToGroup(channelID, sessionID, group);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        public bool RemoveUserFromGroup(int serverID, int channelID, int sessionID, string group)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.removeUserFromGroup(channelID, sessionID, group);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public void RemoveVirtualServerCallback(VirtualServer vs, string key)
        {
            vs.RemoveCallback(key);
        }

        public bool RedirectWhisperGroup(int serverID, int sessionID, string source, string target)
        {
            try
            {
                var server = _meta.getServer(serverID);
                server.redirectWhisperGroup(sessionID, source, target);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        #endregion

        #region rashed meta & channel
        public ServerPrx[] GetBootedServer()
        {
            return _meta.getBootedServers();
        }

        public int GetUptime()
        {
            return _meta.getUptime();
        }

        public string GetSlice()
        {
            return _meta.getSlice();
        }

        public object GetStats()
        {
            int upTime = _meta.getUptime();
            int allServers = _meta.getAllServers().Count();
            int bootedServer = _meta.getBootedServers().Count();
            int usersOnline = getAllUsersCount(_meta);
            int majar = 0, minor = 0, patch = 0;
            string text = "";
            _meta.getVersion(out majar, out minor, out patch, out text);
            string murmurVersion = majar + "." + minor + "." + patch;
            string murmurRESTVersion = "0.1";

            return new
            {
                upTime,
                allServers,
                bootedServer,
                usersOnline,
                murmurVersion,
                murmurRESTVersion
            };
        }
        private int getAllUsersCount(object meta)
        {
            int userCount = 0;
            var allServer = _meta.getAllServers();
            foreach (var s in allServer)
            {
                if (s.isRunning() && s.getUsers().Count > 0)
                {
                    userCount += s.getUsers().Count();
                }
            }
            return userCount;
        }
        public ACL[] GetAllACLOfAServer(int serverID)
        {
            ACL[] acls = null;

            Group[] groups;
            bool inherit;

            var server = _meta.getServer(serverID);
            if (server != null)
            {
                // server must be running (getChannels() doesn's work)
                if (!server.isRunning())
                    return null;
                foreach (var c in server.getChannels())
                {
                    // ignore temporary channels
                    if (c.Value.temporary)
                        continue;
                    server.getACL(c.Value.id, out acls, out groups, out inherit);
                }
            }
            return acls;
        }

        public int VerifyUser(string name, string password, int serverID)
        {
            var server = _meta.getServer(serverID);
            return server.verifyPassword(name, password);
        }

        public void StartListening(int serverID, int userID, int channelID)
        {
            var server = _meta.getServer(serverID);
            server.startListening(userID, channelID);
        }

        public void StartListeningToAllChannel(int serverID, int userID, List<int> lstChannelID)
        {
            try
            {
                var server = _meta.getServer(serverID);
                lstChannelID.ForEach(x =>
                {
                    server.startListening(1, x);
                });
            }
            catch (Exception ex)
            {

            }
        }

        #endregion


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // clear all callbacks
                    //RemoveCallback(null);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~VirtualServer() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }





        #endregion
    }
}