import React from 'react';
import { NavLink } from 'react-router-dom';

import useTheme from '../contexts/theme';

import './header.css';

export default function Header() {
  const theme = useTheme();
  
  return(
    <header className={theme.mode}>
      <button onClick={() => theme.toggleMode()}>Toggle Theme</button>
      <nav>
        <ul>
          <li><NavLink to="/class">Class Counter</NavLink></li>
          <li><NavLink to="/hooks">Hooks Counter</NavLink></li>
        </ul>
      </nav>
    </header>
  );
}