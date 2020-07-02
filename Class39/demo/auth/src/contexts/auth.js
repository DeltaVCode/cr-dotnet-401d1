import React, { useContext } from 'react';
import jwt from 'jsonwebtoken';
import cookie from 'react-cookies';

const usersAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Users';

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
      if (this.processToken(body.token, body)){
        return;
      }
    }

    // TODO: maybe set userError state?
    this.logout();
  }

  logout = () => {
    this.setState({ user: null, permissions: [] });
    cookie.remove('auth');
  }

  processToken(token, user) {
    try {
      const payload = jwt.decode(token);
      if (payload) {
        // When processing cookie, read id/username from token payload
        if (!user) {
          user = {
            id: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
            username: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
          };
        }

        this.setState({
          user,
          permissions: payload.permissions || [],
        });
        cookie.save('auth', token);
        return true;
      }
    } catch(e){
      console.warn(e);
      this.logout();
    }
  }

  componentDidMount() {
    const cookieToken = cookie.load('auth');
    if (cookieToken) console.log('Found auth cookie!');

    this.processToken(cookieToken);
  }

  render() {
    return (
      <AuthContext.Provider value={this.state}>
        {this.props.children}
      </AuthContext.Provider>
    );
  }
}
