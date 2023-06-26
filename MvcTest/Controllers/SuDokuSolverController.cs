using Microsoft.AspNetCore.Mvc;
using MvcTest.MathLibrary;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class SuDokuSolverController : Controller
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Index()
        {
            SudokuPuzzle puzzle = new SudokuPuzzle();
            SudokuSolutionResult? result = null;
            if(HttpContext.Request.Method == "POST")
            {
                for (int x = 0; x < SudokuPuzzle.Size; x++)
                {
                    for (int y = 0; y < SudokuPuzzle.Size; y++)
                    {
                        string cellName = SudokuInputViewModel.GetCellName(x, y);
                        string? val = HttpContext.Request.Form[cellName].SingleOrDefault();
                        if (!String.IsNullOrWhiteSpace(val))
                        {
                            puzzle.SetCell(x, y, int.Parse(val));
                        }
                    }
                }
                result = puzzle.Solve();
            }
            
            ViewData.Model = new SudokuInputViewModel(puzzle, result);
            return View();
        }


        //[HttpPost]
        //public IActionResult Solve()
        //{
        //    SudokuPuzzle puzzle = new SudokuPuzzle();

        //    for(int x = 0; x < SudokuPuzzle.Size; x++)
        //    {
        //        for(int y = 0; y < SudokuPuzzle.Size; y++)
        //        {
        //            string cellName = SudokuInputViewModel.GetCellName(x, y);
        //            string? val = HttpContext.Request.Form[cellName].SingleOrDefault();
        //            if (val != null)
        //            {
        //                puzzle.SetCell(x, y, int.Parse(val));
        //            }
        //        }
        //    }

        //    puzzle.Solve();

        //    ViewData.Model = new SudokuInputViewModel(puzzle);
        //    return View();
        //}
    }
}
