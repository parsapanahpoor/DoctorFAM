﻿namespace DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor
{
    public class FilterFamilyDoctorUserPanelSideViewModel
    {
        #region properties

        public ulong? CountryId { get; set; }

        public ulong? StateId { get; set; }

        public ulong? CityId { get; set; }

        public string? Username { get; set; }

        public int? PageId { get; set; } = 1;

        public int? PageCount { get; set; }

        public int? Gender { get; set; }

        public int CountOfFollowers { get; set; }

        public bool YouFollowed { get; set; }

        public ulong? GeneralSpecialityId { get; set; }

        public ulong? specificId { get; set; }

        public bool? IsContactPartyWithFamilyDoctors { get; set; }

        #endregion
    }
}
