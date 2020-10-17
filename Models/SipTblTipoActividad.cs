using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblTipoActividad
    {
        public SipTblTipoActividad()
        {
            SipTblTrabajoRealizado = new HashSet<SipTblTrabajoRealizado>();
        }

        public int SipTblActId { get; set; }
        public string SipTblActNombre { get; set; }
        public double? SipTblActCostoact { get; set; }

        public virtual ICollection<SipTblTrabajoRealizado> SipTblTrabajoRealizado { get; set; }
    }
}
