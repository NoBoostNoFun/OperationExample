namespace Domain.Models
{
    public class Attachment
    {
        public string Name { get; }
        public string FileId { get; }

        public Attachment(string name, string fileId)
        {
            Name = name;
            FileId = fileId;
        }
    }
}