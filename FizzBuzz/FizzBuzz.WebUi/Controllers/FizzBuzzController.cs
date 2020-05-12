using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using FizzBuzz.Domain.Abstract;
using FizzBuzz.WebUi.ViewModels.FizzBuzz;

namespace FizzBuzz.WebUi.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzGenerator _fizzBuzzGenerator;
        private readonly ISettingsStore _settingsStore;
        private readonly IPager _pager;
        private readonly IUserInputLogger _userInputLogger;

        public FizzBuzzController(
            IFizzBuzzGenerator fizzBuzzGenerator, 
            ISettingsStore settingsStore, 
            IPager pager,
            IUserInputLogger userInputLogger)
        {
            _fizzBuzzGenerator = fizzBuzzGenerator ?? throw new ArgumentNullException(nameof(fizzBuzzGenerator));
            _settingsStore = settingsStore ?? throw new ArgumentNullException(nameof(settingsStore));
            _pager = pager ?? throw new ArgumentNullException(nameof(pager));
            _userInputLogger = userInputLogger ?? throw new ArgumentNullException(nameof(userInputLogger));
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View("Results", new FizzBuzzViewModel());
        }

        public async Task<ActionResult> Results(FizzBuzzViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            ViewBag.Title = "Results Page";
            if (ModelState.IsValid)
            {
                var maxValue = Convert.ToInt32(model.MaxValue);
                var items = _fizzBuzzGenerator.Generate(1, maxValue);
                if (_pager.HasPage(items, 20, model.PageNumber))
                {
                    await _userInputLogger.LogAsync(maxValue, model.PageNumber);
                    return View(new FizzBuzzViewModel
                    {
                        MaxValue = model.MaxValue,
                        FizzWord = _settingsStore.FizzWord,
                        BuzzWord = _settingsStore.BuzzWord,
                        FizzBuzzItems = _pager.GetPage(items, 20, model.PageNumber),
                        PageNumber = model.PageNumber,
                        HasPreviousPage = _pager.HasPage(items, 20, model.PageNumber-1),
                        HasNextPage = _pager.HasPage(items, 20, model.PageNumber + 1)
                    });    
                }
                return RedirectToAction("Results", new {MaxValue = model.MaxValue, PageNumber = 1});
            }
            return View(new FizzBuzzViewModel
            {
                MaxValue = model.MaxValue
            });
        }
    }
}