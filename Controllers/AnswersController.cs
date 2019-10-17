using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using stackoverflow;
using StackOverFlow.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StackOverFlow.ViewModels;

namespace StackOverFlow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnswersController : ControllerBase
  {
    private DatabaseContext context;

    public AnswersController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpPost("CreateAnswer/other")]
    public ActionResult<AnswersPost> nCreateAnswer([Bind("answerContent,questionPostId")] AnswersPost entry)
    {
      context.AnswerPosts.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpPost("CreateAnswer")]

    public ActionResult<AnswersPost> CreateAnswer([FromBody]AnswerVM entry)
    {
      if (context.QuestionPosts.Any(a => a.Id == entry.QuestionPostId))
      {
        var nAnswer = new AnswersPost
        {
          AnswerContent = entry.AnswerContent,
          QuestionPostId = entry.QuestionPostId
        };
        context.AnswerPosts.Add(nAnswer);
        context.SaveChanges();
        return nAnswer;
      }
      else
      {
        return BadRequest();
      }
    }

    [HttpGet("AllAnswers")]
    public ActionResult<IEnumerable<AnswersPost>> GetAll()
    {
      var pls = context.AnswerPosts.OrderBy(l => l.Id);
      return pls.ToList();
    }
  }
}