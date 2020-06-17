import React from 'react';

export default function UserList (props) {
  if (props.loading) {
    return (
      <h2>Loading.....</h2>
    );
  }

  return (
    <h2>User Count: {props.users.length}</h2>
  );
}
