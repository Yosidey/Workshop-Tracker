using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Automotriz
{
    class Validaciones
    {
        public Boolean ValidarCorreo(String correo)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo, expresion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ValidarTelefono(String telefono)
        {
            if (telefono.Trim().Length == 10)
            {
                if (telefono.All(char.IsDigit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
