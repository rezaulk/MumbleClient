/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */


namespace Sentra.PTT.Utility.Constants
{
    public class MessageConstant
    {
        public const string InternalServerError = "Internal Server Error";
        public const string NoDataFound = "No Data Found";
        public const string UnAuthorizedUser = "Un Authorize User";
        public const string FailedToSaveChannel = "Failed to Save Channel";
        public const string ServerNotFound = "Server not found";
        public const string NotPermissionToRemoveUserFromChannel = "you don't have permission to remove/left from the channel";
        public const string PasswordNotMatch = "Password not match";
        public const string DuplicateRadioChannel = "Duplicate radio Channel";
        public const string PhoneNumberUsed = "this phone number is already in used";
        public const string NoUserFound = "no user found";
        public const string UserIDExists = "The username is already exists. please try different one";
        public const string ChannelRenameFailed = "failed to rename channel name";
        public const string TwoUserMustBeAtOnline = "Two user must be at online";
        public const string FailedToGetToken = "failed to get token";
        public const string FailedToSendOTP = "failed to send otp";
        public const string VerificationCodeNotFound = "no verification code found from this mobile no.";
        public const string FailedToEstablihCall = "failed to create one to one a call";
        public const string FailedToGroupCall = "failed to create group call";
        public const string FailedToStopCall = "failed to stop call";
        public const string UserNotAtOnline = "user not at online";
        public const string UserHasNotAccessToJoinThisChannel = "the user has no access to join this channel";
        public const string UserHasNotPermitToCall = "the user has not permitted you to call";
        public const string UserHasNotPermitToAddInAChannel = "the user has not permitted you to add in a channel";
        public const string UserHasNotPermitToAddInPair = "the user has not permitted you to add in pair";
        public const string RequestSent = "your request has been sent for approval";
        public const string NoCompanyFoundForThisCompanyCode = "no company found for this company code";
        public const string QRCodeEmailed = "QR code emailed";
        public const string AssignedUnderCompany = "you have been assigned under company";
        public const string NotAValidRequest = "not a valid request";
        public const string QRCodeSubject = "QR code to become Sentra PTT company user";
        public const string QRCodeEmailBody = "scan this qr code. code will expire after 3 hours";
        public const string QRCodeExpired = "QR code expired";
        public const string RejectedYourCall = "reject your call";
        public const string RejectedYourInvitation = "reject your invitation";
        public const string DeniedYourCall = "denied your call";
        public const string FailedToAddAsBusinessUser = "failed to add as business user";
        public const string CallerAndCalleeShouldBeAtFreeMode = "callee and caller should be at free mode";
        public const string FailedToRemoveInvitation = "failed to remove invitation";
        public const string FailedToRemovePair = "failed to remove one to one pair";
        public const string BannedYou = "is/are banned you";
        //One-To-One Call
        public const string OneToOneCallEnded = "One-To-One Call is Ended";
        public const string OneToOneCallFailedToEnd = "Failed to end call";
        public const string OneToOneCallUserBusy = "User Busy";

        #region PanicAppUser
        public const string PanicAppUser_Success_Saving = "Panic App User saved successfully!";
        public const string PanicAppUser_Success_Saving_Range = "Panic App Users saved successfully!";
        public const string PanicAppUser_Success_Updating = "Panic App User updated successfully!";
        public const string PanicAppUser_Success_Deleting = "Panic App User deleted successfully!";
        #endregion
    }
}
