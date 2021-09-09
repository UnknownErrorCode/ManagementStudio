using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMapSpawnEditor.Controls;

namespace WorldMapSpawnEditor
{
	public static class DataManager
	{
		#region (Properties)
		/// <summary>
		/// The current path to the SR_Client.
		/// </summary>
		public static string ClientPath { get; set; }
		/// <summary>
		/// Unique name from the Silkroad.
		/// </summary>
		public static string SilkroadName { get; private set; }
		/// <summary>
		/// Silkroad Locale
		/// </summary>
		public static byte Locale { get; set; }
		/// <summary>
		/// SR_Client name
		/// </summary>
		public static string SR_Client { get; set; }
		/// <summary>
		/// Silkroad Version
		/// </summary>
		public static uint Version { get; set; }
		/// <summary>
		/// Gets the database previouly selected.
		/// </summary>
		//private static SQLDatabase Database { get; set; }
		#endregion

		

		#region Gets from Database
		
		/// <summary>
		/// Gets the maximum exp required for the level specified.
		/// </summary>
		public static ulong GetPetExpMax(byte level)
		{
			return 0;
		}
		/// <summary>
		/// Gets the maximum exp required for the job level specified.
		/// </summary>
		/// <param name="level">Job level</param>
		/// <param name="type">Trader, Thief or Hunter</param>
		public static uint GetJobExpMax(byte level, SRPlayer.Job type)
		{
			return 0;
		}
		/// <summary>
		/// Get model by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetModelData(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get model by servername, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetModelData(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get teleportlink by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetTeleport(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get teleportlink by servername, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetTeleport(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get teleportlink by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetTeleportLinkByID(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get teleportlink by servername, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetTeleportLinkByServerName(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get item by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetItemData(uint id)
		{
				return null;
		}
		/// <summary>
		/// Get item by servername, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetItemData(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get an magic option from items, by id.
		/// </summary>
		public static NameValueCollection GetMagicOption(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get an magic option from items, by servername.
		/// </summary>
		public static NameValueCollection GetMagicOption(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get skill by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetSkillData(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get skill by servername, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetSkillData(string servername)
		{
			return null;
		}
		/// <summary>
		/// Get mastery by id, using the current database loaded.
		/// </summary>
		public static NameValueCollection GetMastery(uint id)
		{
			return null;
		}
		/// <summary>
		/// Get region name by id, using the current database loaded.
		/// </summary>
		public static string GetRegion(ushort id)
		{
			return "";
		}
		/// <summary>
		/// Gets the UIIT text already formated with params provided. returns an empty string if the servername is not found.
		/// </summary>
		public static string GetUIFormat(string servername, params object[] args)
		{
			return "";
		}
		
		/// <summary>
		/// Gets all links from the teleport specified.
		/// </summary>
		public static List<NameValueCollection> GetTeleportLinks(uint sourceTeleportID)
		{
			return null; // Database.GetResultFromQuery("SELECT * FROM teleportlinks WHERE id=" + sourceTeleportID);
		}
		/// <summary>
		/// Gets the teleport destination ID. Return 0 if none is found.
		/// </summary>
		public static uint GetTeleportLinkDestinationID(uint sourceTeleportID, uint destinationTeleportID)
		{
			
			return 0;
		}
		/// <summary>
		/// Gets the next skill ID from the skill to update, returns 0 if none is found.
		/// </summary>
		public static uint GetCommonAttack(SRTypes.Weapon type)
		{
			
			return 0;
		}
		#endregion
	}
}
