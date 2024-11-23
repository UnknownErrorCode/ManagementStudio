namespace TriggerEditor.EditorLayouts
{
    /// <summary>
    /// Base class for all condition parameters.
    /// </summary>
    public abstract class ConditionParamBase
    {
        /// <summary>
        /// Group identifier for the condition parameter.
        /// </summary>
        public string GroupCodeName128 { get; set; }
    }

    /// <summary>
    /// Represents a condition where a specific monster hive must be killed.
    /// </summary>
    public class MonsterHiveKillConditionParam : ConditionParamBase
    {
        /// <summary>
        /// The selected hive monster ID.
        /// </summary>
        public int HiveMonsterSelect { get; set; } // HIVE_MONSTER_SELECT
    }

    /// <summary>
    /// Represents a condition for monster rarity kill.
    /// </summary>
    public class MonsterRarityKillConditionParam : ConditionParamBase
    {
        /// <summary>
        /// The numeric input parameter (e.g., rarity level).
        /// </summary>
        public int NumInput { get; set; } // NUM_INPUT
    }

    /// <summary>
    /// Represents a condition for monster level kill with a comparison operator.
    /// </summary>
    public class MonsterLevelKillConditionParam : ConditionParamBase
    {
        /// <summary>
        /// The comparison operator for the condition (e.g., SIGN_LEFT_BIG_EQUAL).
        /// </summary>
        public string SignSelect { get; set; } // SIGN_SELECT

        /// <summary>
        /// The numeric input parameter (e.g., monster level threshold).
        /// </summary>
        public int NumInput { get; set; } // NUM_INPUT
    }

    /// <summary>
    /// Represents a condition for the user's level with a comparison operator.
    /// </summary>
    public class UserLevelConditionParam : ConditionParamBase
    {
        /// <summary>
        /// The comparison operator for the condition (e.g., SIGN_LEFT_BIG_EQUAL).
        /// </summary>
        public string SignSelect { get; set; } // SIGN_SELECT

        /// <summary>
        /// The numeric input parameter (e.g., user level threshold).
        /// </summary>
        public int NumInput { get; set; } // NUM_INPUT
    }
}