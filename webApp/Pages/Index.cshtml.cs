using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Currency.Services;
using System.ComponentModel.DataAnnotations;

namespace webApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICurrencyWordsService _currencyWordsService;

        [BindProperty]
        [MinLength(1), MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Range(0.00, 999.99)]
        [DataType(DataType.Currency)]
        public decimal? Number { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ICurrencyWordsService currencyWordsService)
        {
            _logger = logger;
            _currencyWordsService = currencyWordsService;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            ViewData["name"] = Name;
            if(Number.HasValue)
            {
                ViewData["number"] = _currencyWordsService.toWordsInDollarsAndCents(Number.Value);
            }
        }

    }
}
