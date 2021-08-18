using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFileTask.Domain
{
   public class Image_Data
    {
        [Key]
        public int Image_Data_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Image_Path { get; set; }
        public byte[] Image_Blob { get; set; }
    }
}
