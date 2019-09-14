using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class LoginController
    {
        DBConnect SQLConnect = new DBConnect();
        Relatorios pRelatorios = new Relatorios();

        public bool GrantAccess(LoginModel pModel)
        {
            String query = String.Format(@"
                        SELECT LOGIN
                        FROM USUARIOS 
                        where LOGIN = '{1}'",
                        "USUARIOS",
                    pModel.LoginName);

            pRelatorios.Resultado = SQLConnect.Consultar(query);

            if (pRelatorios.Resultado == null)
            {
                throw new Exception("Usuário Inexistente.");
            } else if (pModel.LoginName == pRelatorios.Resultado)
            {
                query = String.Format(@"
                        SELECT SENHA
                        FROM USUARIOS 
                        where SENHA = '{1}'",
                        "USUARIOS",
                    pModel.password);

                pRelatorios.Resultado = SQLConnect.Consultar(query);
            }

           if (pRelatorios.Resultado == pModel.password)
            {
                return true;
            } else
            {
                return false;
            }

            


            
            

        }
    }


}
