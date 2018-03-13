using System.Collections.Generic;
using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoraCorpCM.Web.Utilities
{
    public interface ISelectListMaker
    {
        IEnumerable<SelectListItem> GetSelections<TNamedMuseumEntity>(IMuseumRepository repository, Museum museum) where TNamedMuseumEntity : class, INamedEntity, IMuseumEntity;
        IEnumerable<SelectListItem> GetSelections<TNamedEntity>(IMuseumRepository repository) where TNamedEntity : class, INamedEntity;
        IEnumerable<SelectListItem> GetAcquisitionSelections(IMuseumRepository repository, Museum museum);
        IEnumerable<SelectListItem> GetUnitOfMeasureSelections(IMuseumRepository repository);
    }
}