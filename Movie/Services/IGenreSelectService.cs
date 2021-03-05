using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Services
{
    public interface IGenreSelectService
    {
        Task<IEnumerable<SelectListItem>> GetGenresAsync();
    }
}