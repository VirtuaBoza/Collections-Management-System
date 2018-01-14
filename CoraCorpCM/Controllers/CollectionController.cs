using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Data;
using CoraCorpCM.Identity;
using CoraCorpCM.Models;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly IMuseumRepository museumRepository;

        public CollectionController(IMuseumRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userMuseum = museumRepository.GetMuseum(User);
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
            var userMuseum = museumRepository.GetMuseum(User);
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
                Locations = museumRepository.GetLocationSelections(userMuseum),
                FundingSources = museumRepository.GetFundingSourceSelections(userMuseum),
                PieceSources = museumRepository.GetPieceSourceSelections(userMuseum),
                InsurancePolicies = museumRepository.GetInsurancePolicySelections(userMuseum)
            };

            return View(model);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create([Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece)
        {
            if (ModelState.IsValid)
            {
                var userMuseum = museumRepository.GetMuseum(User);
                await museumRepository.CreatePieceForMuseum(piece, userMuseum);
                return RedirectToAction(nameof(Index));
            }
            return View(piece);
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
