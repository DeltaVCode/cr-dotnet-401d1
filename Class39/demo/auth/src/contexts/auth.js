import React, { useContext } from 'react';
import jwt from 'jsonwebtoken';

const usersAPI = 'https://deltav-todo-alpha.azurewebsites.net/api/v1/Users';

export const AuthContext = React.createContext();

export default function useAuth() {
  return useContext(AuthContext);
}

export class AuthProvider extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      user: null,
      permissions: [],

      // Functions!
      login: this.login,
      logout: this.logout,
    };
  }

  login = async (username, password) => {
    const result = await fetch(`${usersAPI}/Login`, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });

    const body = await result.json();

    if (result.ok){
      const payload = jwt.decode(body.token);
      this.setState({
        user: body,
        permissions: payload.permissions || []
      });
      return;
    }

    // TODO: maybe set userError state?
    this.logout();
  }

  logout = () => {
    this.setState({ user: null });
  }

  render() {
    return (
      <AuthContext.Provider value={this.state}>
        {this.props.children}
      </AuthContext.Provider>
    );
  }
}
