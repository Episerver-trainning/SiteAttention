using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using rdContentArea.Models.Pages;
using rdContentArea.Models.ViewModels;
using EPiServer.Web;
using EPiServer;

namespace rdContentArea.SaCustomization
{
    // todo: can it work as a epi datastore?
    public class SaContentAreaController : Controller
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentVersionRepository _contentVersionRepository;

        public SaContentAreaController(
            IContentLoader contentLoader,
            IContentVersionRepository contentVersionRepository)
        {
            _contentLoader = contentLoader;
            _contentVersionRepository = contentVersionRepository;
        }

        public ActionResult Index()
        {
            // todo: check acl.
            // todo: the parameters should be the name of the property and the current content id, based the parameters load data based on the two latest version.

            var pageVersions = _contentVersionRepository.List(SiteDefinition.Current.StartPage);
            var newVersion = _contentLoader.Get<StartPage>(pageVersions.Select(p => p.ContentLink).OrderByDescending(p => p.WorkID).FirstOrDefault());
            var oldVersion = _contentLoader.Get<StartPage>(pageVersions.Where(p => p.ContentLink.CompareTo(newVersion.ContentLink) != 0).Select(p => p.ContentLink).OrderBy(p => p.WorkID).FirstOrDefault());

            var viewModel = new SaContentAreaViewModel();
            viewModel.OldContentArea = oldVersion.MainContentArea;
            viewModel.NewContentArea = newVersion.MainContentArea;

            // Todo: use with RazorRender?
            return View("~/SaCustomization/Views/Index.cshtml", viewModel);
        }      
    }
}
