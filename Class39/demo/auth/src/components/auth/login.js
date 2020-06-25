import React from 'react';
import { AuthContext } from '../../contexts/auth';

// TODO: for lab, make this a function component!

export default class Login extends React.Component {
  // in a function component you would use a hook instead
  static contextType = AuthContext;

  handleSubmit = (e)  => {
    e.preventDefault();

    // Pull values out for *uncontrolled* inputs
    const { username, password } = e.target.elements;

    this.context.login(username.value, password.value);
  }

  logoutSubmit = e => {
    e.preventDefault();

    this.context.logout();
  }

  render() {
    console.log('auth context', this.context);

    const { user } = this.context;

    if (user) {
      return (
        <h1>
          Welcome back, {user.username}!
          <form onSubmit={this.logoutSubmit}>
            <button>Log Out</button>
          </form>
        </h1>
        );
    }

    return (
      <form onSubmit={this.handleSubmit}>
        <input placeholder="Username" name="username" />
        <input placeholder="Password" type="password" name="password" />
        <button>Log In</button>
      </form>
    )
  }
}
