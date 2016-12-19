namespace Apexnet.Messaging.Mail
{
    public class Attachment
    {
        public Attachment(string content, string fileName, string mediaType)
        {
            this.Content = content;
            this.FileName = fileName;
            this.MediaType = mediaType;
        }

        /// <summary>
        /// Base64 encoded byte stream
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Filename, including the extension
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Media type (some are defined in `System.Net.Mime.MediaTypeNames.*`,
        /// or you can specify any other media type)
        ///
        /// See: https://www.iana.org/assignments/media-types/media-types.xhtml
        /// </summary>
        public string MediaType { get; private set; }
    }
}