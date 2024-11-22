using Structs.Database;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ManagementServer.Utility
{
    internal partial class SQL
    {
        #region Methods

        internal static SaveResult AddRefTriggerCategory(string accountName, RefTriggerCategory category, int? linkGameWorldID = -1)
        {
            // Convert the RefTriggerCategory object to SQL parameters
            var categorySqlParams = ToSqlParameters<RefTriggerCategory>(category).ToList();

            if (linkGameWorldID.HasValue)
                categorySqlParams.Add(new SqlParameter("@WorldID", SqlDbType.Int)
                {
                    Value = linkGameWorldID
                });

            // Save the entity using the modified parameter list
            return SQL.SaveEntity(accountName, categorySqlParams.ToArray(), "_EDIT_RefTriggerCategory");
        }

        internal static SaveResult AddRefTrigger(string accountName, RefTrigger trigger, int? linkCategoryID = null)
        {
            var triggerSqlParams = ToSqlParameters<RefTrigger>(trigger).ToList();
            if (linkCategoryID.HasValue)
                triggerSqlParams.Add(new SqlParameter("@CategoryID", SqlDbType.Int)
                {
                    Value = linkCategoryID
                });
            return SQL.SaveEntity(accountName, triggerSqlParams.ToArray(), "_EDIT_RefTrigger");
        }

        internal static SaveResult AddRefTriggerAction(string accountName, RefTriggerAction action, int? linkTriggerID = null)
        {
            var actionSqlParams = ToSqlParameters<RefTriggerAction>(action).ToList();
            if (linkTriggerID.HasValue)
                actionSqlParams.Add(new SqlParameter("@TriggerID", SqlDbType.Int)
                {
                    Value = linkTriggerID
                });
            return SQL.SaveEntity(accountName, actionSqlParams.ToArray(), "_EDIT_RefTriggerAction");
        }

        internal static SaveResult AddRefTriggerActionParam(string accountName, RefTriggerActionParam actionParam)
        {
            return SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerActionParam>(actionParam), "_EDIT_RefTriggerActionParam");
        }

        internal static SaveResult AddRefTriggerCondition(string accountName, RefTriggerCondition condition, int? linkTriggerID = null)
        {
            var conditionSqlParams = ToSqlParameters<RefTriggerCondition>(condition).ToList();
            if (linkTriggerID.HasValue)
                conditionSqlParams.Add(new SqlParameter("@TriggerID", SqlDbType.Int)
                {
                    Value = linkTriggerID
                });
            return SQL.SaveEntity(accountName, conditionSqlParams.ToArray(), "_EDIT_RefTriggerCondition");
        }

        internal static SaveResult AddRefTriggerConditionParam(string accountName, RefTriggerConditionParam conditionParam)
        {
            // Save the entity using the modified parameter list
            return SQL.SaveEntity(accountName, ToSqlParameters<RefTriggerConditionParam>(conditionParam), "_EDIT_RefTriggerConditionParam");
        }

        internal static SaveResult AddRefTriggerEvent(string accountName, RefTriggerEvent triggerEvent, int? linkTriggerID = null)
        {
            var eventSqlParams = ToSqlParameters<RefTriggerEvent>(triggerEvent).ToList();
            if (linkTriggerID.HasValue)
                eventSqlParams.Add(new SqlParameter("@TriggerID", SqlDbType.Int)
                {
                    Value = linkTriggerID
                });

            return SQL.SaveEntity(accountName, eventSqlParams.ToArray(), "_EDIT_RefTriggerEvent");
        }

        internal static SaveResult AddRefGameWorld(string accountName, RefGame_World gameWorld)
        {
            // Convert the RefGame_World struct into SQL parameters
            var gameWorldSqlParams = ToSqlParameters<RefGame_World>(gameWorld).ToList();

            // Call the generic SaveEntity method with the "_EDIT_RefGame_World" stored procedure
            return SQL.SaveEntity(accountName, gameWorldSqlParams.ToArray(), "_EDIT_RefGame_World");
        }

        internal static SaveResult SaveRefGameWorld(string accountName, RefGame_World gameWorld)
            => SQL.SaveEntity(accountName, ToSqlParameters<RefGame_World>(gameWorld), "_EDIT_RefGame_World");

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

        #endregion Methods
    }
}