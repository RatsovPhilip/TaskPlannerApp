namespace TaskPlanner.Service
{
    using ViewModels;

    public interface IProfileService
    {
        void EditCurrentUserProfile(ProfileEditPostViewModel viewModel);
    }
}
