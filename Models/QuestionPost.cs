using System;
using System.Collections.Generic;

namespace StackOverFlow.Models
{
  public class QuestionPost
  {
    public int Id { get; set; }

    public string ShortDescription { get; set; }

    public string Content { get; set; }

    public int PraisesForMyQuestionRelevance { get; set; }

    public DateTime DateOfPost { get; set; } = DateTime.Now;

    public List<AnswersPost> AnswersPosts { get; set; } = new List<AnswersPost>();
  }
}