using System.Reflection.Emit;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace ConsoleRPG
{
		internal class Program
		{
			static void Main(string[] args)
			{
				Start start = new Start();
				start.GameStart();
			}
		}
	}

