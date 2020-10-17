using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblDetallePlanilla
    {
        public int SipTblDplId { get; set; }
        public int? SipTblEplId { get; set; }
        public int? SipTblTreId { get; set; }
        public int? SipTblDedDeducciones { get; set; }
        public int? SipTblDplBonificacion { get; set; }
        public double? SipTblDplIgss { get; set; }
        public double? SipTblDplIrtra { get; set; }
        public double? SipTblDplIsr { get; set; }
        public double? SipTblDplOtros { get; set; }

        public virtual SipTblEncabezadoPlanilla SipTblEpl { get; set; }
        public virtual SipTblTrabajoRealizado SipTblTre { get; set; }
    }
}
