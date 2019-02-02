using System.Collections.Generic;
using Travel.Models;

namespace TravelMinded.Service
{
    public interface ITravelMindedRepository
    {
        ICompany GetCompany();
        IExperience GetExperience(int experienceId);
        IList<IExperience> GetExperiences();
    }
}