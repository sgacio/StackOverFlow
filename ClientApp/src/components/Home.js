import React from 'react';

export const Home = () => {
    return (
        <>
            <nav className="navbarr">
                <h2 className="title">Suncoast Overflow</h2>
                <span className="question-count">... questions</span>
                <input className="btn btn-success" type="button" value="Got Question?" />
            </nav>

            <ul className="question-list">
                <li className="question-body">
                    <h3 className="question-title">This is the TLDR for the question</h3>

                    <p className="question-shortdesc">
                        First like 150 characters or something like that. I don't know what to write here though so 
                        I'm just going to fill some of the space to make it look a little bit better.
                    </p>

                    <h5 className="question-user">User who asked the question</h5>

                    <div>
                        <span className="praise">Praises: </span>
                        <span className="answers">Answers: </span>
                        <span className="views">Views: </span>
                    </div>
                </li>
            </ul>
        </>
    );
}