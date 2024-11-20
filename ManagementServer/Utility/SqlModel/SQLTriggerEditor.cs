using Structs.Database;

namespace ManagementServer.Utility
{
    internal partial class SQL
    {
        internal static SaveResult SaveRefTrigger(string accountName, RefTrigger trigger)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTrigger>(trigger), "_EDIT_RefTrigger");
        internal static SaveResult SaveRefTriggerAction(string accountName, RefTriggerAction triggerAction)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerAction>(triggerAction), "_EDIT_RefTriggerAction");

        internal static SaveResult SaveRefTriggerActionParam(string accountName, RefTriggerActionParam triggerActionParam)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerActionParam>(triggerActionParam), "_EDIT_RefTriggerActionParam");

        internal static SaveResult SaveRefTriggerCategory(string accountName, RefTriggerCategory triggerCategory)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerCategory>(triggerCategory), "_EDIT_RefTriggerCategory");

        internal static SaveResult SaveRefTriggerCondition(string accountName, RefTriggerCondition triggerCondition)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerCondition>(triggerCondition), "_EDIT_RefTriggerCondition");

        internal static SaveResult SaveRefTriggerConditionParam(string accountName, RefTriggerConditionParam triggerConditionParam)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerConditionParam>(triggerConditionParam), "_EDIT_RefTriggerConditionParam");

        internal static SaveResult SaveRefTriggerEvent(string accountName, RefTriggerEvent triggerEvent)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerEvent>(triggerEvent), "_EDIT_RefTriggerEvent");

        internal static SaveResult SaveRefGameWorld(string accountName, RefGame_World gameWorld)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefGame_World>(gameWorld), "_EDIT_RefGame_World");





    }
}
