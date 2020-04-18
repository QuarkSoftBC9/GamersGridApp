using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.EntityConfigurations
{
    public class MessageChatConfiguration : EntityTypeConfiguration<MessageChat>
    {
        public MessageChatConfiguration()
        {
             HasMany(m => m.MessageChatUsers)
                .WithRequired(m => m.Chat);
        }
    }
}