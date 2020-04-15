using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Perstistence.EntityConfigurations
{
    public class MessageChatUserConfiguration : EntityTypeConfiguration<MessageChatUser>
    {
        public MessageChatUserConfiguration()
        {
            HasKey(m => new { m.MessageChatId, m.UserId });



        }
    }
}