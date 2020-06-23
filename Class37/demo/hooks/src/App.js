import React from 'react';
import { NavLink, Switch, Route } from 'react-router-dom';
import ClassCounter from './components/class-counter';
import HooksCounter from './components/hooks-counter';

function App() {
  return (
    <div>
      <nav>
        <ul>
          <li><NavLink to="/class">Class Counter</NavLink></li>
          <li><NavLink to="/hooks">Hooks Counter</NavLink></li>
        </ul>
      </nav>
      <main>
        <Switch>
          <Route path="/class">
            <ClassCounter initialCount={5} />
          </Route>
          <Route path="/hooks">
            <HooksCounter initialCount={7} />
          </Route>
        </Switch>
      </main>
    </div>
  );
}

export default App;
