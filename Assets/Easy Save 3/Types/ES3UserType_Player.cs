using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Instance", "characters", "stackCharacterPrefab", "maxStackAmount", "stackGap", "stackBar", "objectStackAnimDelay", "horizontalMoveDelay", "cinemachineVirtualCamera")]
	public class ES3UserType_Player : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Player() : base(typeof(Player)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Player)obj;
			
			writer.WritePropertyByRef("Instance", Player.Instance);
			writer.WriteProperty("characters", instance.characters, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UnityEngine.GameObject>)));
			writer.WritePrivateFieldByRef("stackCharacterPrefab", instance);
			writer.WritePrivateField("maxStackAmount", instance);
			writer.WritePrivateField("stackGap", instance);
			writer.WritePrivateFieldByRef("stackBar", instance);
			writer.WritePrivateField("objectStackAnimDelay", instance);
			writer.WritePrivateField("horizontalMoveDelay", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Player)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Instance":
						Player.Instance = reader.Read<Player>();
						break;
					case "characters":
						instance.characters = reader.Read<System.Collections.Generic.List<UnityEngine.GameObject>>();
						break;
					case "stackCharacterPrefab":
					reader.SetPrivateField("stackCharacterPrefab", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "maxStackAmount":
					reader.SetPrivateField("maxStackAmount", reader.Read<System.Int32>(), instance);
					break;
					case "stackGap":
					reader.SetPrivateField("stackGap", reader.Read<System.Single>(), instance);
					break;
					case "stackBar":
					reader.SetPrivateField("stackBar", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "objectStackAnimDelay":
					reader.SetPrivateField("objectStackAnimDelay", reader.Read<System.Single>(), instance);
					break;
					case "horizontalMoveDelay":
					reader.SetPrivateField("horizontalMoveDelay", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerArray() : base(typeof(Player[]), ES3UserType_Player.Instance)
		{
			Instance = this;
		}
	}
}