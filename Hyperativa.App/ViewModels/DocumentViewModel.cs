using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string FileUpload { get; set; }
        public IFormFile UploadDocument { get; set; }
    }
}
