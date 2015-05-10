namespace SDTFramework.Utils.Enums
{
    public enum LogOnValidationStatusEnum
    {
        Logged = 0,
        GenericError = 1,
        ValidationError = 2,
        LdapDomainError = 3,
        AdUserPasswordError = 4,
        ExternalUserDoNotExistError = 5,
        ExternalUserInactiveError = 6,
        ExternalUserNotApproved = 7,
        ExternalUserPasswordError = 8        
    }
}
