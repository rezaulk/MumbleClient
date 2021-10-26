/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */

namespace Sentra.PTT.Utility.Constants
{
    public static class ListeningTopicConstant
    {
        public static string listeningTopic = "state_server_listening";
        public static string locationSubscribeTopic = "location/user/#";
        public static string locationListeningTopic = "location/user/";
        public static string CompanyListeningTopic = "company/";
        public static string SipSubscribeTopic = "IOTDevice/#";
        public static string SipListeningTopic = "IOTDevice/";


        public static string Panicalert_ListeningTopic = "state_server_panicalert_listening";


        public static string PanicalertSubscribeTopic = "PanicalertDevice/Student/#";   /// when student give any alert
        public static string PanicalertListeningTopic = "PanicalertDevice/Student/";

        public static string PanicalertSecuritySubscribeTopic = "PanicalertDevice/Security/#";   /// when Security give any alert
        public static string PanicalertSecurityListeningTopic = "PanicalertDevice/Security/";

        public static string PanicalertChatsSubscribeTopic = "PanicalertChats/#";    /// 
        public static string PanicalertChatsListeningTopic = "PanicalertChats/";

        public static string MultiCastSubscribeTopic = "MultiCastDevice/#";    /// 
        public static string MulticastListeningTopic = "MultiCastDevice/";


        public static string PanicalertChatsSubscribeTopicMobile = "PanicalertChatsSubscribe/";


        public static string MessageSentFromMLTeam = "MessageSentFromMLTeam/";
        public static string MessageSubcribeSentFromMLTeam = "MessageSentFromMLTeam/#";






    }

    public static class ArchiveServerListeningTopicConstant
    {
        public static string listeningTopic = "archive_server_listening";
    }
}
