import React from 'react';
import { Link } from 'react-router-dom';
import './nav.scss';

export default function Nav() {
  return (
    <nav>
      <ul>
        <li><Link to="/">Home</Link></li>
        <li><Link to="/users">Users</Link></li>
        <li><Link to="/numbers">Numbers</Link></li>
      </ul>
    </nav>
  );
}
