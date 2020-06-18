import React from 'react';
import { NavLink } from 'react-router-dom';
import './nav.scss';

export default function Nav() {
  return (
    <nav>
      <ul>
        <li><NavLink to="/" exact>Home</NavLink></li>
        <li><NavLink to="/users">Users</NavLink></li>
        <li><NavLink to="/numbers">Numbers</NavLink></li>
      </ul>
    </nav>
  );
}
