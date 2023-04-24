using IkinciElAracIhaleSistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.DAL.Configuration
{
	public class ChatbotConfiguration : EntityTypeConfiguration<Chatbot>
	{
		public ChatbotConfiguration()
		{
			ToTable("Chatbot");
			HasKey(c => c.ChatbotId);

			Property(c => c.Soru)
				.IsRequired();

			Property(c => c.Cevap)
				.IsRequired();

			Property(c => c.IsActive)
				.IsRequired();

			Property(c => c.IsDeleted)
				.IsRequired();
		}
	}

}
