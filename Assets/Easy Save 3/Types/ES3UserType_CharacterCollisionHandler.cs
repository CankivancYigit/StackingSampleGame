using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_CharacterCollisionHandler : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CharacterCollisionHandler() : base(typeof(CharacterCollisionHandler)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (CharacterCollisionHandler)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (CharacterCollisionHandler)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CharacterCollisionHandlerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CharacterCollisionHandlerArray() : base(typeof(CharacterCollisionHandler[]), ES3UserType_CharacterCollisionHandler.Instance)
		{
			Instance = this;
		}
	}
}