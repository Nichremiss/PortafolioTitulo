using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CentroMedico.Negocio
{
    [DataContract]
    public class MensajeWCF<T>
    {
        [DataMember]
        public bool CodigoError { get; set; }
        [DataMember]
        public List<T> Contenido { get; set; }
    }
}
