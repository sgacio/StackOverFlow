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
  public class AnswersController : ControllerBase
  {
    private DatabaseContext context;

    public AnswersController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpPost("CreateAnswer")]
    public ActionResult<AnswersPost> CreateAnswer([FromBody]AnswersPost entry)
    {
      context.AnswerPosts.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpGet("AllAnswers")]
    public ActionResult<IEnumerable<AnswersPost>> GetAll()
    {
      var pls = context.AnswerPosts.OrderBy(l => l.Id);
      return pls.ToList();
    }
  }
}