using IatPrepExam.Data;
using IatPrepExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IatPrepExam.Controllers
{
    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            var result = await _context.Questions.ToListAsync();
            return View(result);
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            Question question = new Question();
            for (int i = 0; i < 5; i++)
            {
                question.Alternatives.Add(new Alternative {});
            }
            return View(question);
        }

        // POST: Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Question/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = _context.Questions.Find(id);
            question.Alternatives = _context.Alternatives.Where(a => a.QuestionId == id).ToList();
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                var questionFromDb = _context.Questions.Find(question.QuestionId);
                questionFromDb.Statement = question.Statement;
                questionFromDb.Alternatives = question.Alternatives;
                _context.Questions.Update(questionFromDb);
                foreach (var item in questionFromDb.Alternatives)
                {
                    _context.Alternatives.Update(item);
                }
                _context.SaveChanges();
                var result = _context.Questions.Find(question.QuestionId);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
