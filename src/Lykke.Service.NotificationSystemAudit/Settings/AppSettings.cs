﻿using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.NotificationSystemAudit.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public NotificationSystemAuditSettings NotificationSystemAuditService { get; set; }

        public RabbitMqSettings Rabbit { get; set; }
    }
}
