import React from 'react';
import { NavLink } from 'react-router-dom';

import useTheme from '../contexts/theme';
import useSettings from '../contexts/settings';

import './header.css';

export default function Header() {
  const theme = useTheme();
  const { title, twitter } = useSettings();
  
  return(
    <header className={theme.mode}>
      <h1>{title}</h1>
      <button onClick={() => theme.toggleMode()}>Toggle Theme</button>
      <nav>
        <ul>
          <li><NavLink to="/class">Class Counter</NavLink></li>
          <li><NavLink to="/hooks">Hooks Counter</NavLink></li>
          <li><a href={`https://twitter.com/${twitter}`}>Twitter</a></li>
        </ul>
      </nav>
    </header>
  );
}