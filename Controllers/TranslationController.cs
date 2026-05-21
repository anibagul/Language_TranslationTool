using CodeAlpha_LanguageTranslationTool.Models;
using CodeAlpha_LanguageTranslationTool.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_LanguageTranslationTool.Controllers
{
    public class TranslationController : Controller
    {
        private readonly TranslatorService _translatorService;

        public TranslationController(TranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TranslationViewModel
            {
                SourceLanguage = "auto",
                TargetLanguage = "ur"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(TranslationViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.InputText))
            {
                ViewBag.Error = "Please enter text to translate.";
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.TargetLanguage))
            {
                ViewBag.Error = "Please select target language.";
                return View(model);
            }

            model.TranslatedText = await _translatorService.TranslateTextAsync(
                model.InputText,
                model.SourceLanguage ?? "auto",
                model.TargetLanguage
            );

            return View(model);
        }
    }
}