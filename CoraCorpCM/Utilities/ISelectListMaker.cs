using System.Collections.Generic;
using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoraCorpCM.Web.Utilities
{
    public interface ISelectListMaker
    {
        IEnumerable<SelectListItem> GetAcquisitionSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetArtistSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetCollectionSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetCountrySelections(IMuseumRepository repository);
        IEnumerable<SelectListItem> GetFundingSourceSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetLocationSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetGenreSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetMediumSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetPieceSourceSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetSubgenreSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetSubjectMatterSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetUnitOfMeasureSelections(IMuseumRepository repository);
    }
}