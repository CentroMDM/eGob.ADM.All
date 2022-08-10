using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using EntitiesPSR;
using DLLUtilerias;
using System.Data;

namespace DLLEstructuraOrganizacional
{
    public class DesbloqueoDeCuenta
    {
        public List<Etusuarios> busquedaUserID(Etusuarios userID)
        {
            DatosEO IdUser = new DatosEO();
            DataTable dtIdUser = IdUser.busquedaUserID(userID);
            List<Etusuarios> lsUserID = new Utilerias().Convertir<Etusuarios>(dtIdUser);
            return lsUserID;
        }
        public Resultado desbloquearUserID(Etusuarios userID)
        {
            DatosEO IdUser = new DatosEO();
            DataTable dtIdUser = IdUser.desbloquearUserID(userID);
            Resultado lsUserID = new Utilerias().ResultadoDesdeTabla(dtIdUser);
            return lsUserID;
        }
        //public Resultado confirmacionMail(Etusuarios userID)
        //{
        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        //    string body = String.Empty;
        //    body = @"<!DOCTYPE html><html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" /></head><body><br/>---------- Mensaje reenviado ----------<br/>"
        //        + @"<b>De:&nbsp;</b>  Sistema de seguimiento de aclaraciones y trámites &lt;" + Origin.myMail + "&gt;<br/>"
        //        + @"<b>Fecha:&nbsp;</b>"
        //        + @"<b>Asunto:&nbsp;</b>" + "Asunto" + "<br/>"
        //        + @"<b>Para:&nbsp;</b>" + "krys.tresen@gmail.com" + "<br/><br/>"
        //        + @"<blockquote style=""margin-left: 1em; padding-left: 1em; "">"
        //        + @"</blockquote>
        //        </body>
        //        </html>";


        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    {
        //        From = new MailAddress("email"),
        //        Subject = "subject",
        //        Body = "<h1>Hello</h1>",
        //        IsBodyHtml = true,
        //    };
        //    mailMessage.To.Add("recipient");

        //    smtpClient.Send(mailMessage);

        //}

        //public class Reenvio
        //{
            
            
        //    public bool FwRespuestas(FordwardMailParam NuevoDestinatario)
        //    {
        //        ReenviosEmailNotificacion p = new DataFordwardMail().ObtenerDatosRespuesta(NuevoDestinatario.UID);
        //        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        //        string body = String.Empty;
        //        var Fecha = p.Date.ToString("dddd, dd MMMM yyy a la(&#115;)  HH:mm:ss");

        //        body = @"<!DOCTYPE html><html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" /></head><body><br/>---------- Mensaje reenviado ----------<br/>"
        //            + @"<b>De:&nbsp;</b>  Sistema de seguimiento de aclaraciones y trámites &lt;" + Origin.myMail + "&gt;<br/>"
        //            + @"<b>Fecha:&nbsp;</b>" +
        //            //Original.Date.ToShortDateString()
        //            Fecha + "<br/>"
        //            + @"<b>Asunto:&nbsp;</b>" + p.Asunto + "<br/>"
        //            + @"<b>Para:&nbsp;</b>" + p.Email + "<br/><br/>"
        //            + @"<blockquote style=""margin-left: 1em; padding-left: 1em; "">"
        //            + p.HtmlRespuesta
        //            + @"</blockquote>
        //        </body>
        //        </html>";

        //        //AQUI AGREGAR ADJUNTOS
        //        //if (p.ListAttachments.Count > 0)
        //        //{
        //        //    foreach (Archivos A in p.ListAttachments)
        //        //    {
        //        //        msg.Attachments.Add(new System.Net.Mail.Attachment(A.DirectorioFisicoInterno + A.NombreAdjunto));
        //        //    }
        //        //}

        //        msg.SubjectEncoding = System.Text.Encoding.UTF8;
        //        msg.BodyEncoding = System.Text.Encoding.UTF8;
        //        msg.IsBodyHtml = true;

        //        try  //FW mail
        //        {
        //            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
        //            cliente.UseDefaultCredentials = false;
        //            cliente.Host = Origin.smtpSrv;
        //            cliente.Port = Origin.smtpPort;
        //            cliente.EnableSsl = true;
        //            cliente.Credentials = new System.Net.NetworkCredential(Origin.myMail, Origin.myPw);
        //            msg.From = new System.Net.Mail.MailAddress(Origin.myMail);
        //            msg.To.Add(new System.Net.Mail.MailAddress(NuevoDestinatario.NewEmail));
        //            msg.Subject = "RE: " + p.Asunto;
        //            msg.Body = body;
        //            bool send = false;
        //            try
        //            {
        //                cliente.Send(msg);
        //            }
        //            catch (SmtpFailedRecipientsException ex)
        //            {
        //                for (int i = 0; i < ex.InnerExceptions.Length; i++)
        //                {
        //                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
        //                    if (status == SmtpStatusCode.MailboxBusy ||
        //                        status == SmtpStatusCode.MailboxUnavailable)
        //                    {
        //                        Console.WriteLine("Delivery failed - retrying in 5 seconds.");
        //                        System.Threading.Thread.Sleep(5000);
        //                        cliente.Send(msg);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Failed to deliver message to {0}",
        //                            ex.InnerExceptions[i].FailedRecipient);
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
        //                        ex.ToString());
        //            }
        //            finally
        //            {
        //                cliente.Dispose();
        //                new DataFordwardMail().LogReenvio(NuevoDestinatario);
        //                RegistrarPista(NuevoDestinatario);
        //            }
        //            return send;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }


        //    public int RegistrarPista(FordwardMailParam Fwd)
        //    {
        //        List<ModelAuditoria> listCambios = new List<ModelAuditoria>();
        //        ModelAuditoria EnvioRespuesta = new ModelAuditoria();
        //        EnvioRespuesta.ClaveAplicacion = Fwd.ClaveAplicacion;//Buzon
        //        EnvioRespuesta.ClaveUsuario = Fwd.ClaveUsuario;
        //        EnvioRespuesta.ClaveTipoObjeto = 26;
        //        EnvioRespuesta.ClaveObjeto = 1;
        //        EnvioRespuesta.Accion = Accion.Alta;

        //        EnvioRespuesta.Modificaciones.Add("ClaveRespuesta", Fwd.UID.ToString());
        //        EnvioRespuesta.Modificaciones.Add("Email", Fwd.NewEmail.ToString());
        //        listCambios.Add(EnvioRespuesta);

        //        return CtrlAuditoria.RegistrarEvento(listCambios);
        //    }

        //}
        
    }
    static class Origin
    {
        internal const string myMail = "edomex@e-gob.app";
        internal const string myPw = "#3d0m3x@2021!,";
        internal const string smtpSrv = smtpIonos;
        internal const int smtpPort = smtpIonosPort;
        internal const string imapSrv = imapIonos;
        internal const int imapPort = imapIonosPort;
        internal const string MailboxName = "Elementos enviados";

        internal const string imapIonos = "imap.ionos.mx";
        internal const int imapIonosPort = 993;
        internal const string smtpIonos = "smtp.ionos.com";
        internal const int smtpIonosPort = 587;

        internal const string imapGmail = "imap.gmail.com";
        internal const int imapGmailPort = 993;
        internal const string smtpGmail = "smtp.gmail.com";
        internal const int smtpGmailPort = 465;
        internal const int smtpGmailPortTLS = 587;
        internal const int smtpGmailPortSSL = 25;
    }
}
