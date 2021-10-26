/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */

namespace Sentra.PTT.Utility.Constants
{
    public class ErrorMessages
    {
        public const string SAVE_ERROR = "Info created failed";
        public const string SESSION_NOT_FOUND = "Session not found";
        public const string SESSION_IS_EXPIRED = "Session was expired";
        public const string SESSION_EXPIRED_OR_INACTIVE = "Your token is expired by logout or administrator force to inactive the token";
        public const string ACCESS_DENIED = "Access is denied";
        public const string FORBIDDEN = "Sorry! You have no permission to access";
        public const string OLDPASSWORD_NOT_MATCH = "Old password is not match";
        public const string USER_NOT_EXIST = "User not exist";
        public const string SERVER_PROBLEM = "Server Problem";
        public const string USERNAME_OR_PASSWORD_INCORRECT = "Username or password is incorrect";
        public const string CONTENT_IS_EMPTY_OR_NULL = "Content is null or empty";
        public const string NO_USER_FOUND = "There was no user found";
        public const string NO_LOG_FOUND = "There was no log found";
        public const string NO_ACCESS_RIGHT_FOUND = "There was no access right found";
        public const string NO_CONTROLLER_FOUND = "There was no controller found";
        public const string NO_ACTION_FOUND = "There was no action found";
        public const string ACCESS_RIGHT_ALREADY_EXIST = "Access right already exist";
        public const string INVALID_PARAMETERS = "Access right already exist";
        public const string ERROR_FROM_DATABASE = "Error From Database";
        
        #region PanicAppUser
        public const string PanicAppUser_Error_Duplicate_Record = "Record with the Person ID already exsists!";
        public const string PanicAppUser_Error_Saving = "Failed to save Panic App User!";
        public const string PanicAppUser_Error_Saving_Range = "Failed to save Panic App Users!";
        public const string PanicAppUser_Error_Updating = "Failed to update Panic App User!";
        public const string PanicAppUser_Error_Deleting = "Failed to delete Panic App User!";
        public const string PanicAppUser_Error_Not_Found = "No Panic App Users found!";
        #endregion
    }
}
