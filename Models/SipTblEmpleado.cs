using System;
using System.Collections.Generic;

namespace SIPADE.Models
{
    public partial class SipTblEmpleado
    {
        public SipTblEmpleado()
        {
            SipTblControlAsistencia = new HashSet<SipTblControlAsistencia>();
            SipTblTrabajoRealizado = new HashSet<SipTblTrabajoRealizado>();
        }

        public int SipTblEmpId { get; set; }
        public string SipTblEmpNombres { get; set; }
        public string SipTblEmpApellidos { get; set; }
        public string SipTblEmpNit { get; set; }
        public string SipTblEmpDpi { get; set; }
        public string SipTblEmpTel { get; set; }
        public string SipTblEmpDireccion { get; set; }
        public string SipTblEmpNumigss { get; set; }
        public string SipTblEmpNumirtra { get; set; }

        public virtual ICollection<SipTblControlAsistencia> SipTblControlAsistencia { get; set; }
        public virtual ICollection<SipTblTrabajoRealizado> SipTblTrabajoRealizado { get; set; }
    }
}
