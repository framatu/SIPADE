using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblTrabajoRealizado
    {
        public SipTblTrabajoRealizado()
        {
            SipTblDetallePlanilla = new HashSet<SipTblDetallePlanilla>();
        }

        public int SipTblTreId { get; set; }
        public int SipTblEmpId { get; set; }
        public int SipTblActId { get; set; }
        public double? SipTblTreCantidad { get; set; }
        public double? SipTblTreTotal { get; set; }

        public virtual SipTblTipoActividad SipTblAct { get; set; }
        public virtual SipTblEmpleado SipTblEmp { get; set; }
        public virtual ICollection<SipTblDetallePlanilla> SipTblDetallePlanilla { get; set; }
    }
}
