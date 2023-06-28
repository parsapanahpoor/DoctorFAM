#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.NavBar;

#endregion

public class ConsultantPanelNavNarViewModel
{

    #region properties

    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string UserAvatar { get; set; }

    public int UserBalance { get; set; }

    #endregion

}
