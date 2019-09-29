import React, {useEffect, useState} from 'react';
import {Question} from './Question';
import {Link} from 'react-router-dom'
import axios from 'axios'

export const Home = () => {
    const [data, setData] = useState([])

    const getData = () => {
        axios.get('https://localhost:5001/api/Question/BasicGetAll')
            .then(res => {
                setData(res.data)
            })
    }

    useEffect(() => {
        getData()
    }, []);

    return (
        <>
            <nav className="navbarr">
                <h2 className="title">Suncoast Overflow</h2>
                <span className="question-count">... questions</span>
                <Link to='createquestion'>
                    <input className="btn btn-success" type="button" value="Got Question?" />
                </Link>
            </nav>

            {data.map((e, i) => {
                return (
                    <li key={i}>
                        <Question 
                            title={e.shortDescription}
                            shortDesc={e.content.substring(0, 20)}
                            praise={e.praisesForMyQuestionRelevance} 
                            date={e.dateOfPost}/> 
                    </li>
                )
            })}
        </>
    );
}