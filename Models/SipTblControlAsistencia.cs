using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblControlAsistencia
    {
        public int SipTblCasId { get; set; }
        public int? SipTblEmpId { get; set; }
        public DateTime? SipTblCasFechaHoraEntrada { get; set; }
        public DateTime? SipTblCasFechaHoraSalida { get; set; }

        public virtual SipTblEmpleado SipTblEmp { get; set; }
    }
}
