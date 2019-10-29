using Salut.Domain.Enums;

namespace Salut.Domain.Entities {
    public class Identificacao {
        public int Id { get; set; }
        public TipoDocumentoEnum TipoDocumento{ get; set; }
        public string Numero { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
