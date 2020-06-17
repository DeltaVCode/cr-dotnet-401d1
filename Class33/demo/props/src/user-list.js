import React from 'react';

export default function UserList (props) {
  if (props.loading) {
    return (
      <h2>Loading.....</h2>
    );
  }

  return (
    <>
      <h2>User Count: {props.users.length}</h2>
      <ul>
        {props.users.map((user, index) => (
          <li key={index}>
            <a href={`#${user.id}`}>{user.username}</a> says <q>{user.bs}</q>
          </li>
        ))}
      </ul>
    </>
  );
}
