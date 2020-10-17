using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblEncabezadoPlanilla
    {
        public SipTblEncabezadoPlanilla()
        {
            SipTblDetallePlanilla = new HashSet<SipTblDetallePlanilla>();
        }

        public int SipTblEplId { get; set; }
        public DateTime? SipTblEplFechahora { get; set; }
        public DateTime? SipTblEplFechainicio { get; set; }
        public DateTime? SipTblEplFechafin { get; set; }

        public virtual ICollection<SipTblDetallePlanilla> SipTblDetallePlanilla { get; set; }
    }
}
