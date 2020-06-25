import React from 'react';

import Header from './components/header';
import ToDo from './components/todo/todo.js';
import Auth from './components/auth';

export default class App extends React.Component {
  render() {
    return (
      <>
        <Header />
        <ToDo />

        {/*
        <Auth>
          <ToDo />
        </Auth>
        <Auth not>
          <h1>Please Sign In</h1>
        </Auth>
        */}
      </>
    );
  }
}
