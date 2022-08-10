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
using System.Net.Mail;

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
        public bool confirmacionMail(Etusuarios userID)
        {
            MailMessage msg = new MailMessage();
            string body = String.Empty;
            body = @"<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>
                        <tr>
                            <td align='center' style='padding:0;'>
                                <table role='presentation'
                                    style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>
                                    <tr>
                                        <td align='center' style='padding:00px 0 0px 0;background:#ffffff;'> 
                                            <img
                                                src='https://edomex.e-gob.app/ExResources/Plantillas/Web/r2sp52st12nt3d1d/3m1g2n/h1.svg'
                                                alt='' width='550' style='height:auto;display:block;' /></td>
                                    </tr>
                                    <tr>
                                        <td style='padding:0px 30px 42px 30px;'>
                                            <table role='presentation'
                                                style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>
                                                <tr>
                                                    <td style='padding:0 0 36px 0;color:#153643;'>
                                                        <h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Cuenta Desbloqueada | Gobierno Digital</h1>
                                                        <p style='margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'> Estimado usuario,</p>
                                                        <p style='margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'><strong> Su cuenta ha sido desbloqueada de manera exitosa.</strong></p>
                                                        <p style='margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>Si usted desconoce esta actividad, informe a su administrador de sistemas o a su jefe inmediato.</p>
                                                    </td>
                                                </tr>                            
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style='padding:30px;background:#64656A;'>
                                            <table role='presentation'
                                                style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>
                                                <tr>
                                                    <td style='padding:0;width:50%;' align='left'>
                                                        <p
                                                            style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#ffffff;'>
                                                            Gobierno del Estado de México</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>";
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            try  //FW mail
            {
                SmtpClient cliente = new SmtpClient();
                cliente.UseDefaultCredentials = false;
                cliente.Host = Origin.smtpSrv;
                cliente.Port = Origin.smtpPort;
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential(Origin.myMail, Origin.myPw);
                msg.From = new MailAddress("Sistema de verificación de accesos "+Origin.myMail);
                msg.To.Add(new MailAddress(userID.CorreoUsuario));
                msg.Subject = "Sistema de Acceso | Cuenta Desbloqueada";
                msg.Body = body;
                bool send = false;
                try
                {
                    cliente.Send(msg);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    for (int i = 0; i < ex.InnerExceptions.Length; i++)
                    {
                        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                        if (status == SmtpStatusCode.MailboxBusy ||
                            status == SmtpStatusCode.MailboxUnavailable)
                        {
                            Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                            System.Threading.Thread.Sleep(5000);
                            cliente.Send(msg);
                        }
                        else
                        {
                            Console.WriteLine("Failed to deliver message to {0}",
                                ex.InnerExceptions[i].FailedRecipient);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                            ex.ToString());
                }
                finally
                {
                    cliente.Dispose();
                }
                return send;
            }
            catch (Exception e)
            {
                throw e;
            }

        }        
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
