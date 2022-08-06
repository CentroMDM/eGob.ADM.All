using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesPSR;

namespace Utilerias
{
    public class GenerarPreview
    {

        public string GetHTMLPreview(Etcasocformatos formato, List<Etcasoscformatoseccion> secciones, List<EAuxPreviewFormatos> variables) {
            StringBuilder sb = new StringBuilder();
            //Ponemos el nombre de la seccion
            sb.Append("<div class='subheader'>");
            sb.Append("<h1 class='subheader-title'>");
            sb.Append("<i class='fal fa-calendar-alt'></i>");
            sb.Append(formato.DescripcionExterna);
            sb.Append("</h1>");
            sb.Append("</div>");
            //Comenzamos con las secciones
            sb.Append("<div class='fs-lg fw-300 p-5 bg-white border-faded rounded mb-g'>");
            foreach (Etcasoscformatoseccion seccion in secciones) {
                sb.Append("<div class='panel-tag'>");
                sb.Append(seccion.DescripcionExterna);
                sb.Append("</div>");
                foreach (EAuxPreviewFormatos variable in variables) { 
                    
                }
            }
            sb.Append("</div>");
            return sb.ToString();
        }

    }
}
