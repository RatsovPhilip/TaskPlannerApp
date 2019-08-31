using System;
using System.Collections.Generic;
using System.Text;
using TaskPlanner.Data;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Service
{
    public interface IProfileService
    {
        void EditCurrentUserProfile(ProfileEditPostViewModel viewModel);
    }
}
