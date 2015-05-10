namespace SDTFramework.Utils.Enums
{
    public enum AuditActionEnum
    {
        [AuditNomeKey("auditActionsCreate")]
        Insert = 0,
        [AuditNomeKey("auditActionsDelete")]
        Delete = 1,
        [AuditNomeKey("auditActionsUpdate")]
        Edit = 2
    }
}