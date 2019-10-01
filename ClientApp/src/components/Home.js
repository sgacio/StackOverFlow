import React, { useEffect, useState } from 'react'
import { Question } from './Question'
import { Link } from 'react-router-dom'
import axios from 'axios'

export const Home = () => {
  const [data, setData] = useState([])

  const getData = () => {
    axios.get('https://localhost:5001/api/Question/BasicGetAll').then(res => {
      setData(res.data)
    })
  }

  useEffect(() => {
    getData()
  }, [])

  return (
    <div className="main-container">
      <ul className="flexMePls">
        {data.map((e, i) => {
          return (
            <li className="list" key={i}>
              <Link className="link" to={`/question/${e.id}`}>
                <Question
                  title={e.shortDescription}
                  shortDesc={e.content.substring(0, 20)}
                  praise={e.praisesForMyQuestionRelevance}
                  date={e.dateOfPost}
                />
                {console.log(e)}
              </Link>
            </li>
          )
        })}
      </ul>
    </div>
  )
}
