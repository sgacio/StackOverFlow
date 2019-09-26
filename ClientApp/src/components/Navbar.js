import React from 'react';
import {Link} from 'react-router-dom';

export const Navbar = () => {
    return (
        <nav>
            <Link to="/home">Go Home</Link>
        </nav>
    );
}