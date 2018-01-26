using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Data;
using CoraCorpCM.Identity;
using CoraCorpCM.Models;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace CoraCorpCM.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CollectionController(IMuseumRepository museumRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.museumRepository = museumRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = userManager.GetUserAsync(User).Result;
            var userMuseum = museumRepository.GetMuseum(user);
            var pieces = await museumRepository.GetAllPiecesForMuseum(userMuseum);
            return View(pieces);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await museumRepository.GetPiece(id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        [Authorize(Roles = Role.Contributor)]
        public IActionResult Create()
        {
            var user = userManager.GetUserAsync(User).Result;
            var userMuseum = museumRepository.GetMuseum(user);
            var model = new CreatePieceViewModel
            {
                Countries = museumRepository.GetCountrySelections(),
                UnitsOfMeasure = museumRepository.GetUnitOfMeasureSelections(),

                Media = museumRepository.GetMediumSelections(userMuseum),
                Genres = museumRepository.GetGenreSelections(userMuseum),
                Subgenres = museumRepository.GetSubgenreSelections(userMuseum),
                SubjectMatters = museumRepository.GetSubjectMatterSelections(userMuseum),
                KnownArtists = museumRepository.GetArtistSelections(userMuseum),
                Acquisitions = museumRepository.GetAcquisitionSelections(userMuseum),
                FundingSources = museumRepository.GetFundingSourceSelections(userMuseum),
                PieceSources = museumRepository.GetPieceSourceSelections(userMuseum)
            };

            return View(model);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create(CreatePieceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(!ValidateArtist(model))
                {
                    ModelState.AddModelError("ArtistName", "New Artist must have a name.");
                    return View(model);
                }

                if (!ValidateAcquisition(model))
                {
                    ModelState.AddModelError("AcquisitionDate", "New Acquisition must have either date or source.");
                    ModelState.AddModelError("PieceSourceId", "New Acquisition must have either date or source.");
                    return View(model);
                }

                ResolveCreatePieceViewModelToPieceModel(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private async void ResolveCreatePieceViewModelToPieceModel(CreatePieceViewModel model)
        {
            var user = userManager.GetUserAsync(User).Result;
            var userMuseum = museumRepository.GetMuseum(user);

            Artist artist;
            if (int.TryParse(model.ArtistId, out int artistId))
            {
                if (artistId == -1)
                {
                    artist = new Artist
                    {
                        Name = model.ArtistName,
                        AlsoKnownAs = model.ArtistAlsoKnownAs,
                        CityOfOrigin = model.ArtistCity,
                        StateOfOrigin = model.ArtistState,
                    };

                    if (int.TryParse(model.ArtistCountryId, out int countryId))
                    {
                        artist.CountryOfOrigin = museumRepository.GetCountry(countryId);
                    }
                    
                    if (DateTime.TryParse(model.ArtistBirthdate, out DateTime birthdate))
                    {
                        artist.Birthdate = birthdate;
                    }

                    if (DateTime.TryParse(model.ArtistDeathdate, out DateTime deathdate))
                    {
                        artist.Deathdate = deathdate;
                    }
                }
                else
                {
                    artist = await museumRepository.GetArtist(artistId);
                }
            }

            Acquisition acquisition;
            if (int.TryParse(model.AcquisitionId, out int acquisitionId))
            {
                if (acquisitionId == -1)
                {
                    acquisition = new Acquisition
                    {
                        Cost = model.Cost,
                        Terms = model.Terms
                    };

                    if (DateTime.TryParse(model.AcquisitionDate, out DateTime acquisitionDate))
                    {
                        acquisition.Date = acquisitionDate;
                    }

                    if (int.TryParse(model.PieceSourceId, out int pieceSourceId))
                    {
                        if (pieceSourceId == -1 && !string.IsNullOrWhiteSpace(model.PieceSourceName))
                        {
                            acquisition.PieceSource = new PieceSource
                            {
                                Name = model.PieceSourceName,
                                Museum = userMuseum
                            };
                        }
                        else
                        {
                            acquisition.PieceSource = museumRepository.GetPieceSource
                        }
                    }
                }
            }
        }

        private bool ValidateArtist(CreatePieceViewModel model)
        {
            if (model.ArtistId == "-1" && string.IsNullOrWhiteSpace(model.ArtistName))
            {
                return false;
            }

            return true;
        }

        private bool ValidateAcquisition(CreatePieceViewModel model)
        {
            if (model.AcquisitionId == "-1" && string.IsNullOrWhiteSpace(model.AcquisitionDate) && 
                (string.IsNullOrWhiteSpace(model.PieceSourceId) ||
                 model.PieceSourceId == "-1" && string.IsNullOrWhiteSpace(model.PieceSourceName)))
            {
                return false;
            }

            return true;
        }
                
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await museumRepository.GetPiece(id);
            if (piece == null)
            {
                return NotFound();
            }
            return View(piece);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece)
        {
            if (id != piece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await museumRepository.UpdatePiece(piece);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!museumRepository.PieceExists(piece.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(piece);
        }

        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = await museumRepository.GetPiece(id);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await museumRepository.DeletePiece(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
