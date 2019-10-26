using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;

namespace WEBSystemServiceManagement
{
    public class LoginController
    {
       
        public bool GrantAccess(LoginModel pModel)
        {
            Repository db = new Repository();

            string ConsultarNome = @"SELECT LOGIN FROM USUARIOS WHERE LOGIN = '" +pModel.LoginName + "';";
            string NomeUser = db.Consultar(ConsultarNome);
            if (NomeUser != pModel.LoginName)
            {
                return false;                
            } else
            {
                string ConsultarSenha = @"SELECT LOGIN FROM USUARIOS WHERE LOGIN = '" + pModel.Password + "';";
                string ConsultarStatus = @"SELECT STATUS_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
                string UserStatus = db.Consultar(ConsultarStatus);
                string UserPassword = db.Consultar(ConsultarSenha);

                if (UserStatus == "D" || UserPassword != pModel.Password)
                {
                    return false;
                } else
                {
                    return true;
                }
             }            
        }

        public void EsqueciMinhaSenha(LoginModel pModel)
        {
            Repository db = new Repository();

            string ConsultarNome = @"SELECT LOGIN FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
            string NomeUser = db.Consultar(ConsultarNome);
            string ConsultarEmail = @"SELECT EMAIL_USUARIO FROM USUARIOS WHERE LOGIN = '" +
                pModel.LoginName + "';";
            pModel.EmailUsuario = db.Consultar(ConsultarEmail);
            string ConsultarSenha = @"SELECT SENHA FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
            pModel.Password = db.Consultar(ConsultarSenha);

            if (pModel.EmailUsuario == "" || pModel.EmailUsuario  == null)
            {
                throw new Exception("E-mail não cadastrado");
            }
            else
            {
                string remetenteEmail = "ssmoperacao@gmail.com";
                MailMessage mail = new MailMessage();
                mail.To.Add(pModel.EmailUsuario);
                mail.From = new MailAddress(remetenteEmail, "SSM", System.Text.Encoding.UTF8);
                mail.Subject = "SSM - Esqueci minha senha";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = @"Olá! Este é um e-mail automático de envio de senha. <br />
                              Se você não solicitou sua senha favor ignorar este e-mail. <br />
                              Caso você ache que há alguém tentando acessar sua conta, recomendamos alterar sua senha imediatamente. <br /><br />
                              Seu senha é: <b>" + pModel.Password + "</b>";

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
            }

        }
        
    }


}
