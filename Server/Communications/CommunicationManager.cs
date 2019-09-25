using Common;
using Common.Enums;
using Newtonsoft.Json;
using Server.Models.Entities;
using Server.Repositories;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Communications
{
	class CommunicationManager
	{
		public Communication CommunicationReceived { get; set; }
		public CommunicationManager(Communication communicationReceived)
		{
			CommunicationReceived = communicationReceived;
		}

		internal Communication SetResponse()
		{
			switch (CommunicationReceived.Type)
			{
				case EType.CREATE:
					var address = CommunicationReceived.Content;
					var success = TestPing.Test(address);
					DomainRepository.add(new Domain { Address = address, Success = success });
					return SetCommunication(DomainRepository.GetAll);

				case EType.READ:
					return SetCommunication(DomainRepository.GetAll);

				default: return SetCommunication(null);
			}
		}

		private Communication SetCommunication(dynamic content) =>
			new Communication {
				Origin = "server",
				Type = CommunicationReceived.Type,
				Target = CommunicationReceived.Target,
				Content = content,
				Success = CommunicationReceived.Success
			};
	}
}
