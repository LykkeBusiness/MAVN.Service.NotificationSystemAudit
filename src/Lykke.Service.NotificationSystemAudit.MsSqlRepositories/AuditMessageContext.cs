﻿using System.Data.Common;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.NotificationSystemAudit.MsSqlRepositories
{
    public class AuditMessageContext : MsSqlContext
    {
        private const string Schema = "auditmessage";

        internal DbSet<AuditMessage> AuditMessages { get; set; }

        // For EF migrations
        [UsedImplicitly]
        public AuditMessageContext()
            : base(Schema)
        {
        }

        public AuditMessageContext(string connectionString, bool isTraceEnabled)
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        public AuditMessageContext(DbConnection dbConnection)
            : base(Schema, dbConnection)
        {
        }

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
            var auditMessageEntityBuilder = modelBuilder.Entity<AuditMessage>();

            auditMessageEntityBuilder.HasIndex(c => c.MessageType).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(c => c.CustomerId).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(c => c.DeliveryStatus).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(x => x.SentTimestamp).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(x => x.Source).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(x => x.MessageId).IsUnique(false);
            auditMessageEntityBuilder.HasIndex(x => x.MessageGroupId).IsUnique(false);
        }
    }
}
