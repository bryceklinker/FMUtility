using System;

namespace FMUtility.Core.Eventing.Args
{
    public class CloseDocumentArgs
    {
        public CloseDocumentArgs(Guid documentId)
        {
            DocumentId = documentId;
        }

        public Guid DocumentId { get; private set; }
    }
}