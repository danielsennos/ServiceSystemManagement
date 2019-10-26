using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class LoginController
    {
        Repository SQLConnect = new Repository();
        
        public bool GrantAccess(LoginModel pModel)
        {
            String query = String.Format(@"
                        SELECT LOGIN
                        FROM USUARIOS 
                        where LOGIN = '{1}'",
                        "USUARIOS",
                    pModel.LoginName);

            var Result = SQLConnect.Consultar(query);

            if (Result == null)
            {
                throw new Exception("Usuário Inexistente.");
            } else if (pModel.LoginName == Result)
            {
                query = String.Format(@"
                        SELECT SENHA
                        FROM USUARIOS 
                        where SENHA = '{1}'",
                        "USUARIOS",
                    pModel.LoginName);

                Result = SQLConnect.Consultar(query);
            }

           if (Result == pModel.password)
            {
                return true;
            } else
            {
                return false;
            }

            


            
            

        }
    }


}
