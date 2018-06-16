using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Identity;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.Application.Pieces.Queries;
using System.Threading.Tasks;
using System;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;

namespace CoraCorpCM.Web.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGetPieceListQuery getPieceListQuery;
        private readonly ICreatePieceViewModelFactory createPieceViewModelFactory;
        private readonly ICreatePieceCommandFacade createCommand;
        private readonly ICreatePieceViewModelMapper mapper;

        public CollectionController(
            UserManager<ApplicationUser> userManager,
            ICreatePieceViewModelFactory createPieceViewModelFactory,
            IGetPieceListQuery getPieceListQuery,
            ICreatePieceCommandFacade createCommand,
            ICreatePieceViewModelMapper mapper)
        {
            this.userManager = userManager;
            this.createPieceViewModelFactory = createPieceViewModelFactory;
            this.getPieceListQuery = getPieceListQuery;
            this.createCommand = createCommand;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var pieces = getPieceListQuery.Execute(user.MuseumId);

            return View(pieces);
        }

        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(User);
            var viewModel = createPieceViewModelFactory.Create(user.MuseumId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public async Task<IActionResult> Create(CreatePieceViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                var piece = ParsePiece(viewModel, user);

                createCommand.Execute(piece);
                return RedirectToAction(nameof(Index));
            }

            var newViewModel = createPieceViewModelFactory.Create(user.MuseumId, viewModel);
            return View(newViewModel);
        }

        [Authorize(Roles = Role.Contributor)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // TODO Create EditPieceViewModel and return that via View(viewModel);
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult Edit(int id/* TODO Replace this second param with viewModel, [Bind("Id,RecordNumber,AccessionNumber,Title,CreationDate,Height,Width,Depth,EstimatedValue,Subject,CopyrightYear,CopyrightOwner,IsFramed,Created,LastModified")] Piece piece*/)
        {
            //if (id != piece.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        museumRepository.Update(piece);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!museumRepository.EntityExists<Piece>(piece.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(piece);
            return null;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Contributor)]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO Delete piece
            return RedirectToAction(nameof(Index));
        }

        private CreatePieceModel ParsePiece(CreatePieceViewModel viewModel, ApplicationUser user)
        {
            var piece = mapper.MapToCreatePieceModel(viewModel, user.MuseumId, user.Id);

            piece.AcquisitionId = ParseAcquisition(viewModel, user);

            if (viewModel.PieceArtistId == -1)
            {
                piece.ArtistId = createCommand.Execute(mapper.MapToCreateArtistModel(viewModel, user.MuseumId));
            }

            if (viewModel.PieceCollectionId == -1)
            {
                piece.CollectionId = createCommand.Execute(mapper.MapToCreateCollectionModel(viewModel, user.MuseumId));
            }

            if (viewModel.PieceCurrentLocationId == -1)
            {
                piece.CurrentLocationId = createCommand.Execute(mapper.MapPermanentLocationToCreateLocationModel(viewModel, user.MuseumId));
            }

            if (viewModel.PiecePermanentLocationId == -1)
            {
                piece.PermanentLocationId = createCommand.Execute(mapper.MapCurrentLocationToCreateLocationModel(viewModel, user.MuseumId));
            }
            else if (viewModel.PiecePermanentLocationId == -2)
            {
                piece.PermanentLocationId = piece.CurrentLocationId;
            }

            if (viewModel.PieceGenreId == -1)
            {
                piece.GenreId = createCommand.Execute(mapper.MapToCreateGenreModel(viewModel, user.MuseumId));
            }

            if (viewModel.PieceMediumId == -1)
            {
                piece.MediumId = createCommand.Execute(mapper.MapToCreateMediumModel(viewModel, user.MuseumId));
            }

            if (viewModel.PieceSubgenreId == -1)
            {
                piece.SubgenreId = createCommand.Execute(mapper.MapToCreateSubgenreModel(viewModel, user.MuseumId));
            }

            if (viewModel.PieceSubjectMatterId == -1)
            {
                piece.SubjectMatterId = createCommand.Execute(mapper.MapToCreateSubjectMatterModel(viewModel, user.MuseumId));
            }

            return piece;
        }

        private int? ParseAcquisition(CreatePieceViewModel viewModel, ApplicationUser user)
        {
            var acquisition = mapper.MapToCreateAcquisitionModel(viewModel, user.MuseumId);

            if (viewModel.AcquisitionFundingSourceId == -1)
            {
                acquisition.FundingSourceId = createCommand.Execute(mapper.MapToCreateFundingSourceModel(viewModel, user.MuseumId));
            }

            if (viewModel.AcquisitionPieceSourceId == -1)
            {
                acquisition.PieceSourceId = createCommand.Execute(mapper.MapToCreatePieceSourceModel(viewModel, user.MuseumId));
            }

            return createCommand.Execute(acquisition);
        }
    }
}
