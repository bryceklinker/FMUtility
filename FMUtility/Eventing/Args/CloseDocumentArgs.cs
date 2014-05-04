using System;

namespace FMUtility.Eventing.Args
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
