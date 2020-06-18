import React from 'react';
import { Link, Switch, Route } from 'react-router-dom';
import Numbers from './numbers';
import Users from './users';

function Nav() {
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

function App() {
  return (
    <>
      <header>
        <h1>Routing Demo</h1>
        <Nav />
      </header>
      <Switch>
        <Route exact path="/">
          <h2>Welcome</h2>
          <p>You might be interested in our <Link to="/users">Users</Link></p>
        </Route>
        <Route path="/users">
          <Users />
        </Route>
        <Route path="/numbers">
          <Numbers />
        </Route>
        <Route>
          404
        </Route>
      </Switch>
      <footer>
        &copy; 2020
      </footer>
    </>
  );
}

export default App;