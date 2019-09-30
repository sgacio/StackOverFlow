using System;
using System.Collections.Generic;

namespace StackOverFlow.Models
{
  public class AnswersPost
  {
    public int Id { get; set; }

    public string AnswerContent { get; set; }

    public int PraisesForMyAnswer { get; set; }

    public DateTime DateOfPost { get; set; } = DateTime.Now;

    public int? QuestionPostId { get; set; }
  }
}