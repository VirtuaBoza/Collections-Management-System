using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Data;
using CoraCorpCM.Domain;
using CoraCorpCM.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using CoraCorpCM.Utilities;

namespace CoraCorpCM.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IModelMapper modelMapper;

        public CollectionController(
            IMuseumRepository museumRepository,
            UserManager<ApplicationUser> userManager,
            IModelMapper modelMapper)
        {
            this.museumRepository = museumRepository;
            this.userManager = userManager;
            this.modelMapper = modelMapper;
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;
            var userMuseum = museumRepository.GetMuseum(user);
            var pieces = museumRepository.GetAllPiecesForMuseum(userMuseum);
            return View(pieces);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = museumRepository.GetPiece(id);
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
            var model = new PieceViewModel
            {
                Countries = SelectListMaker.GetCountrySelections(museumRepository),
                UnitsOfMeasure = SelectListMaker.GetUnitOfMeasureSelections(museumRepository),
                Media = SelectListMaker.GetMediumSelections(museumRepository, userMuseum),
                Genres = SelectListMaker.GetGenreSelections(museumRepository, userMuseum),
                Subgenres = SelectListMaker.GetSubgenreSelections(museumRepository, userMuseum),
                SubjectMatters = SelectListMaker.GetSubjectMatterSelections(museumRepository, userMuseum),
                Collections = SelectListMaker.GetCollectionSelections(museumRepository, userMuseum),
                Locations = SelectListMaker.GetLocationSelections(museumRepository, userMuseum),
                KnownArtists = SelectListMaker.GetArtistSelections(museumRepository, userMuseum),
                Acquisitions = SelectListMaker.GetAcquisitionSelections(museumRepository, userMuseum),
                FundingSources = SelectListMaker.GetFundingSourceSelections(museumRepository, userMuseum),
                PieceSources = SelectListMaker.GetPieceSourceSelections(museumRepository, userMuseum)
            };

            return View(model);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult Create(PieceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!ValidateArtist(viewModel))
                {
                    ModelState.AddModelError("ArtistName", "New Artist must have a name.");
                    return View(viewModel);
                }

                if (!ValidateAcquisition(viewModel))
                {
                    ModelState.AddModelError("AcquisitionDate", "New Acquisition must have either date or source.");
                    ModelState.AddModelError("PieceSourceId", "New Acquisition must have either date or source.");
                    return View(viewModel);
                }

                if (!ValidatePermanentLocation(viewModel))
                {
                    ModelState.AddModelError("PermanentLocationName", "New locations must have a name.");
                }

                if (!ValidateCurrentLocation(viewModel))
                {
                    ModelState.AddModelError("CurrentLocationName", "New locations must have a name.");
                }

                var user = userManager.GetUserAsync(User).Result;
                var piece = modelMapper.ResolveToPieceModel(viewModel, user);
                museumRepository.AddPiece(piece);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        private bool ValidateCurrentLocation(PieceViewModel model)
        {
            if (model.CurrentLocationId == "-2")
            {
                model.CurrentLocationId = model.PermanentLocationId;
                model.CurrentLocationName = model.PermanentLocationName;
                model.CurrentAddress1 = model.PermanentAddress1;
                model.CurrentAddress2 = model.PermanentAddress2;
                model.CurrentCity = model.PermanentCity;
                model.CurrentState = model.PermanentState;
                model.CurrentZipCode = model.PermanentZipCode;
                model.CurrentCountryId = model.PermanentCountryId;
            }

            if (model.CurrentLocationId == "-1" && string.IsNullOrWhiteSpace(model.CurrentLocationName))
            {
                return false;
            }

            return true;
        }

        private bool ValidatePermanentLocation(PieceViewModel model)
        {
            if (model.PermanentLocationId == "-1" && string.IsNullOrWhiteSpace(model.PermanentLocationName))
            {
                return false;
            }

            return true;
        }

        private bool ValidateArtist(PieceViewModel model)
        {
            if (model.ArtistId == "-1" && string.IsNullOrWhiteSpace(model.ArtistName))
            {
                return false;
            }

            return true;
        }

        private bool ValidateAcquisition(PieceViewModel model)
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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = museumRepository.GetPiece(id);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = museumRepository.GetPiece(id);
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
