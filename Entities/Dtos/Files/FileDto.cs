using System;


namespace Entities.Dtos.Files
{
    public class FileDto
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
