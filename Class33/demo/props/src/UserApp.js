import React from 'react';
import UserForm from './user-form';
import UserList from './user-list';

class UserApp extends React.Component{
  constructor(props){
    super(props);

    this.state = {
      users: [],
    };
  }

  setUsers = users => {
    console.log(users);
    this.setState({ users });
  }

  render() {
    return (
      <>
        <h1>User Lookup</h1>
        <UserForm prompt="Load users..." onReceiveUsers={this.setUsers} />
        <UserList users={this.state.users} />
      </>
    );
  }
}

export default UserApp;
