#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Domain.Entities.VirtualFile;

public class UsersVirtualFile
{
    #region proeprties

    public ulong UserId { get; set; }

    public string File { get; set; }

    public string FileTitle { get; set; }

    public string? Description { get; set; }

    #endregion
}
