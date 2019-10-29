﻿using System;

namespace Salut.Domain.Entities {
    public class Postagem {
        public int Id { get; set; }
        public DateTime DataPublicacao { get; set; }
        public String Text { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }

    }
}
