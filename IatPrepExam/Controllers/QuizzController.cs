using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IatPrepExam.Data;
using IatPrepExam.Models;
using NuGet.Protocol;

namespace IatPrepExam.Controllers
{
    public class QuizzController : Controller
    {
        private readonly AppDbContext _context;

        public QuizzController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Quizz
        public IActionResult Index()
        {
            return View(_context.Quizzes.ToList());
        }

        // GET: Quizz/Details/5
        public IActionResult Details(int? id)
        {

            var AnsweredQuizz = _context.Quizzes.Include("Answers").Include(u => u.Questions).ThenInclude(u => u.Alternatives).Where(u => u.Id == id).First();
            string[] letters = { "A", "B", "C", "D", "E" };

            return View(AnsweredQuizz);
        }

        // GET: Quizz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quizz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        public IActionResult Create(Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                Quizz quizzWithQuestions = new Quizz();
                quizzWithQuestions.Id = quizz.Id;
                quizzWithQuestions.NameOfStudent = quizz.NameOfStudent;
                if (quizz.NumberOfQuestions < _context.Questions.Count())
                {
                    quizzWithQuestions.NumberOfQuestions = quizz.NumberOfQuestions;
                }
                else
                {
                    quizzWithQuestions.NumberOfQuestions = _context.Questions.Count();
                }
                quizzWithQuestions.StartedAt = DateTime.Now;
                var questionsFromDb = _context.Questions.ToList();
                quizzWithQuestions.Questions.AddRange(questionsFromDb.OrderBy(x => Random.Shared.Next()).Take(quizzWithQuestions.NumberOfQuestions));


                _context.Add(quizzWithQuestions);
                _context.SaveChanges();

                return RedirectToAction("TakeTest", new { Id = quizzWithQuestions.Id.ToString() });
            }
            return View(quizz);
        }

        // GET: Quizz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizz == null)
            {
                return NotFound();
            }

            return View(quizz);
        }

        // POST: Quizz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizz = await _context.Quizzes.FindAsync(id);
            if (quizz != null)
            {
                _context.Quizzes.Remove(quizz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizzExists(int id)
        {
            return _context.Quizzes.Any(e => e.Id == id);
        }

        public IActionResult TakeTest(int id)
        {
            var quizz = _context.Quizzes.Include(u => u.Questions).ThenInclude(u => u.Alternatives).Where(u => u.Id == id).First();
            return View(quizz);
        }

        [HttpPost]
        public IActionResult Results(Quizz quizz)
        {


            var x = Request.Form.ToDictionary(x => x.Key, x => x.Value);

            var AnsweredQuizz = _context.Quizzes.Include(u => u.Questions).ThenInclude(u => u.Alternatives).Where(u => u.Id == quizz.Id).First();
            string[] letters = { "A", "B", "C", "D", "E" };

            foreach (var question in AnsweredQuizz.Questions)
            {
                if (x.ContainsKey(question.QuestionId.ToString()))
                {
                    AnsweredQuizz.Answers.Add(new Answer { QuestionId = question.QuestionId, QuizzId = quizz.Id, AnswerValue = x.GetValueOrDefault(question.QuestionId.ToString()) });
                    int comparator = letters.ToList().IndexOf(x.GetValueOrDefault(question.QuestionId.ToString()));
                    var questionFromDB = _context.Questions.Where(u => u.QuestionId == question.QuestionId).Include("Alternatives").FirstOrDefault();
                    if (questionFromDB.Alternatives[comparator].IsRight)
                    {
                        AnsweredQuizz.Rights += 1;
                    }
                }
            }


            int Wrongs = (int)(AnsweredQuizz.Answers.Count - AnsweredQuizz.Rights);
            AnsweredQuizz.Score = (double)(AnsweredQuizz.Rights - (0.25 * Wrongs));
            double y = AnsweredQuizz.Score / AnsweredQuizz.Questions.Count();
            if (y < 0)
            {
                AnsweredQuizz.ScoreRatio = 0;
            }
            else
            {
                AnsweredQuizz.ScoreRatio = y;
            }

            if (AnsweredQuizz.FinishedAt.Year < 2000)
            {
                AnsweredQuizz.FinishedAt = DateTime.Now;
                _context.Quizzes.Update(AnsweredQuizz);
                _context.SaveChanges();
            }

            return View(_context.Quizzes.Find(quizz.Id));

        }
    }
}

