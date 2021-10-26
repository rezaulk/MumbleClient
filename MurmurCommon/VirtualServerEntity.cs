// (c) 2017 HarpyWar (harpywar@gmail.com))
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Xml.Serialization;

namespace MurmurCommon
{
    /// <summary>
    /// Murmur Virtual Server inner structure
    /// </summary>
    [Serializable]
    public class VirtualServerEntity
    {
        public int Id;
        public string Address;
        public int Port;
        public string MurmurVersion;

        public SerializableDictionary<string, string> Config = new SerializableDictionary<string, string>();
        public SerializableDictionary<int, User> Users = new SerializableDictionary<int, User>();
        public SerializableDictionary<int, Channel> Channels = new SerializableDictionary<int, Channel>();
        public SerializableDictionary<int, Ban> Bans = new SerializableDictionary<int, Ban>();

        [XmlIgnore]
        public SerializableDictionary<int, OnlineUser> OnlineUsers = new SerializableDictionary<int, OnlineUser>();


        /// <summary>
        /// Do not use parameters - serialization needs constructor without parameters
        /// </summary>
        public VirtualServerEntity()
        {
        }

        public class User
        {
            public int Id;
            public byte[] Texture;

            public SerializableDictionary<UserInfo, string> Info = new SerializableDictionary<UserInfo, string>();
            public enum UserInfo
            {
                UserName,
                UserEmail,
                UserComment,
                UserHash,
                UserPassword,
                UserLastActive
            }
        }

        public class OnlineUser
        {
            public int Id { get; set; }
            public int ChannelId { get; set; }
            public string Name { get; set; }
            public byte[] Address { get; set; }
            public int BytesPerSec { get; set; }
            public string Comment { get; set; }
            public string Context { get; set; }
            public bool Deaf { get; set; }
            public string Identity { get; set; }
            public int Idlesecs { get; set; }
            public bool Mute { get; set; }
            public int OnlineSecs { get; set; }
            public string Os { get; set; }
            public string OsVersion { get; set; }
            public bool PrioritySpeaker { get; set; }
            public bool Recording { get; set; }
            public string Release { get; set; }
            public bool SelfDeaf { get; set; }
            public bool SelfMute { get; set; }
            public int Session { get; set; }
            public bool Supress { get; set; }
            public float TcpPing { get; set; }
            public bool TcpOnly { get; set; }
            public float UdpPing { get; set; }
            public int Version { get; set; }

            public void Move(IVirtualServer server, int newChannelId)
            {
                this.ChannelId = newChannelId;
                server.UpdateUserState(this);
            }
            public void SetMute(IVirtualServer server, bool mute)
            {
                this.Mute = mute;
                server.UpdateUserState(this);
            }
            public void SetDeafen(IVirtualServer server, bool deaf)
            {
                this.Deaf = deaf;
                server.UpdateUserState(this);
            }

        }


        public class Channel
        {
            public int Id;
            public string Name;
            public int ParentId;
            public bool InheritAcl = true;

            public string Description;
            public int Position;
            public bool Temporary = false;

            public int[] Links;

            public SerializableDictionary<int, Group> Groups = new SerializableDictionary<int, Group>();
            public SerializableDictionary<int, Acl> Acls = new SerializableDictionary<int, Acl>();

            public class Group
            {
                public string Name;
                public bool Inherit;
                public bool Inheritable;
                public bool Inherited;

                public int[] Members;
                public int[] Add;
                public int[] Remove;
            }

            public class Acl
            {
                public int Allow;
                public bool ApplySubs;
                public bool ApplyHere;
                public int Deny;
                public string Group;
                public bool Inherited;
                public int UserId;
            }

            public void Move(IVirtualServer server, int newParentId)
            {
                this.ParentId = newParentId;
                server.UpdateChannelState(this);
            }
            public void SetName(IVirtualServer server, string newName)
            {
                this.Name = newName;
                server.UpdateChannelState(this);
            }
        }

        public class Tree
        {
            public Channel Channel;
            public Tree[] Children;
            public OnlineUser[] Users;
        }

        public class Ban
        {
            public byte[] Address;
            public int Bits;
            public int Duration;
            public string Hash;
            public string Name;
            public string Reason;
            public int Start;
        }

        public struct LogEntry
        {
            public int Timestamp;
            public string Text;
        }
    }
}
