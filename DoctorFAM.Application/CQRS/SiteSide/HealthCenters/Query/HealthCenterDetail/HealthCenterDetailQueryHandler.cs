using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDetail;

public record HealthCenterDetailQueryHandler : IRequestHandler<HealthCenterDetailQuery, HealthCenterDetailSiteSideDTO>
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;
    private readonly ISpecialityRepository _specialityRepository;

    public HealthCenterDetailQueryHandler(IHealthCentersRepository healthCentersRepository,
                                          ISpecialityRepository specialityRepository)
    {
        _healthCentersRepository = healthCentersRepository;
        _specialityRepository = specialityRepository;
    }

    #endregion

    public async Task<HealthCenterDetailSiteSideDTO?> Handle(HealthCenterDetailQuery request, CancellationToken cancellationToken)
    {
        #region Is Health Center Accepted And Exist 

        if (!await _healthCentersRepository.IsHealthCenter_AcceptedAndExist(request.HealthCenterId, cancellationToken))
            return null;

        #endregion

        #region Fill Model 

        var model = await _healthCentersRepository.Fill_HealthCenterDetailSiteSideDTO_ByHealthCenterId(request.HealthCenterId,
                                                                                                       cancellationToken);
        if (model == null) return null;

        #region Doctors

        //Get List Of Health Center Accepted Doctors User Id
        var healthCenterDoctorsUserIds = await _healthCentersRepository.GetList_OfHealthCenterAcceptedDoctorsUserId_ByHealthCenterInformations(request.HealthCenterId,
                                                                                                                                               cancellationToken);
        if (healthCenterDoctorsUserIds != null && healthCenterDoctorsUserIds.Any())
        {
            //Add Doctors Info To Model 
            List<DoctorsMiniInfoDTO> listOfDoctorsMiniInfoDTO = new List<DoctorsMiniInfoDTO>();

            foreach (var doctorUserId in healthCenterDoctorsUserIds)
            {
                var doctorMiniInfo = await _healthCentersRepository.FillDoctorsMiniInfoDTO_ByHealthCenterDoctorsUserIds(doctorUserId,
                                                                                                                     cancellationToken);

                if (doctorMiniInfo != null)
                {
                    listOfDoctorsMiniInfoDTO.Add(doctorMiniInfo);
                }
            }

            model.DoctorsInfo = listOfDoctorsMiniInfoDTO;

            //Initial Speciality Item 
            List<SpecialitiesInfo> specialitiesInfos = new List<SpecialitiesInfo>();

            #region قلب 

            //قلب و عروق
            List<ulong> specialityIds1 = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(5, cancellationToken);
            specialityIds1.Add(5);
            if (specialityIds1 != null && specialityIds1.Any())
            {
                foreach (var specialityId in specialityIds1)
                {
                    if (model.DoctorsInfo.Any(p => p.SpecialitiesIds.Contains(specialityId)))
                    {
                        foreach (var doctor in model.DoctorsInfo.Where(p => p.SpecialitiesIds.Contains(specialityId)))
                        {
                            if (!specialitiesInfos.Any(p => p.SpecialityId == 5 && p.Doctor == doctor))
                            {
                                specialitiesInfos.Add(new SpecialitiesInfo()
                                {
                                    Doctor = doctor,
                                    SpecialityId = 5,
                                    SpecialityName = "قلب"
                                });
                            }
                        }
                    }
                }
            }

            #endregion

            #region دیابت

            #endregion

            #region نورولوژی

            #endregion

            #region چشم

            //متخصص چشم
            List<ulong> specialityIds4 = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(10029, cancellationToken);
            specialityIds4.Add(10029);
            if (specialityIds4 != null && specialityIds4.Any())
            {
                foreach (var specialityId in specialityIds4)
                {
                    if (model.DoctorsInfo.Any(p => p.SpecialitiesIds.Contains(specialityId)))
                    {
                        foreach (var doctor in model.DoctorsInfo.Where(p => p.SpecialitiesIds.Contains(specialityId)))
                        {
                            if (!specialitiesInfos.Any(p => p.SpecialityId == 5 && p.Doctor == doctor))
                            {
                                specialitiesInfos.Add(new SpecialitiesInfo()
                                {
                                    Doctor = doctor,
                                    SpecialityId = 10029,
                                    SpecialityName = "چشم"
                                });
                            }
                        }
                    }
                }
            }

            #endregion

            #region ارتوپدی

            //متخصص ارتوپدی
            List<ulong> specialityIds5 = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(10020, cancellationToken);
            specialityIds5.Add(10020);
            if (specialityIds5 != null && specialityIds5.Any())
            {
                foreach (var specialityId in specialityIds5)
                {
                    if (model.DoctorsInfo.Any(p => p.SpecialitiesIds.Contains(specialityId)))
                    {
                        foreach (var doctor in model.DoctorsInfo.Where(p => p.SpecialitiesIds.Contains(specialityId)))
                        {
                            if (!specialitiesInfos.Any(p => p.SpecialityId == 5 && p.Doctor == doctor))
                            {
                                specialitiesInfos.Add(new SpecialitiesInfo()
                                {
                                    Doctor = doctor,
                                    SpecialityId = 10020,
                                    SpecialityName = "ارتوپدی"
                                });
                            }
                        }
                    }
                }
            }

            #endregion

            #region عفونی


            #endregion

            #region جراحی

            //متخصص جراحی عمومی
            List<ulong> specialityIds7 = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(10025, cancellationToken);
            specialityIds7.Add(10025);
            if (specialityIds7 != null && specialityIds7.Any())
            {
                foreach (var specialityId in specialityIds7)
                {
                    if (model.DoctorsInfo.Any(p => p.SpecialitiesIds.Contains(specialityId)))
                    {
                        foreach (var doctor in model.DoctorsInfo.Where(p => p.SpecialitiesIds.Contains(specialityId)))
                        {
                            if (!specialitiesInfos.Any(p => p.SpecialityId == 5 && p.Doctor == doctor))
                            {
                                specialitiesInfos.Add(new SpecialitiesInfo()
                                {
                                    Doctor = doctor,
                                    SpecialityId = 10025,
                                    SpecialityName = "جراحی"
                                });
                            }
                        }
                    }
                }
            }

            #endregion

            #region گوارش


            #endregion

            #region داخلی

            //متخصص داخلی
            List<ulong> specialityIds9 = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(2, cancellationToken);
            specialityIds9.Add(2);
            if (specialityIds9 != null && specialityIds9.Any())
            {
                foreach (var specialityId in specialityIds9)
                {
                    if (model.DoctorsInfo.Any(p => p.SpecialitiesIds.Contains(specialityId)))
                    {
                        foreach (var doctor in model.DoctorsInfo.Where(p => p.SpecialitiesIds.Contains(specialityId)))
                        {
                            if (!specialitiesInfos.Any(p => p.SpecialityId == 5 && p.Doctor == doctor))
                            {
                                specialitiesInfos.Add(new SpecialitiesInfo()
                                {
                                    Doctor = doctor,
                                    SpecialityId = 2,
                                    SpecialityName = "داخلی"
                                });
                            }
                        }
                    }
                }
            }

            #endregion

            model.Specialities = specialitiesInfos;
        }

        #endregion

        #endregion

        return model;
    }
}
