import React from 'react';
import { AuthContext } from '../../contexts/auth';

export default class Auth extends React.Component {
  static contextType = AuthContext;

  render() {
    const { user, permissions } = this.context;
    const { not, permission } = this.props;

    // TODO: simplify this!

    if (!user){
      if (not)
        return this.props.children;

      return null;
    }

    // TODO: maybe add a `can` function in context to decide?
    if(permission){
      if (permissions.includes(permission)) {
        return not ? null : this.props.children;
      }
      else {
        return not ? this.props.children : null;
      }
    }

    if(not)
      return null;

    return this.props.children;
  }
}