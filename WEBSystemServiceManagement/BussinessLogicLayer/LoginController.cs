using System;
using System.Net.Mail;

namespace WEBSystemServiceManagement
{
    public class LoginController
    {

        public bool GrantAccess(LoginModel pModel)
        {
            Repository db = new Repository();

            string ConsultarNome = @"SELECT LOGIN FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
            string NomeUser = db.Consultar(ConsultarNome);
            if (NomeUser != pModel.LoginName)
            {
                return false;
            }
            else
            {
                string ConsultarSenha = @"SELECT SENHA FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
                string ConsultarStatus = @"SELECT STATUS_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';";
                string UserStatus = db.Consultar(ConsultarStatus);
                string UserPassword = db.Consultar(ConsultarSenha);



                if (UserStatus == "D" || UserPassword != pModel.Password)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void EsqueciMinhaSenha(LoginModel pModel)
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
            client.Port = 580; //587
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro com envio do e-mail" + ex);
                //throw new Exception("Ocorreu um erro com envio do e-mail" + ex);
            }

        }

        public int ConsultarPermissao(LoginModel pModel)
        {
            Repository db = new Repository();
            String ConsultaPermissao = @"SELECT us.id_permissao FROM permissoes_usuarios pu
                                            join usuarios us on us.id_permissao = pu.id_permissao
                                            where pu.status_permissao = 'A' and us.login = '" + pModel.LoginName + "'";
            pModel.idPermissao = db.ConsultaInt(ConsultaPermissao);

            return pModel.idPermissao;
        }

        public string ConsultarNomeUser(LoginModel pModel)
        {
            Repository db = new Repository();
            String ConsultaNome = @"SELECT NOME_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "'";
            pModel.NomeUsuario = db.Consultar(ConsultaNome);

            return pModel.NomeUsuario;
        }
        public string ConsultarIdUser(LoginModel pModel)
        {
            Repository db = new Repository();
            String ConsultaIdUser = @"SELECT ID_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "'";
            pModel.idUser = (db.ConsultaInt(ConsultaIdUser)).ToString();

            return pModel.idUser;
        }

        public void AlterarSenha(LoginModel pModel)
        {
            Repository db = new Repository();

            string UpateSenha = @"UPDATE USUARIOS SET SENHA = '" + pModel.Password + "'" +
                " WHERE ID_USUARIO = " + pModel.idUser;

            db.Update(UpateSenha);

            pModel.EmailUsuario = db.Consultar("SELECT EMAIL_USUARIO FROM USUARIOS WHERE ID_USUARIO =" + pModel.idUser);


            #region notificação por e-mail
            string remetenteEmail = "ssmoperacao@gmail.com";
            MailMessage mail = new MailMessage();
            mail.To.Add(pModel.EmailUsuario);
            mail.From = new MailAddress(remetenteEmail, "SSM", System.Text.Encoding.UTF8);
            mail.Subject = "SSM - Sua senha foi alterada";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = @"Olá! Este é um e-mail automático. <br />
                              Sua senha foi alterada com sucesso. <br />
                              Caso você ache que há alguém acessando sua conta, recomendamos entrar em contato com o administrador do sistema. <br /><br />
                              Seu nova senha é: <b>" + pModel.Password + "</b>";

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
                Console.WriteLine("Ocorreu um erro com envio do e-mail" + ex);
            }
            #endregion
        }

    }


}
