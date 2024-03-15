using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;

namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDoctorsPage;

public record HealthCenterDoctorsPageQueryHandler : IRequestHandler<HealthCenterDoctorsPageQuery, HealthCenterDoctorsPageSiteSideDTO>
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;
    private readonly ISpecialityRepository _specialityRepository;

    public HealthCenterDoctorsPageQueryHandler(IHealthCentersRepository healthCentersRepository,
                                          ISpecialityRepository specialityRepository)
    {
        _healthCentersRepository = healthCentersRepository;
        _specialityRepository = specialityRepository;
    }

    #endregion

    public async Task<HealthCenterDoctorsPageSiteSideDTO?> Handle(HealthCenterDoctorsPageQuery request, CancellationToken cancellationToken)
    {
        #region Is Health Center Accepted And Exist 

        if (!await _healthCentersRepository.IsHealthCenter_AcceptedAndExist(request.HealthCenterId, cancellationToken))
            return null;

        #endregion

        //Initial Model 
        var model = new HealthCenterDoctorsPageSiteSideDTO()
        {
            HealthCenterId = request.HealthCenterId,    
            SpecialityTitle = request.SpecialityTitle,
        };

        //Get List Of Health Center Accepted Doctors User Id
        var healthCenterDoctorsIds = await _healthCentersRepository.GetList_OfHealthCenterAcceptedDoctorsId_ByHealthCenterInformations(request.HealthCenterId,
                                                                                                                                           cancellationToken);

        //Get List Of Specialty Children 
        List<ulong> specialitiesIds = await _specialityRepository.GetListOfSpecialitiesChildrenIds_BySpecialityParentId(request.SpecialityId, 
                                                                                                                        cancellationToken);
        specialitiesIds.Add(request.SpecialityId);

        if (healthCenterDoctorsIds != null && healthCenterDoctorsIds.Any())
        {
            List<HealthCenterDoctorDetailSiteSideDTO> doctors = new List<HealthCenterDoctorDetailSiteSideDTO>();

            foreach (var doctorId in healthCenterDoctorsIds)
            {
                foreach (var specialityId in specialitiesIds)
                {
                    if (await _healthCentersRepository.HasDoctor_SelectedCurrentSpeciality_ByDoctorIdAndSpecialityId(doctorId , specialityId , cancellationToken))
                    {
                        if (doctors.Count == 0)
                        {
                            doctors.Add(await _healthCentersRepository.FillHealthCenterDoctorDetailSiteSideDTO_ByDoctorId(doctorId,
                                                                                                                          cancellationToken));
                        }

                        if (doctors != null &&  !doctors.Any(p=> p.DoctorInfo.DoctorId == doctorId))
                        {
                            doctors.Add(await _healthCentersRepository.FillHealthCenterDoctorDetailSiteSideDTO_ByDoctorId(doctorId,
                                                                                                                          cancellationToken));
                        }
                    }
                }
            }

            model.Doctors = doctors;
        }

        return model;
    }
}