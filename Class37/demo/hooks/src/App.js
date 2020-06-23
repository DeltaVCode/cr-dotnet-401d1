import React from 'react';
import { NavLink, Switch, Route } from 'react-router-dom';
import ClassCounter from './components/class-counter';
import HooksCounter from './components/hooks-counter';
import TodoList from './components/todo-list';

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
          <Route path="/todo">
            <TodoList />
          </Route>
        </Switch>
      </main>
    </div>
  );
}

export default App;
