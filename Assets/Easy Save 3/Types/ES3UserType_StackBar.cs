using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("stackFill")]
	public class ES3UserType_StackBar : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_StackBar() : base(typeof(StackBar)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (StackBar)obj;
			
			writer.WritePropertyByRef("stackFill", instance.stackFill);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (StackBar)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "stackFill":
						instance.stackFill = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_StackBarArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StackBarArray() : base(typeof(StackBar[]), ES3UserType_StackBar.Instance)
		{
			Instance = this;
		}
	}
}