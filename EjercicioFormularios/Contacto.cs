using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFormularios
{
    // MATI: A las clases que vas creando hay que ponerles public (normalmente vienen con internal), esto es para que se puedan usar de todos lados
    public class Contacto
    {
        // MATI: Acá por ejemplo le ponemos public a las propiedades para que puedan accederse desde fuera de la clase, si no ponemos public solo se pueden acceder desde dentro de esta clase
        public String Nombre { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return Nombre + "-" + Edad;
        }
    }
}
