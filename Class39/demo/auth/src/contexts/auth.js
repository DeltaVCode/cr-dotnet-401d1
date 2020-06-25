import React, { useContext } from 'react';

const usersAPI = 'https://localhost:44331/api/v1/Users';

export const AuthContext = React.createContext();

export default function useAuth() {
  return useContext(AuthContext);
}

export class AuthProvider extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      user: null,

      // Functions!
      login: this.login,
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
      this.setState({ user: body });
      return;
    }

    // TODO: maybe set userError state?
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
