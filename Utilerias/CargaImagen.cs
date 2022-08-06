using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utilerias
{
    public class CargaImagen
    {
        public string guardarImagen(string strpath, HttpPostedFileBase file)
        {
            //subir imagen en la ruta
            try
            {
                Guid g;
                g = Guid.NewGuid();

                if (!Directory.Exists(strpath))
                    Directory.CreateDirectory(strpath);
                string pic = g.ToString();
                pic = pic + file.FileName.Substring(file.FileName.ToString().LastIndexOf('.'));
                string strpathFinal = System.IO.Path.Combine(strpath, pic);
                file.SaveAs(strpathFinal);
                return pic;
                //return file.FileName;
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
    }
}
