using FluentValidation.Validators;
using NzbDrone.Core.Profiles.Qualities;

namespace NzbDrone.Core.Validation
{
    public class QualityProfileExistsValidator : PropertyValidator
    {
        private readonly IProfileService _profileService;

        public QualityProfileExistsValidator(IProfileService profileService)
        {
            _profileService = profileService;
        }

        protected override string GetDefaultMessageTemplate() => "Quality Profile does not exist";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            return _profileService.Exists((int)context.PropertyValue);
        }
    }
}
