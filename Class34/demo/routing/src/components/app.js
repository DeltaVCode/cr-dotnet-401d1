import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Nav from './nav';
import Home from './home';
import Numbers from './numbers';
import Users from './users';

function App() {
  return (
    <>
      <header>
        <h1>Routing Demo</h1>
        <Nav />
      </header>
      <Switch>
        <Route exact path="/">
          <Home />
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