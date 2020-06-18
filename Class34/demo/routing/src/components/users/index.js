import React from 'react';
import UserForm from './user-form';
import UserList from './user-list';

class Users extends React.Component{
  constructor(props){
    super(props);

    let usersFromStorage = JSON.parse(window.localStorage.users || '[]');

    this.state = {
      usersLoading: false,
      users: usersFromStorage,
    };
  }

  toggleUsersLoading = () => {
    // When state transition depends on previous state...
    // Pass a function to receive the most current state
    // then return the next value
    this.setState(
      state => ({ usersLoading: !state.usersLoading }),
      // Optional callback when state change is done
      () => {
        console.log('Loading toggled', this.state.usersLoading);
      });
  }

  setUsers = users => {
    console.log(users);
    this.setState({ users });

    window.localStorage.users = JSON.stringify(users);
  }

  render() {
    return (
      <>
        <h1>User Lookup</h1>
        <UserForm prompt="Load users..." onReceiveUsers={this.setUsers}
          toggleLoading={this.toggleUsersLoading} />
        <UserList users={this.state.users} loading={this.state.usersLoading} />
      </>
    );
  }
}

export default Users;
