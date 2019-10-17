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
    <div>
      <ul className="container-fluid">
        {data.map((e, i) => {
          return (
            <div className="card m-5 justify-content-center" key={i}>
              <div className="card-header">
                <Link
                  className="list-group list-group-flush"
                  to={`/question/${e.id}`}
                >
                  <Question
                    className="list-group-item"
                    title={e.shortDescription}
                    shortDesc={e.content}
                    praise={e.praisesForMyQuestionRelevance}
                    date={e.dateOfPost}
                  />
                </Link>
              </div>
            </div>
          )
        })}
      </ul>
    </div>
  )
}
