﻿using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoraCorpCM.Web.Utilities
{
    public class SelectListMaker : ISelectListMaker
    {
        public IEnumerable<SelectListItem> GetAcquisitionSelections(IMuseumRepository repository, Museum museum)
        {
            var acquisitions = repository.GetEntities<Acquisition>(museum);
            var selectList = new List<SelectListItem>();
            foreach (var acquisition in acquisitions)
            {
                selectList.Add(new SelectListItem { Text = $"{acquisition.Date} {acquisition.PieceSource}", Value = acquisition.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetArtistSelections(IMuseumRepository repository, Museum museum)
        {
            var artists = repository.GetEntities<Artist>(museum);
            var selectList = new List<SelectListItem>();
            foreach (var artist in artists)
            {
                selectList.Add(new SelectListItem { Text = artist.Name, Value = artist.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetCollectionSelections(IMuseumRepository repository, Museum museum)
        {
            var collections = repository.GetEntities<Collection>(museum);
            var selectList = new List<SelectListItem>();
            foreach (var collection in collections)
            {
                selectList.Add(new SelectListItem { Text = collection.Name, Value = collection.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetCountrySelections(IMuseumRepository repository)
        {
            var countries = repository.GetCountries();
            var selectList = new List<SelectListItem>();
            foreach (var country in countries)
            {
                selectList.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetGenreSelections(IMuseumRepository repository, Museum museum)
        {
            var genres = repository.GetGenres(museum);
            var selectList = new List<SelectListItem>();
            foreach (var genre in genres)
            {
                selectList.Add(new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetFundingSourceSelections(IMuseumRepository repository, Museum museum)
        {
            var fundingSources = repository.GetFundingSources(museum);
            var selectList = new List<SelectListItem>();
            foreach (var fundingSource in fundingSources)
            {
                selectList.Add(new SelectListItem { Text = fundingSource.Name, Value = fundingSource.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetLocationSelections(IMuseumRepository repository, Museum museum)
        {
            var locations = repository.GetLocations(museum);
            var selectList = new List<SelectListItem>();
            foreach (var location in locations)
            {
                selectList.Add(new SelectListItem { Text = location.Name, Value = location.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetMediumSelections(IMuseumRepository repository, Museum museum)
        {
            var media = repository.GetMedia(museum);
            var selectList = new List<SelectListItem>();
            foreach (var medium in media)
            {
                selectList.Add(new SelectListItem { Text = medium.Name, Value = medium.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetPieceSourceSelections(IMuseumRepository repository, Museum museum)
        {
            var sources = repository.GetPieceSources(museum);
            var selectList = new List<SelectListItem>();
            foreach (var source in sources)
            {
                selectList.Add(new SelectListItem { Text = source.Name, Value = source.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetUnitOfMeasureSelections(IMuseumRepository repository)
        {
            var units = repository.GetUnitsOfMeasure();
            var selectList = new List<SelectListItem>();
            foreach (var unit in units)
            {
                selectList.Add(new SelectListItem { Text = unit.Abbreviation, Value = unit.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetSubgenreSelections(IMuseumRepository repository, Museum museum)
        {
            var subgenres = repository.GetSubgenres(museum);
            var selectList = new List<SelectListItem>();
            foreach (var subgenre in subgenres)
            {
                selectList.Add(new SelectListItem { Text = subgenre.Name, Value = subgenre.Id.ToString() });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetSubjectMatterSelections(IMuseumRepository repository, Museum museum)
        {
            var subjectMatters = repository.GetSubjectMatters(museum);
            var selectList = new List<SelectListItem>();
            foreach (var subjectMatter in subjectMatters)
            {
                selectList.Add(new SelectListItem { Text = subjectMatter.Name, Value = subjectMatter.Id.ToString() });
            }
            return selectList;
        }
    }
}
