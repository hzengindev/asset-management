using Core.Entities;
using System;

namespace Entities.Dtos.Version
{
    public class SaveVersionFileDto: IDto
    {
        public Guid VersionId { get; set; }
        public string Filename { get; set; }
        public string FileMimeType { get; set; }
        public byte[] File { get; set; }
    }
}