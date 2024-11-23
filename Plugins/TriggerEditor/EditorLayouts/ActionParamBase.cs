namespace TriggerEditor.EditorLayouts
{
    using System;

    /// <summary>
    /// Base class for all action parameters.
    /// </summary>
    public abstract class ActionParamBase
    {
        /// <summary>
        /// Group identifier for the action parameter.
        /// </summary>
        public string GroupCodeName128 { get; set; }
    }

    /// <summary>
    /// Parameters for creating a teleport object.
    /// </summary>
    public class TeleportObjectParam : ActionParamBase
    {
        /// <summary>
        /// X coordinate of the teleport.
        /// </summary>
        public float PositionX { get; set; }

        /// <summary>
        /// Y coordinate of the teleport.
        /// </summary>
        public float PositionY { get; set; }

        /// <summary>
        /// Z coordinate of the teleport.
        /// </summary>
        public float PositionZ { get; set; }

        /// <summary>
        /// Region ID where the teleport resides.
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// X coordinate for the teleport destination.
        /// </summary>
        public float DestinationX { get; set; }

        /// <summary>
        /// Y coordinate for the teleport destination.
        /// </summary>
        public float DestinationY { get; set; }

        /// <summary>
        /// Z coordinate for the teleport destination.
        /// </summary>
        public float DestinationZ { get; set; }

        /// <summary>
        /// Region ID for the teleport destination.
        /// </summary>
        public int DestinationRegionID { get; set; }
    }

    /// <summary>
    /// Parameters for outputting a message to the notify window.
    /// </summary>
    public class MessageNotifyParam : ActionParamBase
    {
        /// <summary>
        /// The message to display.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The target player or group (e.g., "TARGET_PLAYER_ALL").
        /// </summary>
        public string TargetPlayer { get; set; }
    }

    /// <summary>
    /// Parameters for outputting a message to the system window.
    /// </summary>
    public class MessageSystemParam : ActionParamBase
    {
        /// <summary>
        /// The message to display.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The target player or group (e.g., "TARGET_PLAYER_EVENT_USER").
        /// </summary>
        public string TargetPlayer { get; set; }
    }

    /// <summary>
    /// Parameters for activating a monster nest.
    /// </summary>
    public class MonsterNestActivationParam : ActionParamBase
    {
        /// <summary>
        /// The ID of the monster nest to activate.
        /// </summary>
        public int NestMonsterID { get; set; }
    }

    /// <summary>
    /// Parameters for switching event zones.
    /// </summary>
    public class EventZoneSwitchParam : ActionParamBase
    {
        /// <summary>
        /// The event zone to activate or deactivate.
        /// </summary>
        public string EventZoneName { get; set; }

        /// <summary>
        /// The ON/OFF state for the event zone.
        /// </summary>
        public string SwitchState { get; set; }
    }

    /// <summary>
    /// Parameters for loading an NPC.
    /// </summary>
    public class NpcLoadParam : ActionParamBase
    {
        /// <summary>
        /// ID of the NPC to load.
        /// </summary>
        public int NpcID { get; set; }

        /// <summary>
        /// Spawn location X coordinate.
        /// </summary>
        public float SpawnX { get; set; }

        /// <summary>
        /// Spawn location Y coordinate.
        /// </summary>
        public float SpawnY { get; set; }

        /// <summary>
        /// Spawn location Z coordinate.
        /// </summary>
        public float SpawnZ { get; set; }
    }

    /// <summary>
    /// Parameters for manipulating a variable's value.
    /// </summary>
    public class VariableManipulationParam : ActionParamBase
    {
        /// <summary>
        /// The variable name.
        /// </summary>
        public string VariableName { get; set; }

        /// <summary>
        /// The value to set or adjust.
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// Factory class for creating action parameters dynamically.
    /// </summary>
    public static class ActionParamFactory
    {
        /// <summary>
        /// Creates an instance of the appropriate parameter class based on the action type.
        /// </summary>
        /// <param name="actionCodeName">The action's code name.</param>
        /// <returns>An instance of the appropriate parameter class.</returns>
        public static ActionParamBase CreateParam(string actionCodeName)
        {
            switch (actionCodeName)
            {
                case "TRIGGER_ACTION_CREATEOBJECT_TELEPORT":
                    return new CreateObjectTeleportParam();

                case "TRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW":
                    return new MessageNotifyParam();

                case "TRIGGER_ACTION_MESSAGE_SYSTEM_WINDOW":
                    return new MessageSystemParam();

                case "TRIGGER_ACTION_MONSTER_ACTIVE_NEST":
                    return new MonsterNestActivationParam();

                case "TRIGGER_ACTION_SWITCH_EVENTZONE":
                    return new EventZoneSwitchParam();

                case "TRIGGER_ACTION_NPC_LOAD":
                    return new NpcLoadParam();

                case "TRIGGER_ACTION_VARIABLE_VALUE":
                    return new VariableManipulationParam();

                default:
                    throw new ArgumentException($"Unknown action type: {actionCodeName}", nameof(actionCodeName));
            }
        }
    }

    /// <summary>
    /// Represents the parameters for creating a teleport object in a trigger action.
    /// </summary>
    public class CreateObjectTeleportParam : ActionParamBase
    {
        /// <summary>
        /// The identifier for the portal (e.g., RUNTIME_POTAL_SELECT).
        /// </summary>
        public string PortalSelect { get; set; }

        /// <summary>
        /// The first numeric input (e.g., NUM_INPUT_1).
        /// Typically represents the region ID for the teleport's location.
        /// </summary>
        public int NumInput1 { get; set; }

        /// <summary>
        /// The X-coordinate of the teleport location.
        /// </summary>
        public float FloatInput1 { get; set; }

        /// <summary>
        /// The Y-coordinate of the teleport location.
        /// </summary>
        public float FloatInput2 { get; set; }

        /// <summary>
        /// The Z-coordinate of the teleport location.
        /// </summary>
        public float FloatInput3 { get; set; }

        /// <summary>
        /// The second numeric input (e.g., NUM_INPUT_2).
        /// Typically represents the region ID for the teleport's destination.
        /// </summary>
        public int NumInput2 { get; set; }

        /// <summary>
        /// The X-coordinate of the teleport destination.
        /// </summary>
        public float FloatInput4 { get; set; }

        /// <summary>
        /// The Y-coordinate of the teleport destination.
        /// </summary>
        public float FloatInput5 { get; set; }

        /// <summary>
        /// The Z-coordinate of the teleport destination.
        /// </summary>
        public float FloatInput6 { get; set; }
    }
}