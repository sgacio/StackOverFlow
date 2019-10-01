import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Answer } from './Answer'

export const SpecificQuestion = props => {
  const [question, setQuestion] = useState({})
  const [answers, setAnswers] = useState([])

  const getQuestion = async () => {
    await axios
      .get(
        `https://localhost:5001/api/Question/question/${props.match.params.id}`
      )
      .then(res => {
        console.log(res.data[0])
        setQuestion(res.data[0])
      })
  }

  const getAnswers = async () => {
    await axios
      .get(
        `https://localhost:5001/api/Question/AllAnswersJoin/${props.match.params.id}`
      )
      .then(res => {
        console.log(res)
        setAnswers(res.data)
      })
  }

  useEffect(() => {
    getQuestion()
    getAnswers()
  }, [])

  return (
    <main className="container">
      <div className="specific-container">
        <h1>Title: {question.shortDescription}</h1>
        <p>Content: {question.content}</p>

        <p>Date Created: {question.dateOfPost}</p>
        <p>Praise: {question.praisesForMyQuestionRelevance}</p>
      </div>
      <div className="things"></div>

      {answers.map((item, i) => {
        return (
          <li className="answer-container" key={i}>
            <Answer
              content={item.answerContent}
              date={item.dateOfPost}
              praise={item.praisesForMyAnswer}
            />
          </li>
        )
      })}
    </main>
  )
}
