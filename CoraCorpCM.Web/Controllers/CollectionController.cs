using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.App.Interfaces;
using CoraCorpCM.Domain;
using CoraCorpCM.Domain.Models;
using CoraCorpCM.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Web.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IModelMapper modelMapper;
        private readonly ISelectListMaker selectListMaker;
        private readonly IModelValidator modelValidator;

        public CollectionController(
            IMuseumRepository museumRepository,
            UserManager<ApplicationUser> userManager,
            IModelMapper modelMapper,
            ISelectListMaker selectListMaker,
            IModelValidator modelValidator)
        {
            this.museumRepository = museumRepository;
            this.userManager = userManager;
            this.modelMapper = modelMapper;
            this.selectListMaker = selectListMaker;
            this.modelValidator = modelValidator;
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;
            var pieces = museumRepository.GetEntities<Piece>(user.Museum);
            return View(pieces);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = museumRepository.GetEntity<Piece>(id.Value);
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
            var viewModel = new CreatePieceViewModel
            {
                Countries = selectListMaker.GetSelections<Country>(museumRepository),
                UnitsOfMeasure = selectListMaker.GetUnitOfMeasureSelections(museumRepository),
                Media = selectListMaker.GetSelections<Medium>(museumRepository, user.Museum),
                Genres = selectListMaker.GetSelections<Genre>(museumRepository, user.Museum),
                Subgenres = selectListMaker.GetSelections<Subgenre>(museumRepository, user.Museum),
                SubjectMatters = selectListMaker.GetSelections<SubjectMatter>(museumRepository, user.Museum),
                Collections = selectListMaker.GetSelections<Collection>(museumRepository, user.Museum),
                Locations = selectListMaker.GetSelections<Location>(museumRepository, user.Museum),
                KnownArtists = selectListMaker.GetSelections<Artist>(museumRepository, user.Museum),
                Acquisitions = selectListMaker.GetAcquisitionSelections(museumRepository, user.Museum),
                FundingSources = selectListMaker.GetSelections<FundingSource>(museumRepository, user.Museum),
                PieceSources = selectListMaker.GetSelections<PieceSource>(museumRepository, user.Museum)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult Create(CreatePieceViewModel viewModel)
        {
            modelValidator.Validate(ModelState, viewModel);

            if (ModelState.IsValid)
            {
                var user = userManager.GetUserAsync(User).Result;
                var piece = modelMapper.ResolveToPieceModel(viewModel, user.Museum);
                piece.LastModifiedBy = user;
                museumRepository.Insert(piece);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = Role.Contributor)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piece = museumRepository.GetEntity<Piece>(id.Value);
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
        public IActionResult Edit(int id, [Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece)
        {
            if (id != piece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    museumRepository.Update(piece);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!museumRepository.EntityExists<Piece>(piece.Id))
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

            var piece = museumRepository.GetEntity<Piece>(id.Value);
            if (piece == null)
            {
                return NotFound();
            }

            return View(piece);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult DeleteConfirmed(int id)
        {
            museumRepository.Delete<Piece>(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
