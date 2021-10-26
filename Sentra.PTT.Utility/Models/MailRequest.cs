

using System;
using System.Collections.Generic;

namespace Sentra.PTT.Utility.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<AttachmentElement> Attachments { get; set; }
    }

    public class AttachmentElement
    {
        public Byte[] fileBytes { get; set; }
        public string fileName { get; set; }
    }
}
