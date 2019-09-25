using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StackOverFlow;
using StackOverFlow.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StackOverFlow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionController : ControllerBase
  {
    private DatabaseContext context;

    public QuestionController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpGet("AllQuestions")]
    public ActionResult<IEnumerable<Object>> GetAllQuestions()
    {
      var QuestionReturned = context.QuestionPosts.Join(context.AnswerPost, i => i.AnswerPostId, l => l.Id, (i, l) => new
      {
        QuestionId = i.Id,
        QuestionShortDescription = i.ShortDescription,
        QuestionContent = i.Content,
        QuestionDate = i.DateOfPost,
        QuestionUpDown = i.PraisesForMyQuestionRelevance,
        AnswerId = l.Id,
        AnswerContent = l.Content,
        AnswerDate = l.DateOfPost,
        AnswerUpDown = l.PraisesForMyAnswer
      }
      );
      return QuestionReturned.ToList();
    }
  }
}