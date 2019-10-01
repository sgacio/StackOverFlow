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
      var answers = context.AnswerPosts.Where(x => x.QuestionPostId == Id);
      return answers.ToList();
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
    [HttpPut("numberOfViews/{Id}")]
    public ActionResult<Int32> postViews(int Id)
    {
      var question = context.QuestionPosts.FirstOrDefault(l => l.Id == Id);
      // var views = question.NumberOfViews + 1;
      // return views;
      question.NumberOfViews += 1;
      context.SaveChanges();
      return question.NumberOfViews;
    }
  }
}