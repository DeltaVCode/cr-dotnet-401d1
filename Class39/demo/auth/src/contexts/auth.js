import React, { useContext } from 'react';

export const AuthContext = React.createContext();

export default function useAuth() {
  return useContext(AuthContext);
}

export class AuthProvider extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      user: null,
    };
  }

  render() {
    return (
      <AuthContext.Provider value={this.state}>
        {this.props.children}
      </AuthContext.Provider>
    );
  }
}
