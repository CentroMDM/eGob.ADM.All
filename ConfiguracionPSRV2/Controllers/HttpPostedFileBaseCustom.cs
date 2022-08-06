using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ConfiguracionPSRV2.Controllers
{
    public class HttpPostedFileBaseCustom: HttpPostedFileBase
    {
        readonly MemoryStream stream;
        readonly string contentType;
        readonly string fileName;

        public HttpPostedFileBaseCustom(string cadenaBase64, string fileName)
        {
            this.stream = ConvertBase64ToString(cadenaBase64);
            this.contentType = "image/jpeg";
            this.fileName = fileName;
        }


        private MemoryStream ConvertBase64ToString(string cadenaBase64) {
            byte[] byteArray = Convert.FromBase64String(cadenaBase64.Replace("data:image/jpeg;base64,", ""));
            return new MemoryStream(byteArray);
        }

        public override int ContentLength
        {
            get { return (int)stream.Length; }
        }

        public override string ContentType
        {
            get { return contentType; }
        }

        public override string FileName
        {
            get { return fileName; }
        }

        public override Stream InputStream
        {
            get { return stream; }
        }

        public override void SaveAs(string filename)
        {
            using (var file = File.Open(filename, FileMode.CreateNew))
                stream.CopyTo(file);
        }

    }
}