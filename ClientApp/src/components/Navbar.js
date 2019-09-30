import React from 'react';
import {Link} from 'react-router-dom';

export const Navbar = () => {
    return (
        <nav className="navbarr">
            <h2 className="title">Suncoast Overflow</h2>
            <span className="question-count">... questions</span>

            <Link to='/createquestion'>
                <input className="btn btn-success" type="button" value="Got Question?" />
            </Link>

            <Link to="/home">Go Home</Link>
        </nav>
    );
}