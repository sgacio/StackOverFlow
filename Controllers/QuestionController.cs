using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using stackoverflow;
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

    [HttpGet("BasicGetAll")]
    public ActionResult<IEnumerable<QuestionPost>> GetAll()
    {
      var BringMeQuestions = context.QuestionPosts.OrderBy(l => l.Id);
      return BringMeQuestions.ToList();
    }

    [HttpGet("AllAnswersJoin/{Id}")]
    public ActionResult<IEnumerable<Object>> GetQuestionAnswers(int Id)
    {
      //   var context = new DatabaseContext();
      var QuestionReturned = context.QuestionPosts.Join(context.AnswerPosts, i => i.Id, l => l.QuestionPostId, (i, l) => new
      {
        QuestionId = i.Id,
        QuestionShortDescription = i.ShortDescription,
        QuestionContent = i.Content,
        QuestionDate = i.DateOfPost,
        QuestionUpDown = i.PraisesForMyQuestionRelevance,
        AnswerId = l.Id,
        AnswerContent = l.AnswerContent,
        AnswerDate = l.DateOfPost,
        AnswerUpDown = l.PraisesForMyAnswer
      }
      ).Where(s => s.QuestionId == Id);
      return QuestionReturned.ToList();
    }
    [HttpPost("CreateQuestion")]
    public ActionResult<QuestionPost> CreatePost([FromBody]QuestionPost entry)
    {
      context.QuestionPosts.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpGet("question/{Id}")]
    public ActionResult<IEnumerable<QuestionPost>> GetSingleQuestion(int Id)
    {
      var post = context.QuestionPosts.Where(i => i.Id == Id);
      return post.ToList();
    }
  }
}