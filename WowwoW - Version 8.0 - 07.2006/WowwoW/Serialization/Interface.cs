using System;
using System.Collections;
using HelperTools;

//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	public interface ISerialize
	{
		void Serialize(GenWriter writer);
		void Deserialize(GenReader reader);
	}
}
