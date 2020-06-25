import React from 'react';

// TODO: for lab, make this a function component!

export default class Login extends React.Component {

  handleSubmit = (e)  => {
    e.preventDefault();

    // Pull values out for *uncontrolled* inputs
    const { username, password } = e.target.elements;
    
    console.log(username.value, password.value);
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <input placeholder="Username" name="username" />
        <input placeholder="Password" type="password" name="password" />
        <button>Login</button>
      </form>
    )
  }
}
