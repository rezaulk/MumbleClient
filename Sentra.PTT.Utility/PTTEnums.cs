/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Feb 16,2021
 * (c) NybSys Ltd.
 */


namespace Sentra.PTT.Utility
{
    public class PTTEnums
    {
        public enum Status
        {
            None = 0,
            Active = 1,
            Inactive = 2,
            Deleted = 3,
            Pending = 4,
            Registered = 5,
            Online = 6,
            Offline = 7
        }

        public enum DeviceStatus
        {
            Active = 1,
            Assigned = 2,
            Released = 3,
            Deleted = 4
        }

        public enum ModelStatus
        {
            Already = -1,
            SystemError = -2,
            InvalidParameter = -3,
            Inserted = 1,
            Updated = 2,
            Deleted = 3
        }

        public enum ResponseCode
        {
            Success = 200,
            InternalServerError = 500,
            Failed = 404,
            Warning = 400,
            UnAuthorize = 401
        }
        public enum RegistrationStatus
        {
            Request = 1,
            OTPSent = 2,
            PhoneNoConfirmed = 3,
            Registered = 4

        }

        public enum PanicAlertStatus
        {
            PENDING=1,
            ACTIVE=2,
            RESOLVED= 3,
            CANCEL= 4,
            FALSE= 5

        }


        public enum StatusOfAlive
        {
            Online = 1,
            Offline = 2,
            Away = 3,
            Busy = 4,
            StandBy = 5,
            Custom = 6
        }

        public enum Role
        {
            SuperAdmin = 1,
            CompanyAdmin = 2,
            Agent = 3,
            Participant = 4
        }

        public enum MessageType
        {
            UserConnected = 1,
            UserDisconnected = 2,
            UserStateChanged = 3,
            UserAdded = 4,
            UserRemoved = 5,
            ChannelSaved = 6,
            ChannelRemoved = 7,
            ChannelMoved = 8,
            OneToOneCallConfirmation = 9,
            OneToOneCallEstablished = 10,
            OneToOneCallChannelRemoved = 11,
            SimpleNotification = 12,
            AddUserToAChannelConfirmation = 13,
            AddUserToAChannelEstablished = 14,
            AllowChannelPermission = 15,
            BanUser = 16,
            MessageSeen = 17,
            ChannelInvitationRejection = 18,
            ChannelParticipants = 19,
            UserAddedToAChannel = 20,
            ChannelLeft = 21,
            UnBanUser = 22,
            RemoveChannelPermission = 23,
            UserAddConfirmation = 24,
            ChannelList = 25,
            UserProfileUpdate = 26,
            NewAlert = 27,
            RemoveInvitation = 28,
            NewAudioArchived = 29,
            OneToOneChannelConfirmation = 30,
            OneToOneChannelInvitationRejection = 31,
            RemoveOneToOneInvitation = 32,
            RemoveOneToOnePair = 33,
            OneToOneCallConfirmation2 = 34,
            OneToOneCallEstablished2 = 35,
            OneToOneCallChannelRemoved2 = 36,
            OneToOneCallRejection2 = 37,
            CompanyInactiveOrDeleted = 38,
            CompanyActivated = 39,
            MuteStatus = 40,
            PushToTalkResponse = 141,
        }

        public enum ListeningType
        {
            ChannelSavedToACompany = 1,
            ChannelRemovedFromACompany = 2,
            UserSavedToACompany = 3,
            UserRemovedFromACompany = 4,
            OneToOneTalk = 5,
            OneToOneTalkConfirmation = 6,
            OneToOneTalkStop = 7,
            AddUserToChannel = 8,
            AddUserToChannelConfirmation = 9,
            RemoveUserFromChannel = 10,
            RenameChannel = 11,
            MessageSeen = 12,
            CompanyCodeToAddUser = 13,
            QRCodeToAddUser = 14,
            AddUserBan = 15,
            RemoveUserBan = 16,
            AddChannelPermission = 17,
            RemoveChannelPermission = 18,
            UserSavedToACompanyConfirmation = 19,
            UpdateUserProfile = 20,
            RemoveInvitation = 21,
            GroupCall = 22,
            AudioArchive = 23,
            RemoveOneToOneInvitation = 24,
            RemoveOneToOnePair = 25,
            OneToOneTalk2 = 26,
            OneToOneTalkConfirmation2 = 27,
            OneToOneTalkStop2 = 28,
            MumsiInstanceCreated = 29,
            MumsiInstanceDeleted = 30,
            MumsiCreateInstanceFailed = 31,
            MumsiDELETEInstanceFailed = 32,
            MumsiReloadResponse = 33,
            PushToTalkRequest = 34,
            PushToTalkingTime = 40,
            UserUpdateStatus = 41,

        }

        public enum ArchiveServerListeningType
        {
            ChannelSaved = 1,
            ChannelRemoved = 2
        }
        public enum ChannelType
        {
            CompanyChannel = 1,
            OneToOneTempChannel = 2,
            FreeUserDedicatedChannel = 3,
            GroupChannel = 3
        }

        public enum PanicConfigurationType
        {
            SecurityPersonnel = 1,
            PanicResponsibles = 2,
            Channels = 3
        }

        public enum PickType
        {
            Accepted = 1,
            Rejected = 2,
            BanUser = 3
        }

        public enum ExceptionType
        {
            Log = 1,
            Exception = 2,
        }

        public enum TextMessageType
        {
            TextMessage = 1,
            ImageMaster = 2,
            ImageDetail = 3,
            Alert = 4,
            Location = 5,
            MuteOthers = 6,
            PanicAlert = 17,
            GuardReply = 18,
            Chats = 20,



        }

        public enum PushTalkStatus
        {
            StartTalk = 1,
            EndTalk = 2,

        }

        public enum SipAction
        {
            //Request action: when I have to take action.
            CreateInstance = 1,
            Call = 2,
            Answer = 3,
            End = 4,
            Mute = 5,
            Unmute = 6,
            Transfer = 7,
            Hold = 8,
            Unhold = 9,
            Reject = 10,
            Patch = 11,
            RemoveReg = 35,
            ReRegister = 36,

            //Response action: after doing action
            RegSuccess = 12,
            RegTempFail = 13,
            RegFail = 14,
            RegRemoved = 15,
            CallStarting = 16,
            CallFailedNotResolved = 17,
            CallProgressing = 18,
            CallTrying = 19,
            CallRinging = 20,  // Remote phone ringing. ( Local to Remote call)
            CallFailed = 21,
            CallAnswered = 22, //When destination answered my call
            CallFinished = 23,
            CallHold = 24,
            CallUnhold = 25,
            RemoteHold = 26,
            RemoteUnhold = 27,
            CallCancel = 28,
            IncomingCall = 29,   // Ringing at local phone - when called from remote phone. ( Remote to local)
            IncomingCallCanceled = 30, //when 
            IncomingCallAnswered = 31, //When I answered an incoming call
            BlindTransfer = 32,
            TransferNotify = 33,
            PortUnableToBind = 34,
            CallRejected = 37,



            //WarningMessage = 99
        }

        public enum ChannelInvitationStatus
        {
            Panding = 1,
            Accepted = 2,
            Rejected = 3,
            Removed = 4
        }

        public enum CallStatus
        {
            Ringing = 1,
            Active = 2,
            Rejected = 3,
            End = 4,
            MissedCall = 5
        }

        public enum CallHistoryType
        {
            All = 1,
            MissedCall = 2
        }


        public enum MessageTypeWebSocket
        {
            //Alert= 1,
            //Image=2,
            Voice = 5,
            ChannelAdd = 6,
            ChannelRemove = 7,
            ChannelUpdate = 8,
            ParticipantAdd = 9,
            ParticipantRemove = 10,
            ParticipantStatus = 11,
            UserAdd = 12,
            UserRemove = 13,
            UserUpdate = 14,
            MessageSeen = 15,

            Online = 16,
            Offline = 17,
            LocationChange = 18,

            ChannelMove = 19,
            MuteStatus = 20
        }

        public enum CallStatusSIP
        {
            Ringing = 1,
            Active = 2,
            Hold = 3,
            End = 4,
            Forward = 5,
            MissedCall = 6,
            AgentConference = 7,
            SIPtoSIPTransfer = 8,
            End_Participant = 9,
            Add_Participant = 10,
            Rejected = 11,
        }

        public enum CallType
        {
            MissedCall = 1,
            Incoming = 2,
            Outgoing = 3
        }

        public enum GlobalSettingKeys
        {
            SentraServer = 1,
            SipServer = 2,
            SipWebSocketServer = 3
        }

        public enum ValidationType
        {
            IsNullOrEmpty = 1,
            IsNullOrWhiteSpace = 2,
            IsLessThanThree = 3,
            IsLessThanOrEqual = 4,
            IsGreaterThan = 5,
            IsGreaterThanOrEqual = 6,
            IsEqual = 7,
            IsNotEqual = 8,
            IsValidEmail = 9,
            IsNull = 10,
            IsDuplicateItem = 11,
            IsLengthLessThan = 12,
            IsGreaterThanFifty = 13,
            IsPositiveIntegreOrNull = 14,
            IsValidDate = 15
        }

        public enum ActivityLogType
        {
            TextMessage = 1,
            ImageMaster = 2,
            ImageDetail = 3,
            Alert = 4,
            Location = 5,
            MuteOthers = 6,
            VoiceRecord = 7
        }


        public enum MumbleUserType
        {
            Dispatch = 1,
            IOT_1 = 2,
            IOT_2 = 3,

            //Mobile= 3,
        }
        public enum LoginStatus
        {
            Loggedin = 1,
            Loggedout = 0
        }

        public enum UserAccessRight
        {
            SuperAdmin = 1,
            Admin = 2,
            Agent = 3,
            User = 4
        }

        public enum UserType
        {
            APPSUSER = 1,
            DEVICEUSER = 2,
            WEBUSER = 3
        }
        public enum LogActions
        {
            insert = 1,
            Update = 2,
            Deleted = 3,
            Modified = 4,
            View = 5,
            Reviewed = 6

        }

        public enum LogType
        {
            SecurityLog = 1,
            ErrorLog = 2,
            SystemLog = 3,
            DbQuery = 4,
            Other = 5

        }

        #region "Exception Log"

        public enum ExceptionModule
        {
            AdminPanel = 1,
            App = 2,
            Sentra = 3
        }

        public enum ActionName
        {
            User = 1,
            Dashboard = 2
        }

        public enum ActionType
        {
            Add = 1,
            Update = 2,
            Delete = 3,
            filter = 4,
            View = 5,
            List = 6
        }

        public enum LogFixPriority
        {
            Low = 1,
            Medium = 2,
            High = 3
        }



        public enum WebSocketType
        {
            Low = 1,
            Medium = 2,
        }

        public enum ContactType
        {
            None = 0,
            Phone = 1,
            Email = 2
        }
        #endregion        
    }
}
