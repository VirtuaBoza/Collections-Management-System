using CoraCorpCM.App.Interfaces;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoraCorpCM.Web.Utilities
{
    public class SelectListMaker : ISelectListMaker
    {
        public IEnumerable<SelectListItem> GetSelections<TNamedMuseumEntity>(IMuseumRepository repository, Museum museum) where TNamedMuseumEntity : class, INamedEntity, IMuseumEntity
        {
            var entities = repository.GetEntitiesAsNoTracking<TNamedMuseumEntity>(museum);
            var selectList = new List<SelectListItem>();
            foreach (var entity in entities)
            {
                selectList.Add(new SelectListItem { Text = entity.Name, Value = entity.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetSelections<TNamedEntity>(IMuseumRepository repository) where TNamedEntity : class, INamedEntity
        {
            var entities = repository.GetEntitiesAsNoTracking<Country>();
            var selectList = new List<SelectListItem>();
            foreach (var entity in entities)
            {
                selectList.Add(new SelectListItem { Text = entity.Name, Value = entity.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetAcquisitionSelections(IMuseumRepository repository, Museum museum)
        {
            var acquisitions = repository.GetEntitiesAsNoTracking<Acquisition>(museum);
            var selectList = new List<SelectListItem>();
            foreach (var acquisition in acquisitions)
            {
                selectList.Add(new SelectListItem { Text = $"{acquisition.Date} {acquisition.PieceSource}", Value = acquisition.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetUnitOfMeasureSelections(IMuseumRepository repository)
        {
            var units = repository.GetEntitiesAsNoTracking<UnitOfMeasure>();
            var selectList = new List<SelectListItem>();
            foreach (var unit in units)
            {
                selectList.Add(new SelectListItem { Text = unit.Abbreviation, Value = unit.Id.ToString() });
            }
            return selectList;
        }
    }
}
