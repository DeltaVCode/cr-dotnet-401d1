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
    
    console.log(username.value, password.value);
  }

  render() {
    console.log('auth context', this.context);

    return (
      <form onSubmit={this.handleSubmit}>
        <input placeholder="Username" name="username" />
        <input placeholder="Password" type="password" name="password" />
        <button>Login</button>
      </form>
    )
  }
}
