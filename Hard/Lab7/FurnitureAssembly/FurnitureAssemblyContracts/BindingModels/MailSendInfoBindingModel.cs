﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.BindingModels
{
    // Класс для обмена информацией по почте
    public class MailSendInfoBindingModel
    {
        public string MailAddress { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;
    }
}
