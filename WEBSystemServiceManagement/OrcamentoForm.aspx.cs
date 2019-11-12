using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WEBSystemServiceManagement
{
    public partial class OrcamentoForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EnviarFormulario(object sender, EventArgs e)
        {
            string Requerente = RequerenteInput.Value;
            string Empresa = OrganizacaoInput.Value;
            string Telefone = TelefoneInput.Value;
            string Email = EmailInput.Value;
            string Resumo = ResumoInput.Value;

            #region Envio de Email
            string remetenteEmail = "ssmoperacao@gmail.com";
            MailMessage mail = new MailMessage();
            mail.To.Add(remetenteEmail);
            mail.From = new MailAddress("systemservice@ssm.com.br", "SSM", System.Text.Encoding.UTF8);
            mail.Subject = "SSM - Novo Contato";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = @"Você recebeu uma nova mensagem!" + "<br />" +
                        "De: " + Requerente + "<br />" +
                        "Telefone:" + Telefone + "<br />" +
                        "E-mail:" + Email + "<br />" +
                        "<br />" + Resumo;

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "est@ciotcc2");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {                
                client.Send(mail);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro com envio do e-mail" + ex);
            }
            #endregion
        }

    }
}